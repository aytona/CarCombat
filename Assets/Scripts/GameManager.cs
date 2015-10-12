﻿using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	public float InvulnDelay;

	private float timeRemaining;
	private int playerHealth;
	private int turretsRemaining;
	private int maxHealth = 10;
	private bool isInvulnerable = false;

	public float TimeRemaining
	{
		get
		{
			return timeRemaining;
		}
		set
		{
			timeRemaining = value;
		}
	}

	public int TurretsRemaining
	{
		get
		{
			return turretsRemaining;
		}
		set
		{
			turretsRemaining = value;
		}
	}

	public int PlayerHealth
	{
		get
		{
			return playerHealth;
		}
		set
		{
			playerHealth = value;
		}
	}

	private void DecrementPlayerHealth(GameObject player)
	{
		if (isInvulnerable)
			return;
		StartCoroutine(InvulnerableDelay(InvulnDelay));
		PlayerHealth--;
		// TODO: Destroy player when health runs out
		if (PlayerHealth <= 0)
			Restart();
	}

	private void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
		TimeRemaining = 60 * 5;
		PlayerHealth = maxHealth;
	}

	void OnEnable()
	{

	}

	void OnDisable()
	{

	}

	void Update()
	{
		TimeRemaining -= Time.deltaTime;
		// TODO: Destroy player when time runs out
		if (TimeRemaining <= 0)
			Restart();
	}
	
	private IEnumerator InvulnerableDelay(float InvulnDelay)
	{
		isInvulnerable = true;
		yield return new WaitForSeconds(InvulnDelay);
		isInvulnerable = false;
	}
}