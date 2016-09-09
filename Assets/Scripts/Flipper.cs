using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour
{

	private GameObject follow = null;

	// Update is called once per frame
	void Update()
	{
		if (follow == null) return;
		if (follow.transform.position.x < transform.position.x)
		{
			Vector3 theScale = transform.localScale;
			theScale.x = -Mathf.Abs(theScale.x);
			transform.localScale = theScale;
		}
		else
		{
			Vector3 theScale = transform.localScale;
			theScale.x = Mathf.Abs(theScale.x);
			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player")) follow = other.gameObject;
	}
}
