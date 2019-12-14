using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletDir
{
    Forward,
    Back
}
public class Arms : MonoBehaviour
{
    public BulletDir dir;
    public GameObject bullet;
    [Range(1,5000)]
    public float bulletSpeed = 2000;
    public void Shoot()
    {
        GameObject gameObject = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
   
        if (dir == BulletDir.Forward) { rb.AddForce(Vector3.forward * bulletSpeed); }
        else if(dir == BulletDir.Back) { rb.AddForce(Vector3.back * bulletSpeed); }
        
    }
}
