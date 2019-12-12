using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "true")
            {
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
        print("打到真的了"); this.gameObject.SetActive(false);
    }
    //打中假的了
    void HitFalseEmpty(Collider other)
    {
        print("打到假的了");
        other.GetComponent<Enemy>().Shoot(); this.gameObject.SetActive(false);

    }
    //打中玩家了
    void HitPlayer()
    {
        print("反弹打到自己了"); this.gameObject.SetActive(false);
    }

}
