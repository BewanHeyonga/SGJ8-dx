using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyGos;
    public Vector3[] vectors;
    //当前的
    public Enemy[] Enemies;
    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Spawn(int num)
    {
        RandomVector(num);
        float length = vectors.Length;
        int index = Mathf.RoundToInt(Random.Range(0, length)) ;
        for (int i=0;i<length;i++)
        {
            if (i == index)
            {
                ObjectPooler.Instance.SpawnFromPool("TrueEnemy", vectors[i], Quaternion.identity);
                continue;
            }
            ObjectPooler.Instance.SpawnFromPool("FalseEnemy", vectors[i], Quaternion.identity);
        }
    }

    void RandomVector(int num)
    {
        vectors = new Vector3[num];
       
    }

    void Die()
    {
        foreach (Enemy enemy in Enemies)
        {
            enemy.Die();
        }
    }

}
