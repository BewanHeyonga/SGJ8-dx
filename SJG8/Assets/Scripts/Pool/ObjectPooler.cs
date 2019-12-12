using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictonary;

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    private void Start()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach (pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            print(pool.tag);
            poolDictonary.Add(pool.tag,objectpool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotaion)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag"+tag+"doesn't excist");
            return null;
        }

        GameObject objectToSpawn = poolDictonary[tag].Dequeue();
        print("tag");
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotaion;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictonary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
