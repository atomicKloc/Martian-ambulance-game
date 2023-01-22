using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMass : MonoBehaviour
{
    public Vector3 com = new Vector3(0f,0f,-.5f);
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com; 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
