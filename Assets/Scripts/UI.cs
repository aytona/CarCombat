using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : Singleton<UI> {

    public Text Timer;
    public Text TurretCounter;
    public Text PlayerHealth;

    void Start()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameManager.Instance.TurretsRemaining = turrets.Length;
    }

    void Update()
    {
        Timer.text = FormatTime(GameManager.Instance.TimeRemaining);
        TurretCounter.text = "Turrets: " + GameManager.Instance.TurretsRemaining.ToString();
        PlayerHealth.text = "Health: " + GameManager.Instance.PlayerHealth.ToString();
    }

    private string FormatTime(float timeinSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeinSeconds / 60), Mathf.FloorToInt(timeinSeconds % 60));
    }
}