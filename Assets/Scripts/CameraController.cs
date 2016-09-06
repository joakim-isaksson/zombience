using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public float RightOffset = 12f;
	public float LeftOffset = -12f;
	public float TopOffset = 9f;
	public float BottomOffset = 9f;

	public float LeftEdge = -62f;
	public float RightEdge = 100f;
	public float TopEdge = 40;
	public float BottomEdge = -1;

	private float CameraSpeedX = 4.0f;
	private float CameraSpeedY = 0.5f;

	private GameObject player;
	private PlayerController playerController;

	private float oldPlayerPosY;
	private float targetX;
	private float targetY;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		targetX = transform.position.x;
		targetY = transform.position.y;
		oldPlayerPosY = player.transform.position.y;
	}

	void FixedUpdate()
	{

		float cameraX = transform.position.x;
		float cameraY = transform.position.y;
		float cameraZ = transform.position.z;

		float offsetX = cameraX - player.transform.position.x;
		float offsetY = cameraY - player.transform.position.y;

		if (playerController.FacingRight && offsetX < RightOffset)
			targetX = player.transform.position.x + RightOffset;
		else if (offsetX > LeftOffset)
			targetX = player.transform.position.x + LeftOffset;

		if (oldPlayerPosY < player.transform.position.y && offsetY < TopOffset)
			targetY = player.transform.position.y + TopOffset;
		else if (oldPlayerPosY > player.transform.position.y && offsetY > BottomOffset)
			targetY = player.transform.position.y + BottomOffset;

		var vertExtent = Camera.main.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;
		float minX = LeftEdge + (horzExtent / 2);
		float maxX = RightEdge - (horzExtent / 2);
		float minY = BottomEdge + (vertExtent / 2);
		float maxY = TopEdge - (vertExtent / 2);

		float speedY = CameraSpeedY;
		if (oldPlayerPosY > player.transform.position.y && offsetY > BottomOffset)
		{
			speedY *= 20;
		}

		targetX = Mathf.Clamp(targetX, minX, maxX);
		targetY = Mathf.Clamp(targetY, minY, maxY);

		cameraX = Mathf.Lerp(cameraX, targetX, Time.deltaTime * CameraSpeedX);
		cameraY = Mathf.Lerp(cameraY, targetY, Time.deltaTime * speedY);

		transform.position = new Vector3(cameraX, cameraY, cameraZ);
		oldPlayerPosY = player.transform.position.y;
	}
}
