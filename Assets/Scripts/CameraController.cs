using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float OffSetX = 4f;
	public float OffSetY = 2f;
	public float CameraSpeed = 4.0f;

	[HideInInspector]
	public GameObject FollowObject;

	private float targetX;
	private float targetY;

	void FixedUpdate()
	{
		float cameraX = transform.position.x;
		float cameraY = transform.position.y;
		float cameraZ = transform.position.z;

		targetX = FollowObject.transform.position.x + OffSetX;
		targetY = FollowObject.transform.position.y + OffSetY;

		float offsetX = cameraX - FollowObject.transform.position.x;
		float offsetY = cameraY - FollowObject.transform.position.y;

		cameraX = Mathf.Lerp(cameraX, targetX, Time.deltaTime * CameraSpeed);
		cameraY = Mathf.Lerp(cameraY, targetY, Time.deltaTime * CameraSpeed);

		transform.position = new Vector3(cameraX, cameraY, cameraZ);
	}
}
