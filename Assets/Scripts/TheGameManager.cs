using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheGameManager : MonoBehaviour {

	bool isGameOver;
	
	int FinalPoint;
	int FinalHealth;
	float FinalTimer;
	AudioSource BGM;
	
	public TMP_Text ScoreText;
	public TMP_Text TimerText;
	public TMP_Text HealthText;
	public TMP_Text DebugLogUIText;
	public TMP_Text GameOverUI;
	public TMP_Text TotalScore;
	public TMP_Text HealthRemaining;
	public GameObject GameOverPanel;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		isGameOver = false;
		BGM = GetComponent<AudioSource>();
		
	}

	public void GameOver ()
	{
		if (isGameOver){
			return;
		}
		
		isGameOver = true;

		GameOverPanel.SetActive (true);
		TotalScore.text = "Total " + ScoreText.text;
		HealthRemaining.text = "Total " + HealthText.text;
	}


	public void AplicationQuit(){
		Application.Quit();
	
	}

	public void UpdateStats (int _Score, int _CurPHealth, float _RoundTimer)
	{
		ScoreText.text = "Score : " + _Score.ToString();
		HealthText.text = "Health : " + _CurPHealth.ToString();
		TimerText.text = "Timer : " + _RoundTimer.ToString("f0");
	
	}

	public void ToggleBGM(bool BGMPlay)
	{
		if (BGMPlay == true){
			BGM.Play();
		}else
		{
			BGM.Stop();
		}
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		// if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
		// {
		// 	Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		// 	RaycastHit raycastHit;
		// 	if (Physics.Raycast(raycast, out raycastHit))
		// 	{
		// 		Debug.Log("Something Hit");
		// 		if (raycastHit.collider.name == "Bat_Green")
		// 		{
		// 			DebugLogUIText.text = "Bat_Green Hit!!";
		// 			Debug.Log(raycastHit.collider.name + " Hit!");
		// 		}

		// 		//OR with Tag

		// 		if (raycastHit.collider.CompareTag("Enemy"))
		// 		{
		// 			DebugLogUIText.text = "Tagged Enemy Hit!!";
		// 			Debug.Log("Tagged Enemy Hit!!");
		// 			Destroy(raycastHit.collider.gameObject);	
		// 		}
		// 	}
		// }
	}
}
