using UnityEngine;
using System.Collections;

public class DynamicPlant : MonoBehaviour
{
	[SerializeField]
	private float maxRotation = 45f;

	[SerializeField]
	private float rotationSpeed = 5f;

	private float currentRotation = 0f;
	private float originalRotation = 0f;
	private float timeToRotate = 0f;
	private float randomTimeOffset = 0f;

	void Awake()
	{
		originalRotation = transform.localEulerAngles.z;
		currentRotation = originalRotation;

		randomTimeOffset = Random.Range(0f, Mathf.PI * 10f);
	}

	void Update()
	{
		timeToRotate -= Time.deltaTime;
		float targetRotation = (Mathf.Sin((Time.time + randomTimeOffset) * rotationSpeed) * maxRotation * Mathf.Clamp01(timeToRotate)) + originalRotation;

		currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * 10f);

		// Reset rotation
		transform.localEulerAngles = Vector3.zero;

		// Apply new rotation
		transform.Rotate(Vector3.forward, currentRotation);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		timeToRotate = 2f;
	}
}
