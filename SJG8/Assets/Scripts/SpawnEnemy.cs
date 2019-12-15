using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteEnemyTable : MonoBehaviour
{
    public GameObject TrueEn;
    public GameObject FalseEn;
    Queue<Enemy> enemies;
    GameController ctrl;
    private void Start()
    {
        ctrl = GameController.Instance;
    }
    float stepTime = 6f;  
    //协成生成敌人
    IEnumerator SpawnEnemy()
    {
        MoveALLEnemy();
        yield return new WaitForSeconds(stepTime);
        while (!ctrl.isDie)
        {
            Spawn();
        }
                 
    }
    void Spawn()
    {
        var num = Random.Range(0, 5);

        for (int i = 0; i < 5; i++)
        {
            
        }
    }
    //移动所有的敌人
    void MoveALLEnemy()
    {

    }
}
