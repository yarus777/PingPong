using UnityEngine;
using System.Collections;

public class GameLogic2d : MonoBehaviour
{
	public	static GameLogic2d		Instance;

	public	enum STATE
	{
		Menu,
		Game,
		GameOver
	}
	public	STATE					state;

	public	float					initialGameSpeed	= 1f;
	public	float					gameIncrementSpeed	= 0.01f;
	public	float					gameSpeed;

	[Tooltip("This Is The Score When Game Is Playing")]
	private	int						currentScore;

	void Awake ()
	{
		Instance					= this;

		Application.targetFrameRate = 60;
	}

	void Start ()
	{
		this.state = STATE.Menu;

		// SHOW START MENU
		MenuLogic2d.Instance.MenuShow ();
	}

	void Update ()
	{
		this.HandlePlayerInput ();
	}

	#region PLAYER INPUT

	void HandlePlayerInput ()
	{
		// CHECK IF PLAYER IS PRESSING LEFT SIDE OR RIGHT SIDE OF THE SCREEN
		
		// EDITOR DEBUGGING
		#if UNITY_EDITOR
		if ( Input.GetKeyDown ( KeyCode.Space ) )
		{
			if ( this.state == STATE.Menu )
			{
				MenuLogic2d.Instance.PressMenuButtonPlay ();
			}
			else if ( this.state == STATE.GameOver )
			{
				MenuLogic2d.Instance.PressGameOverButtonRestart ();
			}
		}
		if ( Input.GetKeyDown ( KeyCode.O ) )
		{
			this.GameOver ();
		}
		if ( Input.GetKeyDown ( KeyCode.R ) )
		{
			PlayerPrefs.DeleteAll ();
		}
		#endif
		
		// GAME IS RUNNING
		if ( this.state == STATE.Game )
		{
			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				PaddlePivot2d.Instance.ChangeDirection ();
			}
		}
	}
	#endregion

	#region GAME LOGIC

	public void GameStart ()
	{
		this.currentScore 	= 0;

		this.gameSpeed		= this.initialGameSpeed;

		MenuLogic2d.Instance.GameShow ();

		PaddlePivot2d.Instance.OnGameStart ();

		Ball2d.Instance.OnGameStart ();

		this.state = STATE.Game;
	}

	public void GameRestart ()
	{
		this.GameStart ();
	}

	#endregion

	public void GameOver ()
	{
		int __bestScore = this.GetBestScore ();
		if ( this.currentScore > __bestScore )
		{
			this.SaveBestScore ( this.currentScore );
		}

		MenuLogic2d.Instance.GameOverShow ();

		PaddlePivot2d.Instance.OnGameOver ();

		this.state = STATE.GameOver;
	}

	#region SCORE

	public int GetCurrentScore ()
	{
		return this.currentScore;
	}
	
	public void AddScore ( int __score )
	{
		this.gameSpeed		+= this.gameIncrementSpeed;

		this.currentScore 	+= __score;
		
		// UPDATE SCORE IN HUD
		MenuLogic2d.Instance.GameUpdate (); 
	}

	public int GetBestScore ()
	{
		return PlayerPrefs.GetInt ( "BESTSCORE", 0 );
	}
	
	public void SaveBestScore ( int __score )
	{
		PlayerPrefs.SetInt ( "BESTSCORE", __score );
	}

	#endregion
}
