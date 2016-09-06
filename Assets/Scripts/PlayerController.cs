using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	[HideInInspector]
	public bool FacingRight = true;
	[HideInInspector]
	public bool Grounded = false;

	[HideInInspector]
	public bool Jump = false;
	[HideInInspector]
	public bool Freezed = false;

	public float JumpForce = 1.0f;
	public float WalkingForce = 0.5f;
	public float MaxWalkingSpeed = 1.0f;

	public AudioClip JumpSound;
	public Transform GroundCheckPoint;

	private AudioSource audioSource;

	void Awake()
	{
		//audioSource = GetComponentInChildren<AudioSource>();
	}

	void Update()
	{
		Grounded = Physics2D.Linecast(transform.position, GroundCheckPoint.position, 1 << LayerMask.NameToLayer("Ground"));

		if (!Freezed)
		{
			if (Grounded && Input.GetButtonDown("Jump"))
			{
				Jump = true;
			}

		}
	}

	void FixedUpdate()
	{

		if (Freezed)
		{
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
			return;
		}

		float h = Input.GetAxis("Horizontal");

		float force = WalkingForce;
		float jumpForce = JumpForce;
		float maxSpeed = MaxWalkingSpeed;

		GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * force);

		if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * force);

		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (h > 0 && !FacingRight) Flip();
		else if (h < 0 && FacingRight) Flip();

		if (Jump)
		{
			if (!Freezed)
			{
				//audioSource.PlayOneShot(jumpSound);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
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
}
