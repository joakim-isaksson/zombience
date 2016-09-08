using UnityEngine;
using System.Collections;

public class DestroyOnKeyPress : MonoBehaviour
{

	public float delay = 3.0f;

	private bool destroyed = false;

	void Update()
	{
		if (!destroyed && Input.anyKeyDown)
		{
			destroyed = true;
			Destroy(gameObject, delay);
		}
	}
}
