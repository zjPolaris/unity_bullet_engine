using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "create projectile")]
public class projectileobject : ScriptableObject
{
    public int ID=0;
    [Header("初始化子弹")]
    public float LifeTime=5f;
    public float LinearVelocity=0;
    public float Acceleration=0;
    public float AngularVelocity=0;
    public float AngularAcceleration=0;
    public float MaxVelocity=int.MaxValue;

    [Header("初始化发射器")]
    public float InitRotation=0;
    public float SenderAngularVelocity=0;
    public float SenderAcceleration=0;
    public int count=0;
    public float LineAngle=30;
    public float SendInterval = 0.1f;
    public float SenderMaxAngularVelocity=int.MaxValue;
    [Header("子弹随机参数")]
    public bool RandomLinearVelocity = false; 
    [Tooltip("子弹速度随机范围")]
    public Vector2 VelocityRange = new Vector2(-15f, 15f);

    public bool RandomAcceleration = false;
    [Tooltip("加速度随机范围")]
    public Vector2 AccelerationRange = new Vector2(-15f, 15f);

    public bool RandomAngularVelocity = false;
    [Tooltip("角速度随机范围")]
    public Vector2 AngularVelocityRange = new Vector2(-15f, 15f);

    public bool RandomAngularAcceleration = false;
    [Tooltip("角速度加速度随机范围")]
    public Vector2 AngularAccelerationRange = new Vector2(-15f, 15f);

    [Header("发射器随机参数")]
    public bool RandomInitRotation = false;
    [Tooltip("发射器初始旋转角度随机范围")]
    public Vector2 InitRotationRange = new Vector2(-15f, 15f);

    public bool RandomSenderAngularVelocity = false;
    [Tooltip("发射器角速度随机范围")]
    public Vector2 SenderAngularVelocityRange = new Vector2(-15f, 15f);

    public bool RandomSenderAcceleration = false;
    [Tooltip("发射器加速度随机范围")]
    public Vector2 SenderAccelerationRange = new Vector2(-15f, 15f);

    public bool RandomLineAngle = false;
    [Tooltip("发射器发射角度随机范围")]
    public Vector2 LineAngleRange = new Vector2(-15f, 15f);

    [Header("预设")]
    public GameObject prefabs;

}