using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
	public	static GameCamera	Instance;

	public 	bool 				isShaking;

	public 	float 				shakeTimer;
	public 	float 				shakeDuration;
	public 	float 				shakeFrequency;
	public 	float 				shakeBounds;

	public 	Vector2 			shakeStartDir;
	public 	Vector3 			shakeOffset 	= Vector3.zero;

	public	Vector3				initialPosition;

	public	Transform			tr;
	
	void Awake ()
	{
		Instance 				= this;
		
		this.tr 				= this.GetComponent<Transform>();

		this.initialPosition 	= this.tr.position;
	}
	
	void LateUpdate ()
	{
		// SHAKING
		if ( this.isShaking )
		{
			this.shakeTimer 		+= Time.deltaTime;
			if ( this.shakeTimer > this.shakeDuration )
			{
				this.isShaking      = false;
				this.shakeOffset    = Vector3.zero;
			}
			else
			{
				float __t			= this.shakeTimer / this.shakeDuration;
				float __freq		= Mathf.Lerp ( this.shakeFrequency, 4f * this.shakeFrequency, __t );
				Vector2 __v			= new Vector2 ( Mathf.Lerp ( this.shakeBounds, 0f, __t ) * Mathf.Sin ( this.shakeTimer * __freq ), Mathf.Lerp ( this.shakeBounds, 0f, __t ) * Mathf.Sin ( ( this.shakeTimer * __freq ) * 2f ) );
				this.shakeOffset	= new Vector3 ( __v.x * this.shakeStartDir.x, __v.y * this.shakeStartDir.y, 0f );
			}

			this.tr.position 		= new Vector3 ( this.initialPosition.x + this.shakeOffset.x, this.initialPosition.y + this.shakeOffset.y, this.initialPosition.z );
		}
	}

	public void Shake ( float _frequency, float _bounds, float _duration )
	{
		this.isShaking		= true;
		this.shakeTimer		= 0f;
		this.shakeDuration	= _duration;
		this.shakeBounds	= _bounds;
		this.shakeFrequency	= _frequency;
		this.shakeStartDir	= new Vector2 ( 0.2f, 1f );
	}
}
