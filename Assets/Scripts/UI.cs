using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : Singleton<UI> {

    public Text Timer;
    public Text TurretCounter;
    public Text PlayerHealth;
    public Text Mute;
    public Text Saved;

    private GameObject PauseMenu;
    private GameObject SaveButton;
    private GameObject LoadButton;
    private bool paused;
    private bool muted;

    void Start()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameManager.Instance.TurretsRemaining = turrets.Length;
        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");
        SaveButton = GameObject.Find("Save");
        LoadButton = GameObject.Find("Load");
    }

    void Update()
    {
        Timer.text = FormatTime(GameManager.Instance.TimeRemaining);
        TurretCounter.text = "Turrets: " + GameManager.Instance.TurretsRemaining.ToString();
        PlayerHealth.text = "Health: " + GameManager.Instance.PlayerHealth.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;
        
        if (muted)
        {
            AudioListener.volume = 0;
            Mute.text = "Unmute";
        }
        else if (!muted)
        {
            AudioListener.volume = 1;
            Mute.text = "Mute";
        }

        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            if (PlayerPrefs.GetInt("CurrentSaveScene") == 0)
                LoadButton.GetComponent<Button>().interactable = false;
            else if (PlayerPrefs.GetInt("CurrentSaveScene") != 0)
                LoadButton.GetComponent<Button>().interactable = true;
        }
        else if(!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Saved.text = "Save";
            SaveButton.GetComponent<Button>().interactable = true;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Muted()
    {
        muted = !muted;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Save Game Test
    public void Save()
    {
        PlayerPrefs.SetInt("CurrentSceneSave", Application.loadedLevel);
        Saved.text = "Saved";
        SaveButton.GetComponent<Button>().interactable = false;
    }

    public void Load()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("CurrentSceneSave"));
    }

    private string FormatTime(float timeinSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeinSeconds / 60), Mathf.FloorToInt(timeinSeconds % 60));
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
            Destroy(this.gameObject);
    }

}