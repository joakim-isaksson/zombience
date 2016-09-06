using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float OffSetX = 4f;
	public float OffSetY = 2f;
	public float CameraSpeed = 4.0f;

	private GameObject player;
	private PlayerController playerController;

	private float targetX;
	private float targetY;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		targetX = player.transform.position.x;
		targetY = player.transform.position.y;
	}

	void FixedUpdate()
	{
		float cameraX = transform.position.x;
		float cameraY = transform.position.y;
		float cameraZ = transform.position.z;

		targetX = player.transform.position.x + OffSetX;
		targetY = player.transform.position.y + OffSetY;

		float offsetX = cameraX - player.transform.position.x;
		float offsetY = cameraY - player.transform.position.y;

		cameraX = Mathf.Lerp(cameraX, targetX, Time.deltaTime * CameraSpeed);
		cameraY = Mathf.Lerp(cameraY, targetY, Time.deltaTime * CameraSpeed);

		transform.position = new Vector3(cameraX, cameraY, cameraZ);
	}
}
