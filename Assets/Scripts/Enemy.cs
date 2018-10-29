using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour {

	public float StartSpeed = 3f;
	public float Speed;
	public int StartHealth = 100;
	private int curHealth;
	public int Attack;
	public int KillPoint;
	public AudioClip[] AudioClips;
	public TMP_Text healthBarText;
	public GameObject deathEffect;
	public GameObject attackEffect;

	private Animator anim;
	private AudioSource audioSource;
	private EnemyMovement enemyMovement;
	private bool isDead;


	// Use this for initialization
	void Start () {
		Speed = StartSpeed;
		curHealth = StartHealth;
		isDead = false;

		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		healthBarText = GetComponentInChildren<TMP_Text>();
		enemyMovement = GetComponent<EnemyMovement>();
	}

	public int CurrentHealthBar()
	{
		return healthBarText.text.Length;
	}

	public void DecreaseHealthBar(int _amount)
	{
		if (CurrentHealthBar() >= 0)
		{
			healthBarText.text = healthBarText.text.Remove(healthBarText.text.Length - _amount);

		}
	}
	public void TakeDamage (int _amount) {
		curHealth -= _amount;
		DecreaseHealthBar(_amount);
		
		StartCoroutine("TakeDamagePhase"); //Do some Damaged Stuff
		
		if (curHealth <= 0 && !isDead)
		{
			Die();
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

	IEnumerator TakeDamagePhase()
	{
		anim.SetTrigger("TookDamage");
		PlayTheClip("Punch");
		//GameObject effect = (GameObject)Instantiate(attackEffect, transform.position, Quaternion.identity);
		//Destroy(effect, 1F);
		
		Slowed (.7f);
		yield return new WaitForSeconds (.3f);
		Slowed(0f);
		yield return 0;
	}

	public void DoDamage () {
		if (PlayerStats.IsFortified == true){
			return;
		}

		PlayerStats.CurPHealth -= Attack;
		Debug.Log(PlayerStats.CurPHealth + " PlayerStats");
		//do attack Animation
		anim.SetTrigger("Attack");
		//play attack sound
		PlayTheClip("Attack");
		//audioSource.Play();
	}

	public void Slowed(float _slowSpeed)
	{
		Speed = StartSpeed * (1f - _slowSpeed);

		enemyMovement.UpdateEnemy();
	}

	IEnumerator DeathPhase()
	{
		enemyMovement.StopNavMesh();
		//Slowed(0.99f);
		anim.SetTrigger("Death"); //dead Animation
		PlayTheClip("Bats #1");//play dead hymne
		
		yield return new WaitForSeconds (1.8f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

	private IEnumerator WaitForAnimation ( Animation animation )
	{
		do
		{
			yield return null;
		} 
		while ( animation.isPlaying );
	}

	void Die()
	{	
		isDead= true;

		PlayerStats.Score += KillPoint;

		StartCoroutine("DeathPhase");
		
		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

	}

	public void OnMouseDown()
	{
		if (isDead) return;
		this.TakeDamage(1);
	}
}
