using UnityEngine;
using System.Collections;

public class DoNotDestroyOnLoad : MonoBehaviour
{

	private static DoNotDestroyOnLoad instance = null;

	public static DoNotDestroyOnLoad Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
		}

		DontDestroyOnLoad(gameObject);
	}
}
