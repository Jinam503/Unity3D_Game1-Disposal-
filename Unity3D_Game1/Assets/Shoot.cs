using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    private float currentShotDelay;
    private float maxShotDelay = 0.1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentShotDelay += Time.deltaTime;
            if (currentShotDelay < maxShotDelay)
            {
                return;
            }
            Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            Debug.Log(firePos.transform.position);
            currentShotDelay = 0f;
        }
    }
}
