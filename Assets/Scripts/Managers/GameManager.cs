using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	private float InvulnDelay = 3f;
	private float timeRemaining;
    private float maxTime = 5 * 60;
	private int playerHealth;
	private int turretsRemaining;
	private int maxHealth = 10;
	private bool isInvulnerable = false;
    private bool hasSave = false;
    private bool winCondition;
    private bool loseCondition;

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

    public bool HasSave
    {
        get
        {
            return hasSave;
        }
        set
        {
            hasSave = value;
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
		TimeRemaining = maxTime;
		PlayerHealth = maxHealth;
	}

    void Start()
    {
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
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