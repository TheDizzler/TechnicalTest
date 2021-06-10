using System.Collections;
using LubBug.HungryShark.GameManager;
using LuvBug.HungryShark.Fish;
using UnityEngine;

namespace LuvBug.HungryShark.Player
{
	public class SharkController : MonoBehaviour
	{
		[SerializeField]
		private GameManager gameManager = null;
		[SerializeField]
		private float maxHorizontalAcceleration = 5;
		[SerializeField]
		private float maxVerticalAcceleration = 5;
		[SerializeField]
		private float maxHorizontalSpeed = 10;
		[SerializeField]
		private float maxVerticalSpeed = 10;

		private Rigidbody2D body;
		private Camera mainCamera;
		private SpriteRenderer spriteRenderer;
		private Vector2 startPos;


		void Start()
		{
			body = GetComponent<Rigidbody2D>();
			mainCamera = Camera.main;
			spriteRenderer = GetComponent<SpriteRenderer>();
			this.enabled = false;
			startPos = transform.localPosition;
		}


		public void StartGame()
		{
			this.enabled = true;
			spriteRenderer.color = Color.white;
			spriteRenderer.flipY = false;
			body.velocity = Vector2.zero;
			transform.localPosition = startPos;
		}

		void Update()
		{
			if (Input.GetKey(KeyCode.D))
			{
				if (body.velocity.x < maxHorizontalSpeed)
					body.AddForce(new Vector2(maxHorizontalAcceleration, 0));
			}
			else if (Input.GetKey(KeyCode.A))
			{
				if (body.velocity.x > -maxHorizontalSpeed)
					body.AddForce(new Vector2(-maxHorizontalAcceleration, 0));
			}

			if (Input.GetKey(KeyCode.W))
			{
				if (body.velocity.y < maxVerticalSpeed)
					body.AddForce(new Vector2(0, maxVerticalAcceleration));
			}
			else if (Input.GetKey(KeyCode.S))
			{
				if (body.velocity.y > -maxVerticalSpeed)
					body.AddForce(new Vector2(0, -maxVerticalAcceleration));
			}

			if (body.velocity.x > 0)
			{
				spriteRenderer.flipX = false;
			}
			else if (body.velocity.x < 0)
				spriteRenderer.flipX = true;
		}


		void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.collider.CompareTag("Fish"))
			{
				if (collision.gameObject.GetComponent<FishController>().Eaten())
					gameManager.AteFish();
				else
				{
					StartCoroutine(Sick());
				}
			}
		}

		private IEnumerator Sick()
		{
			this.enabled = false;
			gameManager.GameOver();
			spriteRenderer.flipY = true;
			body.velocity = new Vector2(0, 1);

			Color startColor = spriteRenderer.color;
			Color endColor = Color.green;

			float t = 0;
			while (t < 1)
			{
				t += Time.deltaTime;
				spriteRenderer.color = Color.Lerp(startColor, endColor, t);
				yield return null;
			}
		}
	}
}