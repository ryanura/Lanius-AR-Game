using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {
	private float thunderCooldown;
	private float fortifyCooldown;
	private bool thunderisOnCD = false;
	private bool fortifyisOnCD = false;
	private float fortifDuration = 4.5f;
	private float stunDuration = 15f;

	public AudioClip[] AudioClips;
	AudioSource audioSource;
	public GameObject ThunderEffect;
	public GameObject FortifyEffect;

	public Button ThunderSkillBtn;
	public Button FortifySkillBtn;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void DoFortiyFortress()
	{
		StartCoroutine("FortiyFortress");
	}

	public IEnumerator FortiyFortress ()
	{
		Debug.Log ("FORTIFIED");
		PlayTheClip ("Shield of Protection");
		GameObject effect = (GameObject)Instantiate(FortifyEffect, this.transform.TransformPoint(0,12,0), Quaternion.Euler(90, 0, 0));
		Destroy(effect, 4.5f);
		
		if (PlayerStats.IsFortified == false){
			PlayerStats.IsFortified = true;
		}

		yield return new WaitForSeconds (fortifDuration);
		
		PlayerStats.IsFortified = false;
	}

	public void DoThunderStrike(){
		StartCoroutine("ThunderStrikeSequence");
		
		//ThunderSkillBtn.interactable = false;
		thunderCooldown = 15f;
		thunderisOnCD = true;
		//InvokeRepeating ("CountdownTimer", 1, 1);
	}

	IEnumerator ThunderStrikeSequence ()
	{
		
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		if (Enemies.Length <= 0 || Enemies == null){
			yield break;
		}

		foreach (GameObject ene in Enemies)
		{
			Debug.Log("THUNDER STRIKE " + Enemies.Length);

			//ene.GetComponent<Enemy>().Slowed(.99f);
			PlayTheClip("Thunder_short");
			GameObject effect = (GameObject)Instantiate(ThunderEffect, ene.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			Destroy(effect, 2f);
			//Destroy(ene.gameObject);
			ene.GetComponent<Enemy>().TakeDamage(1);
		}
		
		yield return new WaitForSeconds (1f);
	}
	void CountdownTimer(){
		if (thunderisOnCD && thunderCooldown >= 0)
		{
			thunderCooldown--;
		}else{
			ThunderSkillBtn.interactable = true;
		}

		if (fortifyisOnCD && fortifyCooldown >= 0)
		{
			fortifyCooldown--;
		}else{
			FortifySkillBtn.interactable = true;
		}
	}

	public void PlayTheClip(string _clipName)
	{
		foreach (AudioClip clip in AudioClips){
			if (clip.name == _clipName)
			{
				audioSource.PlayOneShot(clip);
			}
		}
	}
}
