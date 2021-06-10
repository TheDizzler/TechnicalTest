using LubBug.HungryShark.GameManager;
using UnityEngine;

namespace LuvBug.HungryShark.Fish
{
	public class FishController : MonoBehaviour
	{
		public bool isPoison;

		[SerializeField]
		private GameObject bubblePrefab = null;

		private Rigidbody2D body;
		private Camera mainCamera;
		private SpriteRenderer spriteRenderer;
		private GameManager gameManager;


		void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			mainCamera = Camera.main;
			spriteRenderer = GetComponent<SpriteRenderer>();
			gameManager = GameObject.FindGameObjectWithTag("GameManager")
				.GetComponent<GameManager>();
		}


		public void Spawn(Vector2 position, Vector2 direction, float speed)
		{
			transform.localPosition = position;
			body.velocity = direction * speed;
		}


		public bool Eaten()
		{
			if (!isPoison)
			{
				Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
				RemoveFromGame();

			}

			return !isPoison;
		}

		private void RemoveFromGame()
		{
			gameManager.RemoveFish(this);
			Destroy(gameObject);
		}

		void Update()
		{
			if (CheckOutOfBounds())
			{
				RemoveFromGame();
			}
		}




		private bool CheckOutOfBounds()
		{
			// Check if actor is out of camera
			Vector3 vpPos = mainCamera.WorldToViewportPoint(transform.localPosition);
			if (vpPos.x < -0.1f || vpPos.x > 1.1f)
			{
				return true;
			}

			return false;
		}
	}
}