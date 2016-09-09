using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour
{

	public Transform Target;
	public float MultiplierX;
	public float MultiplierY;

	private float targetOldX;
	private float targetOldY;

	void Start()
	{
		targetOldX = Target.position.x;
		targetOldY = Target.position.y;
	}

	void Update()
	{
		float moveX = (Target.position.x - targetOldX) * MultiplierX;
		float moveY = (Target.position.y - targetOldY) * MultiplierY;

		transform.position = new Vector3(
			transform.position.x + moveX,
			transform.position.y + moveY,
			transform.position.z
		);

		targetOldX = Target.position.x;
		targetOldY = Target.position.y;
	}
}
