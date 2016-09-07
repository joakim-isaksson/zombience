using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public CameraController CameraController;
	public Transform SpawnPoint;

	public GameObject ZombiePrefab;
	public GameObject GooPrefab;

	public void SpawnZombie()
	{
		GameObject character = (GameObject)Instantiate(ZombiePrefab, SpawnPoint.position, SpawnPoint.rotation);
		CameraController.FollowObject = character;
		character.GetComponent<CharacterController>().Manager = this;
	}

	public void SpawnGoo()
	{
		GameObject character = (GameObject)Instantiate(GooPrefab, SpawnPoint.position, SpawnPoint.rotation);
		CameraController.FollowObject = character;
		character.GetComponent<CharacterController>().Manager = this;
	}

	void Start()
	{
		SpawnZombie();
	}

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
	}
}
