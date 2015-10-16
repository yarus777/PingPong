using UnityEngine;
using System.Collections;

public class DebugADSKD : MonoBehaviour {

	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}

#if UNITY_ANDROID && !UNITY_EDITOR
	void OnApplicationPause(bool pauseStatus) {
		if(pauseStatus)
		{
			AdSDK.StartDebug();
		}
		else
		{
			AdSDK.StopDebug();
		}
	}
#endif

}
