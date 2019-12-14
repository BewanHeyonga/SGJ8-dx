using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = EnemyManager.Instance;

    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "true")
            {
            print("True");
            enemyManager.Die();
            HitTureEmpty();
            }
            if (other.tag == "false")
            {
                HitFalseEmpty(other);
            }
            if (other.tag == "Player" )
            {
                HitPlayer();
            }
        

    }
    //打中真实的
    void HitTureEmpty()
    {
        Destroy(this.gameObject);
    }
    //打中假的了
    void HitFalseEmpty(Collider other)
    {
        other.GetComponent<Enemy>().Shoot(); Destroy(this.gameObject);

    }
    //打中玩家了
    void HitPlayer()
    {
        print("反弹打到自己了"); Destroy(this.gameObject);
    }

}
