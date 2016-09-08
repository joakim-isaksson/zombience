using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
	[HideInInspector]
	public bool FacingRight = true;
	[HideInInspector]
	public bool Grounded = false;

	[HideInInspector]
	public bool Jump = false;
	[HideInInspector]
	public bool Freezed = false;

	public bool Flipping = false;
	public float JumpForce = 1.0f;
	public float WalkingForce = 0.5f;
	public float MaxWalkingSpeed = 1.0f;
	public float JumpCD = 0.6f;

	public float LeathalFallingVelocity = -10.0f;

	public Transform GroundCheckPoint;

	public AudioClip JumpSound;
	public AudioClip SpawnSound;
	public AudioClip HitGroundSound;

	[HideInInspector]
	public GameManager Manager;

	private Rigidbody2D rb;
	private AudioSource audioSource;
	private Animator animator;

	private bool died = false;
	private bool jumpOnCooldown;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioSource = GetComponentInChildren<AudioSource>();
	}

	void Start()
	{
		audioSource.PlayOneShot(SpawnSound);
	}

	void Update()
	{
		Grounded = Physics2D.Linecast(transform.position, GroundCheckPoint.position, 1 << LayerMask.NameToLayer("Ground"));

		if (!Freezed && Grounded && !jumpOnCooldown && Input.GetButtonDown("Jump"))
		{
			StartCoroutine(SetJumpOnCooldown(JumpCD));
			Jump = true;
		}

		animator.SetBool("Grounded", Grounded);
		animator.SetFloat("VelocityX", rb.velocity.x);
		animator.SetFloat("VelocityY", rb.velocity.y);
	}

	void FixedUpdate()
	{
		if (rb.velocity.y < LeathalFallingVelocity)
		{
			// *** DEATH BY FALLING
			if (!died && Grounded)
			{
				died = true;
				audioSource.PlayOneShot(HitGroundSound);
				Freezed = true;
				animator.SetTrigger("Death");
				StartCoroutine(DestroyAndSpawn(2.0f));
			}
		}

		if (Freezed)
		{
			rb.constraints = RigidbodyConstraints2D.FreezePositionX;
			return;
		}

		float h = Input.GetAxis("Horizontal");

		float force = WalkingForce;
		float jumpForce = JumpForce;
		float maxSpeed = MaxWalkingSpeed;

		rb.AddForce(Vector2.right * h * force);

		if (h * rb.velocity.x < maxSpeed)
			rb.AddForce(Vector2.right * h * force);

		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

		if (Flipping)
		{
			if (h > 0 && !FacingRight) Flip();
			else if (h < 0 && FacingRight) Flip();
		}

		if (Jump)
		{
			if (!Freezed)
			{
				audioSource.PlayOneShot(JumpSound);
				rb.AddForce(new Vector2(0f, jumpForce));
				animator.SetTrigger("Jump");
			}
			Jump = false;
		}
	}

	void Flip()
	{
		FacingRight = !FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DestroyAndSpawn(float time)
	{
		yield return new WaitForSeconds(time);
		Manager.SpawnGoo();
		Destroy(gameObject);
	}

	IEnumerator SetJumpOnCooldown(float time)
	{
		jumpOnCooldown = true;
		yield return new WaitForSeconds(time);
		jumpOnCooldown = false;
	}
}
