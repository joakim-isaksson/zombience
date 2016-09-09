using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AnyKeyToStart : MonoBehaviour
{

	private bool started = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}

		if (!started && Input.anyKeyDown)
		{
			started = true;
			SceneManager.LoadScene("Level1");
		}
	}
}
