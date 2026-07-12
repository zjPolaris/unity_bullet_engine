using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class projectiles : MonoBehaviour
{
    public float LifeTime=5f;
    public projectilepool pool;
    public float LinearVelocity=0;
    public float Acceleration=0;
    public float AngularVelocity=0;
    public float AngularAcceleration=0;
    public float MaxVelocity=int.MaxValue;

    private void FixedUpdate()
    {
        LinearVelocity = Mathf.Clamp(LinearVelocity+Acceleration*Time.fixedDeltaTime,-MaxVelocity,MaxVelocity);
        AngularVelocity += AngularAcceleration*Time.fixedDeltaTime;
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,1)*AngularVelocity*Time.fixedDeltaTime);
        transform.Translate(LinearVelocity*Vector2.right*Time.fixedDeltaTime,Space.Self);
        LifeTime -= Time.fixedDeltaTime;
        if(LifeTime<=0){
            pool.ReleaseItem(this);
        }
    }
}