using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public	static MusicManager		Instance;

	[Tooltip("Audio When Pressing Button")]
	public	AudioClip				audioClipMenuButton;
	[Tooltip("Audio Source Used When Pressing Button")]
	public	AudioSource				audioSourceMenu;

	[Tooltip("Audio When Ball Hits Paddle")]
	public	AudioClip				audioClipGameBallHitPaddle;
	[Tooltip("Audio When Game Is Over")]
	public	AudioClip				audioClipGameOver;
	[Tooltip("Audio Source for Game Events")]
	public	AudioSource				audioSourceGame;

	void Awake ()
	{
		Instance = this;
	}
	
	public void PlayMenuButtonPressed ()
	{
		this.audioSourceMenu.clip = this.audioClipMenuButton;
		this.audioSourceMenu.loop = false;
		this.audioSourceMenu.Play ();
	}

	public void PlayGameBallHitPaddle ()
	{
		this.audioSourceGame.clip = this.audioClipGameBallHitPaddle;
		this.audioSourceGame.loop = false;
		this.audioSourceGame.Play ();
	}
	
	public void PlayGameBallOver ()
	{
		this.audioSourceGame.clip = this.audioClipGameOver;
		this.audioSourceGame.loop = false;
		this.audioSourceGame.Play ();
	}
}
