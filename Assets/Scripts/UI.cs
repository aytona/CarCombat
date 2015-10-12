using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text Timer;
    public Text TurretCounter;
    public Text PlayerHealth;

    void Update()
    {
        Timer.text = FormatTime(GameManager.Instance.TimeRemaining);
        TurretCounter.text = GameManager.Instance.TurretsRemaining.ToString();
        PlayerHealth.text = GameManager.Instance.PlayerHealth.ToString();
    }

    private string FormatTime(float timeinSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeinSeconds / 60), Mathf.FloorToInt(timeinSeconds % 60));
    }
}
