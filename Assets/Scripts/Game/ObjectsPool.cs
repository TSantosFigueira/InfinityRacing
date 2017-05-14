using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Pool class for enemy objects
public class ObjectsPool : MonoBehaviour
{
    public GameObject objectToPool;  //!< Original object from which the pool will be generated from
    public int amountToPool;         //!< Amount of objects to generate
    public bool canGrow = false;     //!< Can the pool grow in execution time?
    List<GameObject> pooledObjects;  //!< Objects list 

    public ObjectsPool(GameObject obj, int amount, bool grows)
    {
        objectToPool = obj;
        amountToPool = amount;
        canGrow = grows;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool, gameObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //! Retrieves object from the pool
    public GameObject getObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (canGrow)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
