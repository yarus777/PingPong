using UnityEngine;
using System.Collections;

public class EyesBehavior : MonoBehaviour {

    public Transform target;
    

	void Update ()
	{
	    Vector3 dir = target.position - transform.position;
	    float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.LookAt(target);

	}
}
