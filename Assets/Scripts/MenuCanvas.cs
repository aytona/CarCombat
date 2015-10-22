using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuCanvas : MonoBehaviour {

    public Text StartText;
    public GameObject HowTo;
    public GameObject MainMenu;
    public GameObject Continue;

    void Start()
    {
        if (PlayerPrefs.GetInt("CurrentSceneSave") != 0)
            GameManager.Instance.HasSave = true;
        if (GameManager.Instance.HasSave)
            Continue.SetActive(true);
    }

    void Update()
    {
        if (GameManager.Instance.HasSave)
            StartText.text = "Start New Game";
    }

    // Button functions
    public void doStart()
    {
        PlayerPrefs.SetInt("CurrentSceneSave", 0);
        Application.LoadLevel(1);
    }

    public void doHowTo()
    {
        MainMenu.SetActive(false);
        HowTo.SetActive(true);
    }

    public void doQuit()
    {
        Application.Quit();
    }

    public void doMenu()
    {
        MainMenu.SetActive(true);
        HowTo.SetActive(false);
    }

    public void doContinue()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("CurrentSceneSave"));
    }
}