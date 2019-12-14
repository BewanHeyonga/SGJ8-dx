using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Hp=1;
    protected Arms arms;
    protected Collider col;
    public GameObject bullet;
    public GameObject dieGo;

    public BulletDir bulletDir;
    [Range(1,2000)]
    public float bulletSpeed=2000f;

    public virtual void Shoot(){ }

    public virtual void UpDate(){ }

    public virtual void Born(){ }

    public virtual void Die(){  }

    public virtual void Hit() { }
}
