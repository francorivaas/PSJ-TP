using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : IPooleable
{
    private List<T> active = new List<T>();
    private List<T> used = new List<T>();

    private T poolObject;

    public Pool(T prefab)
    {
        this.poolObject = prefab;    
    }

    public T GetInstance()
    {
        GameObject pObj;

        if (active.Count == 0)
        {
            pObj = GameObject.Instantiate(poolObject.Prefab.gameObject);
            //active.Add(pObj);
        }

        T obj = active[0];

        used.Add(obj);
        active.Remove(obj);

        return obj;
    }

    public void Store(T pool)
    {
        //pool.gameObject.SetActive(false);

        active.Add(pool);
        used.Remove(pool);
    }
}
