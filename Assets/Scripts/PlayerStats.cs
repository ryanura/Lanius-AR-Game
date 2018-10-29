using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public static int Score;
	public static int CurPHealth;
	public int StartPHealth = 50;
	public static int Rounds;
	
	public static bool IsFortified;
	public TheGameManager gameManager;
	public int PlayerDamage;
	private float RoundTimer;

	// Use this for initialization
	void Start () {
		Score = 0;
		CurPHealth = StartPHealth;
		gameManager.UpdateStats(Score, CurPHealth, RoundTimer);

		Rounds = 0;
		RoundTimer = 60f;

		PlayerDamage = 1;
		IsFortified = false;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		gameManager.UpdateStats(Score, CurPHealth, RoundTimer) ;
		RoundTimer -= Time.deltaTime;
		if (RoundTimer <= 0 || CurPHealth <= 0 )
		{
			gameManager.GameOver();
		}
	}

	// public void TakeDamage(int _amount)
	// {
	// 	CurPHealth -= _amount;
		
	// 	if (CurPHealth <= 0)
	// 	{
	// 		gameManager.GameOver(Score, CurPHealth);
	// 	}
	// }
}
