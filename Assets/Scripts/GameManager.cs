using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public CameraController CameraController;
	public GameObject ActiveCheckPoint;

	public GameObject ZombiePrefab;
	public GameObject GooPrefab;

	public void SpawnZombie()
	{
		GameObject character = (GameObject)Instantiate(ZombiePrefab, ActiveCheckPoint.transform.position, ActiveCheckPoint.transform.rotation);
		CameraController.FollowObject = character;
		character.GetComponent<CharacterController>().Manager = this;
	}

	public void SpawnGoo()
	{
		GameObject character = (GameObject)Instantiate(GooPrefab, ActiveCheckPoint.transform.position, ActiveCheckPoint.transform.rotation);
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
