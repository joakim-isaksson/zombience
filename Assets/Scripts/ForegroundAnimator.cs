using UnityEngine;
using System.Collections;

public class ForegroundAnimator : MonoBehaviour
{

	public GameObject Prefab;
	public float MinDelay;
	public float MaxDelay;
	public float MinSpeed;
	public float MaxSpeed;
	public float MinSize;
	public float MaxSize;

	public Transform CenterPoint;

	// need to be positive
	public float MinOffsetX;
	public float MinOffsetY;
	public float MaxOffsetX;
	public float MaxOffsetY;
	public float MinRotationSpeed;
	public float MaxRotationSpeed;

	private float speed;
	private float rotationSpeed;
	private GameObject obj;
	private Vector3 targetPoint;

	void Start()
	{
		StartCoroutine(SpawnAfterDelay(Random.Range(MinDelay, MaxDelay)));
	}

	void Update()
	{
		if (obj == null) return;

		if (!obj.transform.position.Equals(targetPoint))
		{
			float step = speed * Time.deltaTime;
			obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPoint, step);
			step = rotationSpeed * Time.deltaTime;
			obj.transform.Rotate(0, 0, step);
		}
		else
		{
			Destroy(obj);
			StartCoroutine(SpawnAfterDelay(Random.Range(MinDelay, MaxDelay)));
		}
	}

	IEnumerator SpawnAfterDelay(float time)
	{
		yield return new WaitForSeconds(time);

		speed = Random.Range(MinSpeed, MaxSpeed);

		int direction = 1;
		if (Random.value > 0.5) direction = -1;

		Vector3 fromPoint = new Vector3(
			direction * Random.Range(MinOffsetX, MaxOffsetX),
			direction * Random.Range(MinOffsetX, MaxOffsetX),
			0
		);

		targetPoint = new Vector3(
			(-direction) * Random.Range(MinOffsetX, MaxOffsetX),
			(-direction) * Random.Range(MinOffsetX, MaxOffsetX),
			0
		);

		obj = (GameObject)Instantiate(Prefab, fromPoint, Quaternion.identity);
		float newScale = Random.Range(MinSize, MaxSize);
		obj.transform.localScale = new Vector3(newScale, newScale, 1f);
		rotationSpeed = Random.Range(MinRotationSpeed, MaxRotationSpeed);
	}
}
