using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public CameraController CameraController;
	public Transform SpawnPoint;

	public GameObject ZombiePrefab;
	public GameObject GooPrefab;

	public bool Zombie;

	public void SpawnZombie()
	{
		SpawnZombie(SpawnPoint);
	}

	public void SpawnZombie(Transform transform)
	{
		Zombie = true;
		GameObject character = (GameObject)Instantiate(ZombiePrefab, transform.position, transform.rotation);
		CameraController.FollowObject = character;
		character.GetComponent<CharacterController>().Manager = this;
	}

	public void SpawnGoo()
	{
		Zombie = false;
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

		if (Input.GetButtonDown("Reset"))
		{
			SceneManager.LoadScene(0);
		}
	}
}
