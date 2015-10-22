using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuCanvas : MonoBehaviour {

    public Text StartText;
    public GameObject HowTo;
    public GameObject MainMenu;
    public GameObject Continue;

    private bool hasSave;

    void Start()
    {
        hasSave = false;
        if (PlayerPrefs.GetInt("CurrentSceneSave") != 0)
            hasSave = true;
        if (hasSave)
            Continue.SetActive(true);
    }

    void Update()
    {
        if (hasSave)
            StartText.text = "Start New Game";

    }

    // Button functions
    public void doStart()
    {
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