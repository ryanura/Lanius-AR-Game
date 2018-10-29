using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {
	public static int EnemiesAlive = 0;
	public Wave[] waves;
	public float timeBetweenWaves = 5f;
	public Transform spawnPoint;
	public GameObject BatPrefab;
	public float SpawnInterval = 3;
	public Text waveCountdownText;
	public TheGameManager gameManager;
	private int waveIndex = 0;
	private float countDown = 2f;
	
	void Start()
	{
		
	}

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.GameOver();
			this.enabled = false;
		}

		if (countDown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countDown = timeBetweenWaves;
			return;
		}

		countDown -= Time.deltaTime;

		countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
		//Debug.Log (countDown);
		
		//waveCountdownText.text = string.Format("{0:00.00}", countDown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;

	}
	void SpawnEnemy (GameObject enemy) 
	{
		//Debug.Log("Spawn!");
		Instantiate(BatPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
