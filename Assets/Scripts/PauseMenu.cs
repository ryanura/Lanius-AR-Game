using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;
	TheGameManager gameManager;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		gameManager = GetComponent<TheGameManager>();
		Time.timeScale = 0f;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			gameManager.ToggleBGM(false);
			Time.timeScale = 0f;
		} else
		{
			gameManager.ToggleBGM(true);
			Time.timeScale = 1f;
		}
	} 
}
