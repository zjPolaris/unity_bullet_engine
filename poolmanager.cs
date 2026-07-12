using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolmanager : singleton<poolmanager>
{
    public Dictionary<int, projectilepool> pools = new Dictionary<int, projectilepool>();
    public projectilepool GetPool(projectileobject objects)
    {
        if (!pools.ContainsKey(objects.ID))
        {
            var pool = new projectilepool();
            pool.objects = objects;
            pools.Add(objects.ID, pool);
        }
        return pools[objects.ID];
    }
    public void ClearAllPools()
    {
        foreach (var poolEntry in pools)
        {
            poolEntry.Value?.Dispose();
        }
        pools.Clear();
    }
}
