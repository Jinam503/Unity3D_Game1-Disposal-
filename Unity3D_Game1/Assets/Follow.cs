using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform trans;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = trans.transform.position;
    }
}
