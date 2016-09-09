using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TheEnd : MonoBehaviour
{
	public float EndDelay = 10.0f;
	public GameObject Credits;

	private bool gameEnded = false;

	// Use this for initialization
	void Start()
	{
		Credits.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag.Equals("Player"))
		{
			Credits.SetActive(true);
			if (!gameEnded)
			{
				gameEnded = true;
				StartCoroutine(EndGameWithDelay(EndDelay));
			}
		}
	}

	IEnumerator EndGameWithDelay(float time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("StartScreen");
	}
}
