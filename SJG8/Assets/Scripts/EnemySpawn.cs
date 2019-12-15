using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameController ctrl;
    public float step=6;
    public GameObject trueGameObj;
    public GameObject falseGameObj;
    public Transform originTrans;

    private List<Enemy> enemyList;
    private Vector3 ori;

    private void Awake()
    {
        ori = originTrans.position;
    }

    private void Start()
    {
        ctrl = GameController.Instance;
    }

    public List<Enemy> Spawn(int wavaIndex)
    {
        if (enemyList != null)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] != null)
                    enemyList.RemoveAt(i);
            }
        }

        enemyList = new List<Enemy>();
       

        var wava =ctrl.levelFile.waves[wavaIndex].enemyData;
        foreach (var data in wava)
        {
            switch (data.type)
            {
                case EnemyType.TrueEnemy:
                    SpawnTrueEnemy(data.bornPoint);
                    break;
                case EnemyType.falseEnemy:
                    SpawnFalseEnemy(data.bornPoint);
                    break;
            }
        }
        return enemyList;
    }

    void SpawnTrueEnemy(Vector2 pos)
    {
        var vector = GetVector3(pos);
        GameObject go
            =GameObject.Instantiate(trueGameObj,vector,Quaternion.identity);
        enemyList.Add(go.GetComponent<Enemy>());
    }

    void SpawnFalseEnemy(Vector2 pos)
    {
        var vector = GetVector3(pos);
        GameObject go=
            GameObject.Instantiate(falseGameObj,vector,Quaternion.identity);
        enemyList.Add(go.GetComponent<Enemy>());
    }

    Vector3 GetVector3(Vector2 pos)
    {
        return new Vector3(ori.x+pos.x*6,ori.y ,ori.z+pos.y*6);
    }
}
