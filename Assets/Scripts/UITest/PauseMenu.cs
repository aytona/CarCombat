using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private GameObject PauseMenuObject;
    private bool paused;
    private bool muted;

    [SerializeField]
    private Text muteText = null;

	// Use this for initialization
	void Start () {
        paused = false;
        PauseMenuObject = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
            paused = !paused;

        if (paused)
        {
            PauseMenuObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(!paused)
        {
            PauseMenuObject.SetActive(false);
            Time.timeScale = 1;
        }

        if (muted)
        {
            AudioListener.volume = 0;
            muteText.text = "Unmute";
        }
        else if (!muted)
        {
            AudioListener.volume = 1;
            muteText.text = "Mute";
        }
	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(2);
    }

    // Save current scene
    public void Save()
    {
        PlayerPrefs.SetInt("currentSceneSave", Application.loadedLevel);
    }

    public void Load()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("currentSceneSave"));
    }

    public void Mute()
    {
        muted = !muted;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
