using UnityEngine;
using System.Collections;

public class BalloonLogic : MonoBehaviour
{
	public float DestroyOnAltitude;

	private Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start()
	{
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y > DestroyOnAltitude) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player"))
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
	}
}
