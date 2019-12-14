using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :Character
{
    [HideInInspector]
    public bool isDie=false;
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

    }

    public override void Die()
    {
        base.Die(); print("Player Die");


    }

    public override void Hit()
    {
        base.Hit();
        Hp -= 1;
        print("Player HP- 1");
    }

    public override void UpDate()
    {
        base.UpDate();
        if (Hp <= 0&&!isDie)
        {
            col.enabled = false;
            GameObject die = Instantiate(dieGo);
            this.gameObject.SetActive(false);
            
            isDie = true;
        }
    }
}
