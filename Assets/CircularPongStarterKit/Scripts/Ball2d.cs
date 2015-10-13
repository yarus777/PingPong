using UnityEngine;
using System.Collections;

public class Ball2d : MonoBehaviour
{
	public	static Ball2d		Instance;

	[Tooltip("SPEED OF THE BALL WHEN GAME STARTS")]
	public	float				speedOnStart 		= 100f;		// SPEED ON GAME START

	public	Animation			spriteAnimation;

	private	bool				isAlive;						// IS PLAYER ALIVE

	private	bool				canMove;						// CAN IT MOVE

	[SerializeField]
	private	float				ballSpeed;						// CURRENT SPEED

	private float           	lastTimeHitPaddle;				// STORE LAST TIME THE BALL HITS PADDLE

	private Vector2         	moveDirection;					// DIRECTION

	private	Transform			tr;								// CACHED TRANSFORM

	private	Rigidbody2D			rb;								// CACHED RIGIDBODY 2D

	private	CircleCollider2D	cc;								// CACHED CIRCLE COLLIDER 2D

	void Awake ()
	{
		Instance 	= this;

		this.tr 	= this.GetComponent<Transform>();

		this.rb 	= this.GetComponent<Rigidbody2D>();

		this.cc		= this.GetComponent<CircleCollider2D>();
	}
	
	void FixedUpdate ()
	{
		if ( this.canMove == true )
		{
			// KEEP THE SPEED OF THE BALL
			this.rb.velocity   = this.moveDirection * this.ballSpeed * GameLogic2d.Instance.gameSpeed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter2D ( Collider2D __c )
	{
		if ( this.isAlive == true )
		{
			// BALL HITS PADDLE
			if ( __c.CompareTag ( "PADDLE" ) )
			{
				if ( ( Time.time - this.lastTimeHitPaddle ) > 0.1f )
				{
					// CHANGE DIRECTION TOWARD CENTER OF THE CIRCLE WITH AN ADDITIONAL RANDOM ANGLES
					this.moveDirection 	= Vector3.Reflect ( this.moveDirection, Vector3.zero - this.tr.position );
					this.moveDirection	= Quaternion.Euler ( 0f, 0f, Random.Range ( 0f, 45f ) ) * this.moveDirection;
					this.moveDirection.Normalize();

					// UPDATE SCORE
					GameLogic2d.Instance.AddScore ( 1 );

					this.spriteAnimation.Play ( "BallHit" );

					MusicManager.Instance.PlayGameBallHitPaddle ();
				}
				
				this.lastTimeHitPaddle = Time.time;
			}
		}
	}

	void OnTriggerExit2D ( Collider2D __c )
	{
		// GAME IS OVER IF THE BALL EXITS CIRCLE
		if ( __c.CompareTag ( "INSIDECIRCLE" ) )
		{
			this.GameOver ();
		}
	}

	// CALL WHEN GAME STARTS
	public void OnGameStart ()
	{
		// PLACE THE BALL IN CENTER OF THE CIRCLE
        this.tr.position = new Vector3(0.2f, 0, 0);

		// THE BALL WILL MOVE IN UP DIRECTION AT START
		this.moveDirection		= Vector2.up;

		this.lastTimeHitPaddle	= Time.time;

		// INITIAL MOVING SPEED
		this.ballSpeed			= this.speedOnStart;

		// 
		this.isAlive			= true;
		this.canMove			= true;
	}

	void GameOver ()
	{
		if ( this.isAlive == true )
		{
			this.isAlive 		= false;

			// GAMELOGIC2D HANDLES GAME OVER
			GameLogic2d.Instance.GameOver ();

			MusicManager.Instance.PlayGameBallOver ();
		}
	}
}
