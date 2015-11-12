using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UI : Singleton<UI> {

    public Text Timer;
    public Text TurretCounter;
    public Text PlayerHealth;
    public Text Mute;
    public Text Saved;
    public Text Loaded;

    private SoundManager soundManager;
    private GameObject PauseMenu;
    private GameObject SaveButton;
    private GameObject LoadButton;
    private GameObject Player;
    private bool paused;
    private bool muted;

    void Start()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameManager.Instance.TurretsRemaining = turrets.Length;
        paused = false;
        soundManager = FindObjectOfType<SoundManager>();
        PauseMenu = GameObject.Find("PauseMenu");
        SaveButton = GameObject.Find("Save");
        LoadButton = GameObject.Find("Load");
        Player = GameObject.Find("Player");
        if (!GameManager.Instance.HasSave)
        {
            LoadButton.GetComponent<Button>().interactable = false;
            Loaded.text = "No Saved Scene";
        }
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
            Cursor.visible = true;
        }
        else if(!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Saved.text = "Save";
            SaveButton.GetComponent<Button>().interactable = true;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        paused = false;
        soundManager.PlayClickClip();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
        soundManager.PlayClickClip();
    }

    public void Muted()
    {
        muted = !muted;
        soundManager.PlayClickClip();
    }

    public void Quit()
    {
        Application.Quit();
        soundManager.PlayClickClip();
    }

    public void Unstuck()
    {
        Player.transform.position = new Vector3(0f, -0.45f, 0f);
        soundManager.PlayClickClip();
    }

    // Save Game Test
    public void Save()
    {
        PlayerPrefs.SetInt("CurrentSceneSave", Application.loadedLevel);
        Saved.text = "Saved";
        SaveButton.GetComponent<Button>().interactable = false;
        LoadButton.GetComponent<Button>().interactable = true;
        Loaded.text = "Load";
        GameManager.Instance.HasSave = true;
        soundManager.PlayClickClip();
    }

    public void Load()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("CurrentSaveScene"));
        soundManager.PlayClickClip();
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