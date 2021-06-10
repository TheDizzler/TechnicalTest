using System;
using System.Collections.Generic;
using LuvBug.HungryShark.Fish;
using LuvBug.HungryShark.Player;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace LubBug.HungryShark.GameManager
{
	public class GameManager : MonoBehaviour
	{
		public float maxTimeBetweenSpawn = 10;

		[Tooltip("Chance out of 10 that fish is poisoned")]
		public int poisonChance = 2;
		public GameObject fishPrefab;
		public GameObject poisonFishPrefab;

		[SerializeField]
		private SharkController shark = null;
		[SerializeField]
		private GameObject startPanel = null;
		[SerializeField]
		private TextMeshProUGUI scoreText = null;
		[SerializeField]
		private TextMeshProUGUI timerText = null;
		[SerializeField]
		private GameObject gameOverPanel = null;
		[SerializeField]
		private GameObject winPanel = null;
		[SerializeField]
		private TextMeshProUGUI finalScoreText = null;
		[SerializeField]
		private TextMeshProUGUI winScoreText = null;


		private Random rng;
		private float nextSpawnTime;
		private float timeLastSpawn;
		private int score;
		private float timeRemaining;

		private List<FishController> activeFish = new List<FishController>();


		void Awake()
		{
			rng = new Random();
			this.enabled = false;
			startPanel.SetActive(true);
			winPanel.SetActive(false);
			gameOverPanel.SetActive(false);
		}


		public void StartGame()
		{
			score = 0;
			timeRemaining = 5 * 60;
			nextSpawnTime = (float)rng.NextDouble() * maxTimeBetweenSpawn;
			timeLastSpawn = Time.time;
			
			winPanel.SetActive(false);
			startPanel.SetActive(false);
			gameOverPanel.SetActive(false);
			
			activeFish.Clear();

			enabled = true;
			shark.StartGame();
		}

		public void AteFish()
		{
			scoreText.text = ++score + "";
		}

		
		public void RemoveFish(FishController fish)
		{
			activeFish.Remove(fish);
		}

		public void GameOver()
		{
			gameOverPanel.SetActive(true);
			finalScoreText.text = "Fish Eaten: " + score;
			enabled = false;
			foreach (var fish in activeFish)
				Destroy(fish.gameObject);
		}

		public void Win()
		{
			winPanel.SetActive(true);
			winScoreText.text = "Fish Eaten: " + score;
			enabled = false;
			shark.enabled = false;
			foreach (var fish in activeFish)
				Destroy(fish.gameObject);
		}


		void Update()
		{
			if (Time.time - timeLastSpawn > nextSpawnTime)
			{
				nextSpawnTime = (float)rng.NextDouble() * maxTimeBetweenSpawn;
				FishController newFish;
				if (rng.Next(0, 10) <= poisonChance)
				{
					newFish = Instantiate(poisonFishPrefab).GetComponent<FishController>();
				}
				else
				{
					newFish = Instantiate(fishPrefab).GetComponent<FishController>();
				}

				activeFish.Add(newFish);
				Vector2 pos = new Vector2(7, 2 - (float)rng.NextDouble() * 6);
				newFish.Spawn(pos, Vector2.left, 2);
				timeLastSpawn = Time.time;
			}

			timeRemaining -= Time.deltaTime;

			if (timeRemaining <= 0)
			{
				timerText.text = System.TimeSpan.FromSeconds(0)
					.ToString("mm':'ss");
				Win();
			}
			else
				timerText.text = System.TimeSpan.FromSeconds(timeRemaining)
					.ToString("mm':'ss");
		}
	}
}