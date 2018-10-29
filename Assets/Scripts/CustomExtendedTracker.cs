using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CustomExtendedTracker : MonoBehaviour {
	public GameObject TheGame;
	public Button activeBtn;
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		TheGame.SetActive(false);
		activeBtn.enabled = true;
	
	}
	public void SummonTheGame(){

		TheGame.SetActive(true);
		Debug.Log("TheGame is ON!");

		DisableOtherGO();
	}

	private void DisableOtherGO()
	{
		activeBtn.enabled = false;
	}
}
