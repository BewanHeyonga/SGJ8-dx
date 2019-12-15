using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :Character 
{
    [HideInInspector]
    public bool isDie = false;
    private void Start()
    {
        col = GetComponent<Collider>();

        arms = GetComponentInChildren<Arms>();
        arms.bullet = bullet;
        arms.bulletSpeed = bulletSpeed;
        arms.dir = bulletDir;
    }

    private void Update()
    {
        UpDate();
    }

    public override void Shoot()
    {
        base.Shoot();
        arms.Shoot();
    }

    private void OnEnable()
    {
        Born();
    }

    public override void Born()
    {
        base.Born(); 
    }

    public override void Die()
    {
        isDie = true;
        //col.enabled = false;
        Instantiate(dieGo,transform.position,Quaternion.identity);
        print("Kill");
        Destroy(this.gameObject,0.02f);

    }

    public override void Hit()
    {
        base.Hit();
        Hp -= 1;
    }

    //public override void UpDate()
    //{
    //    base.UpDate();
    //    if (Hp <= 0 && !isDie)
    //    {
    //        Die();
    //        isDie = true;
    //    }
    //}

}
