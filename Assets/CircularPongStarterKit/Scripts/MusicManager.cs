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

    public AudioSource backgroundMusic;

	void Awake ()
	{
		Instance = this;
	    IsSound = true;
	}
	
	public void PlayMenuButtonPressed ()
	{
	    if (IsSound)
	    {
	        this.audioSourceMenu.clip = this.audioClipMenuButton;
	        this.audioSourceMenu.loop = false;
	        this.audioSourceMenu.Play();
	    }
	}

	public void PlayGameBallHitPaddle ()
	{
	   if (IsSound)
	    {
	        this.audioSourceGame.clip = this.audioClipGameBallHitPaddle;
	        this.audioSourceGame.loop = false;
	        this.audioSourceGame.Play();
	    }
	}
	
	public void PlayGameBallOver ()
	{
	    if (IsSound)
	    {
	        this.audioSourceGame.clip = this.audioClipGameOver;
	        this.audioSourceGame.loop = false;
	        this.audioSourceGame.Play();
	    }
	}

   private bool _isMusic;
    public bool IsMusic
    {
        get
        {
            return _isMusic;
        }
        set
        {
            //Debug.Log(value);
            _isMusic = value;
            if (_isMusic)
            {
                backgroundMusic.Play();
            }
            else
            {
                backgroundMusic.Pause();
            }
        }
    }

    public bool IsSound { get; set; }
}
