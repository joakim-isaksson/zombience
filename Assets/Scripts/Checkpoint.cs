using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public Sprite ActiveSprite;
	public Sprite DeactiveSprite;
	public Transform SpawnPoint;

	public AudioClip ActivationSound;

	private GameManager manager;
	private SpriteRenderer spriteRenderer;

	private AudioSource audioSource;

	private bool activated = false;

	void Awake()
	{
		audioSource = GetComponentInChildren<AudioSource>();
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = DeactiveSprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!activated)
		{
			activated = true;
			audioSource.PlayOneShot(ActivationSound);
			spriteRenderer.sprite = ActiveSprite;
			manager.SpawnPoint = SpawnPoint;
		}

	}
}
