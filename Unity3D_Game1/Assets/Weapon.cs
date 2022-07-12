using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;


    public void Use()
    {
        
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        
        GameObject instantBullet = Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
        Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = firePos.up * 20;
        yield return null;

        
    }
}
