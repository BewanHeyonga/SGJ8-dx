using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
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
    #endregion
    [HideInInspector]
    public List<Enemy> Enemies;
    [HideInInspector]
    public EnemySpawn spawnCtrl;
    private void Start()
    {
        spawnCtrl = GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>();
        Enemies=spawnCtrl.Spawn(0);if(Enemies==null)
        { print("Enemise ERROR"); }

    }
 
    public void Die()
    {
       //this The Enemies is Null，I don't Delete enemy In Here.
       
        foreach (Enemy enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
