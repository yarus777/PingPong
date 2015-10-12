using UnityEngine;
using System.Collections;

public class PaddlePivot2d : MonoBehaviour
{
	public	static PaddlePivot2d	Instance;

	public	float					rotateDirection;			// ROTATION DIRECTION

	public	float					rotateSpeed			= 5f;	// ROTATION SPEED

	public	Transform				tr;							// CACHED TRANSFORM
	
	void Awake ()
	{
		Instance 	= this;
		
		this.tr 	= this.GetComponent<Transform>();
	}

	void FixedUpdate ()
	{
		if ( this.rotateDirection > 0f )
		{
			this.tr.Rotate ( Vector3.forward, -this.rotateSpeed * GameLogic2d.Instance.gameSpeed * Time.deltaTime );
		}
		else if ( this.rotateDirection < 0f )
		{
			this.tr.Rotate ( Vector3.forward,  this.rotateSpeed * GameLogic2d.Instance.gameSpeed * Time.deltaTime );
		}
	}

	public void OnGameStart ()
	{
		this.tr.rotation 		= Quaternion.identity;

		this.rotateDirection 	= 1f;
	}

	public void OnGameOver ()
	{
		this.rotateDirection 	= 0f;
	}

	public void ChangeDirection ()
	{
		this.rotateDirection 	*= -1f;
	}
}
