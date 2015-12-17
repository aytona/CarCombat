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
    private GameObject player;

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

    public bool WinCondition
    {
        get { return winCondition; }
        set { winCondition = value; }
    }

    public bool LoseCondition
    {
        get { return loseCondition; }
        set { loseCondition = value; }
    }

	private void DecrementPlayerHealth(GameObject player)
	{
		if (isInvulnerable)
			return;
		StartCoroutine(InvulnerableDelay(InvulnDelay));
		PlayerHealth--;
		// TODO: Destroy player when health runs out
        if (PlayerHealth <= 0)
            playerDead();
	}

    //private void Restart()
    //{
    //    TimeRemaining = maxTime;
    //    PlayerHealth = maxHealth;
    //}

    private void playerDead()
    {
        loseCondition = true;
        Destroy(player);
    }

    private void playerWin()
    {
        winCondition = true;
    }

    void Start()
    {
        TimeRemaining = maxTime;
        PlayerHealth = maxHealth;
        player = GameObject.Find("Player");
    }

	void Update()
	{
		TimeRemaining -= Time.deltaTime;
        if (TimeRemaining <= 0)
            playerDead();
        if (turretsRemaining <= 0)
            playerWin();
	}

    void OnLevelLoaded(int level)
    {
        if (level == 0)
        {
            loseCondition = false;
            winCondition = false;
        }
    }
	
	private IEnumerator InvulnerableDelay(float InvulnDelay)
	{
		isInvulnerable = true;
		yield return new WaitForSeconds(InvulnDelay);
		isInvulnerable = false;
	}
}