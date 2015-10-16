using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.CircularPongStarterKit.Scripts;

public class MenuLogic2d : MonoBehaviour
{
	public	static MenuLogic2d	Instance;

	// MENU
	public	GameObject			menuPanel;

	// GAME
	public	GameObject			gamePanel;
	public	Text				gameCurrentScore;

	// GAME OVER
	public	GameObject			gameOverPanel;
	public	Text				gameOverCurrentScore;
	public	Text				gameOverBestScore;

    //PAUSE

    public GameObject pausePanel;
    public Text pauseCurrentScore;

    //SETTINGS

    public GameObject settingsPanel;

	void Awake ()
	{
		Instance = this;
	}

    	void Update ()
	{
        if ((Input.GetKeyDown(KeyCode.Escape)) || (Input.GetKeyDown(KeyCode.Backspace)))
	    {
	        OnBackPressed();
	    }
	}

    public void OnBackPressed()
    {
        if (menuPanel.activeSelf)
        {
            Application.Quit();
        }
        else if (gamePanel.activeSelf && !settingsPanel.activeSelf && !gameOverPanel.activeSelf && !pausePanel.activeSelf)
        {
            MenuShow();
        }
    }


	public void MenuShow ()
	{
        Time.timeScale = 0;
		this.gamePanel.SetActive	 ( false );
		this.gameOverPanel.SetActive ( false );
		this.menuPanel.SetActive 	 ( true  );
        this.pausePanel.SetActive(false);
        this.settingsPanel.SetActive(false);

	}

	public void GameShow ()
	{
        Time.timeScale = 1;
		this.menuPanel.SetActive 	 ( false );
		this.gameOverPanel.SetActive ( false );
		this.gamePanel.SetActive  	 ( true  );
        this.pausePanel.SetActive(false);
        this.settingsPanel.SetActive(false);

		this.GameUpdate ();
	}

	public void GameUpdate ()
	{
		this.gameCurrentScore.text = GameLogic2d.Instance.GetCurrentScore ().ToString ();
	}

	public void GameOverShow ()
	{
        Time.timeScale = 0;
		this.gamePanel.SetActive 	 ( true );
		this.menuPanel.SetActive  	 ( false );
		this.gameOverPanel.SetActive ( true  );
        this.pausePanel.SetActive(false);
        this.settingsPanel.SetActive(false);

		this.GameOverUpdate ();
	}

	void GameOverUpdate ()
	{
		this.gameOverCurrentScore.text 	= GameLogic2d.Instance.GetCurrentScore ().ToString ();
		this.gameOverBestScore.text 	= GameLogic2d.Instance.GetBestScore    ().ToString ();
	}


    void PauseUpdate()
    {
        this.pauseCurrentScore.text = GameLogic2d.Instance.GetCurrentScore().ToString();
    }
	public void PressMenuButtonPlay ()
	{
		MusicManager.Instance.PlayMenuButtonPressed ();

		GameLogic2d.Instance.GameStart ();
	}
	
	public void PressGameOverButtonRestart ()
	{
		MusicManager.Instance.PlayMenuButtonPressed ();

		GameLogic2d.Instance.GameRestart ();
	}

    public void PressPauseButton()
    {
        Time.timeScale = 0;
        this.gamePanel.SetActive(true);
        this.menuPanel.SetActive(false);
        this.gameOverPanel.SetActive(false);
        this.pausePanel.SetActive(true);
        this.settingsPanel.SetActive(false);

        this.PauseUpdate();
    }

    public void PressResumeButton()
    {
        Time.timeScale = 1;
        this.GameShow();
    }

    public void PressMenuButton()
    {
        Time.timeScale = 0;
        this.gamePanel.SetActive(false);
        this.menuPanel.SetActive(true);
        this.gameOverPanel.SetActive(false);
        this.pausePanel.SetActive(false);
        this.settingsPanel.SetActive(false);
    }

    public void PressMenuSettingsButton()
    {
        Time.timeScale = 0;

        this.gamePanel.SetActive(false);
        this.menuPanel.SetActive(true);
        this.gameOverPanel.SetActive(false);
        this.pausePanel.SetActive(false);
        this.settingsPanel.SetActive(true);
    }

    public void PressGameSettingsButton()
    {
        Time.timeScale = 0;
        this.settingsPanel.SetActive(true);
    }

    public void PressExitSettingsButton()
    {
        Time.timeScale = 0;
        this.settingsPanel.SetActive(false);

        if (gamePanel.active)
        {
            Time.timeScale = 1;
        }
    }


    public void MusicToogleChanged(bool isChecked )
    {
            MusicManager.Instance.IsMusic = isChecked;
            //Debug.Log("Checked"+isChecked);
       
    }

    public void SoundToogleChanged(bool isChecked)
    {
       
            MusicManager.Instance.IsSound = isChecked;
            Debug.Log("IsSoundChecked" + isChecked);
 
    }

    public void PressShareButton()
    {
        FBHelper.Feed();
    }

}
