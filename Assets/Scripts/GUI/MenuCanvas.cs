using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuCanvas : MonoBehaviour {

    public Text StartText;
    public GameObject HowTo;
    public GameObject MainMenu;
    public GameObject Continue;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
        soundManager.PlayClickClip();
        PlayerPrefs.SetInt("CurrentSceneSave", 0);
        Application.LoadLevel(1);
    }

    public void doHowTo()
    {
        soundManager.PlayClickClip();
        MainMenu.SetActive(false);
        HowTo.SetActive(true);
    }

    public void doQuit()
    {
        soundManager.PlayClickClip();
        Application.Quit();
    }

    public void doMenu()
    {
        soundManager.PlayClickClip();
        MainMenu.SetActive(true);
        HowTo.SetActive(false);
    }

    public void doContinue()
    {
        soundManager.PlayClickClip();
        Application.LoadLevel(PlayerPrefs.GetInt("CurrentSceneSave"));
    }
}