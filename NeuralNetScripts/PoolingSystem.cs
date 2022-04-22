using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        [SerializeField]
        string name;
        [SerializeField]
        GameObject Prefab;
        [SerializeField]
        int maxLength;
        Queue<GameObject> objects = new Queue<GameObject>();
        public List<GameObject> agg = new List<GameObject>();

        public Pool (string _name, GameObject _prefab, int max)
        {
            name = _name;
            Prefab = _prefab;
            maxLength = max;
            for (int i = 0; i < max; i++)
            {
                GameObject obj = Instantiate(Prefab);
                agg.Add(obj);
                obj.SetActive(false);
                objects.Enqueue(obj);
            }
            
        }

        internal GameObject GetNext()
        {
            GameObject obj = objects.Dequeue();

            objects.Enqueue(obj);
            return obj;
        }
    }
    [System.Serializable]
    public class PoolStarter
    {
        public string name;
        public GameObject prefab;
        public int maxLength;
    }


    [SerializeField]
    PoolStarter[] pools;
    Pool[] _pools;

    private void Start()
    {
        _pools = new Pool[pools.Length];
       
        for (int i = 0; i < pools.Length; i++)
        {
            _pools[i] = new Pool(pools[i].name, pools[i].prefab, pools[i].maxLength);
        }
    }

    public GameObject InstantiateFromPool(int index, Vector3 position,Quaternion Rotation)
    {
        GameObject obj = _pools[index].GetNext();
        obj.transform.position = position;
        obj.transform.rotation = Rotation;
        obj.SetActive(true);
        return obj;
    }
   
  
}
