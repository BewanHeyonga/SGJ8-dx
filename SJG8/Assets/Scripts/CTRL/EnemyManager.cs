using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager:MonoBehaviour
{
    #region Singleton
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EnemyManager();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private GameController ctrl;
    [HideInInspector]
    public List<Enemy> Enemies=new List<Enemy>();

    public EnemySpawn spawnCtrl;
   
    public void Spawn(int num)
    {
        spawnCtrl = GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>();
      
        Enemies= spawnCtrl.Spawn(num);
    }
    public void Die()
    {
        ctrl = GameController.Instance;
        for (int i = 0; i< Enemies.Count;i++)
        {
            Enemies[i].Die();
        }

        ctrl.GoNextWave();

    }
}
