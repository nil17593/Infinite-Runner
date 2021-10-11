using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class ObjectPool : MonoSingletonGeneric<ObjectPool>
    {
        [SerializeField] private List<GameObject> pooledObjects;
        [SerializeField] private GameObject objectToPool;
        [SerializeField] private int amtToPool;

        protected override void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject temp;
            for (int i = 0; i < amtToPool; i++)
            {
                temp = Instantiate(objectToPool);
                temp.SetActive(false);
                pooledObjects.Add(temp);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amtToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    pooledObjects[i].SetActive(true);
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}