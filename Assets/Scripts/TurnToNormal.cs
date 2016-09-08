using UnityEngine;
using System.Collections;

public class TurnToNormal : MonoBehaviour
{
	private GameManager manager;

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player") && !manager.Zombie)
		{
			Destroy(other.gameObject);
			manager.SpawnZombie(other.transform);
		}
	}
}
