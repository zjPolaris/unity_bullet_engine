using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class projectilepool
{
    private ObjectPool<projectiles> pool;

    public projectileobject objects;
    public projectiles GetItem()
    {
        return pool.Get();
    }
    public void ReleaseItem(projectiles bh)
    {
        pool.Release(bh);
    }
    public projectilepool()
    {
        pool = new ObjectPool<projectiles>(OnCreateItem, OnGetItem, OnReleaseItem, OnDestroyItem);
    }

    private projectiles OnCreateItem()
    {
        var bh = GameObject.Instantiate(objects.prefabs).AddComponent<projectiles>();
        InitProjectile(bh);
        bh.pool = this;
        return bh;
    }
    private void InitProjectile(projectiles bh)
    {
        var grid = GameObject.Find("ProjectileContainer");
        if(grid) bh.transform.SetParent(grid.transform);
        
        bh.LinearVelocity = objects.RandomLinearVelocity ? Random.Range(objects.VelocityRange.x, objects.VelocityRange.y) : objects.LinearVelocity;
        bh.AngularVelocity = objects.RandomAngularVelocity ? Random.Range(objects.AngularVelocityRange.x, objects.AngularVelocityRange.y) : objects.AngularVelocity;
        bh.AngularAcceleration = objects.RandomAngularAcceleration ? Random.Range(objects.AngularAccelerationRange.x, objects.AngularAccelerationRange.y) : objects.AngularAcceleration;
        bh.Acceleration = objects.RandomAcceleration ? Random.Range(objects.AccelerationRange.x, objects.AccelerationRange.y) : objects.Acceleration;
        bh.LifeTime = objects.LifeTime;
        bh.MaxVelocity = objects.MaxVelocity;
    }
    private void OnDestroyItem(projectiles bh)
    {
        if (bh != null && bh.gameObject != null) 
        {
            Object.Destroy(bh.gameObject);
        }
    }
    private void OnReleaseItem(projectiles bh)
    {
        bh.gameObject.SetActive(false);

    }
    private void OnGetItem(projectiles bh)
    {
        InitProjectile(bh);
        bh.gameObject.SetActive(true);

    }
    public void Dispose()
    {
        if (pool != null)
        {
            pool.Clear(); 
            pool = null;
        }
    }
}
