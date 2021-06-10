using UnityEngine;

namespace LubBug.HungryShark
{
	public class Bubbles : MonoBehaviour
	{
		private float timeSpawned;

		void Start()
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
			timeSpawned = Time.time;
		}

		void Update()
		{
			if (Time.time - timeSpawned > 3f)
			{
				Destroy(gameObject);
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Waves"))
				Destroy(gameObject);
		}
	}
}