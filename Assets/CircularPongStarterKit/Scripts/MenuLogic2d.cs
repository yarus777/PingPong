using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogic2d : MonoBehaviour
{
	public	static MenuLogic2d	Instance;

	// MENU
	public	GameObject			menuPanel;
	public	Text				menuBestScore;

	// GAME
	public	GameObject			gamePanel;
	public	Text				gameCurrentScore;

	// GAME OVER
	public	GameObject			gameOverPanel;
	public	Text				gameOverCurrentScore;
	public	Text				gameOverBestScore;

	void Awake ()
	{
		Instance = this;
	}

	public void MenuShow ()
	{
		this.gamePanel.SetActive	 ( false );
		this.gameOverPanel.SetActive ( false );
		this.menuPanel.SetActive 	 ( true  );

		this.menuBestScore.text = GameLogic2d.Instance.GetBestScore ().ToString ();
	}

	public void GameShow ()
	{
		this.menuPanel.SetActive 	 ( false );
		this.gameOverPanel.SetActive ( false );
		this.gamePanel.SetActive  	 ( true  );

		this.GameUpdate ();
	}

	public void GameUpdate ()
	{
		this.gameCurrentScore.text = GameLogic2d.Instance.GetCurrentScore ().ToString ();
	}

	public void GameOverShow ()
	{
		this.gamePanel.SetActive 	 ( false );
		this.menuPanel.SetActive  	 ( false );
		this.gameOverPanel.SetActive ( true  );

		this.GameOverUpdate ();
	}

	void GameOverUpdate ()
	{
		this.gameOverCurrentScore.text 	= GameLogic2d.Instance.GetCurrentScore ().ToString ();
		this.gameOverBestScore.text 	= GameLogic2d.Instance.GetBestScore    ().ToString ();
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
}
