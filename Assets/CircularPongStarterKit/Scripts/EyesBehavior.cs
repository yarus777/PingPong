using UnityEngine;
using System.Collections;

public class EyesBehavior : MonoBehaviour {

    public Transform Target;

    public Transform[] Observers;


    void Update()
    {
        Vector2 dir = Target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.LookAt(target);
        for (var i = 0; i < Observers.Length; i++)
        {
            Observers[i].rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
