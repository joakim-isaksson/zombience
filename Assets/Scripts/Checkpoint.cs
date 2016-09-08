using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public Sprite ActiveSprite;
	public Sprite DeactiveSprite;
	public Transform SpawnPoint;

	private GameManager manager;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = DeactiveSprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		spriteRenderer.sprite = ActiveSprite;
		manager.SpawnPoint = SpawnPoint;
	}
}
