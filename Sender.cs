using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    [System.Serializable]
    public class PhaseConfig
    {
        public projectileobject objects; 
        public float switchTime;             
    }

    public PhaseConfig[] phases;
    
    private int currentPhase;
    private float timer;
    private projectilepool currentPool;

    private float currentAngle;
    private float currentAngularVelocity;
    private float currentIntervalTimer;
    public void Start()
    {
        GameManager.RegisterSender();
        ResetToPhase(0);
        pool = poolmanager.Instance.GetPool(phases[0].objects);

    }

    private void ResetToPhase(int phaseIndex)
    {
        currentPhase = phaseIndex;
        timer = 0f;
        currentIntervalTimer = 0f;
        if (phases[currentPhase] != null && phases[currentPhase].objects != null){
        pool = poolmanager.Instance.GetPool(phases[phaseIndex].objects);
        var objects = phases[currentPhase].objects;
        currentPool = poolmanager.Instance.GetPool(objects);
        currentAngle = objects.RandomInitRotation ? Random.Range(objects.InitRotationRange.x, objects.InitRotationRange.y) : objects.InitRotation;
        currentAngularVelocity = objects.RandomSenderAngularVelocity ?
            Random.Range(objects.SenderAngularVelocityRange.x, objects.SenderAngularVelocityRange.y) : objects.SenderAngularVelocity;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        currentIntervalTimer += Time.fixedDeltaTime;
        if (currentPhase < phases.Length - 1 &&
           timer >= phases[currentPhase].switchTime)
        {
            ResetToPhase(currentPhase + 1);
            return;
        }
        if (currentPhase >= phases.Length - 1 && timer >= phases[currentPhase].switchTime)
        {
            gameObject.SetActive(false);
            GameManager.CompleteSender();
            return;
        }
        if (phases[currentPhase] != null && phases[currentPhase].objects != null)
        {
            var objects = phases[currentPhase].objects;
            currentAngularVelocity = Mathf.Clamp(currentAngularVelocity + objects.SenderAcceleration * Time.fixedDeltaTime,
                                                -objects.SenderMaxAngularVelocity, objects.SenderMaxAngularVelocity);
            currentAngle += currentAngularVelocity * Time.fixedDeltaTime;
            currentAngle %= 360f;
            if (currentIntervalTimer >= objects.SendInterval)
            {
                currentIntervalTimer -= objects.SendInterval;
                SendByCount(objects.count, currentAngle, objects);
            }
        }
    }

    private void SendByCount(int count,float angle,projectileobject objects){
        float lineAngle = objects.RandomLineAngle ? 
            Random.Range(objects.LineAngleRange.x, objects.LineAngleRange.y) : objects.LineAngle;
        float temp=count%2==0 ? angle+objects.LineAngle/2:angle;
        for(int i=0;i<count;++i){
            temp+=Mathf.Pow(-1,i)*i*lineAngle;
            Send(temp,objects);
            }
    }
    public projectilepool pool;
    private void Send(float angle, projectileobject objects)
    {
        var bh = pool.GetItem();
        bh.gameObject.transform.position = transform.position;
        bh.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (bh.TryGetComponent<Sender>(out var childSender)) 
        {
            childSender.gameObject.SetActive(true);
            childSender.ResetToPhase(0);
        }
    }

}
