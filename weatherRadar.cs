using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherRadar : MonoBehaviour
{
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction += Time.deltaTime*360;
        transform.rotation = Quaternion.Euler(-90f, 0f, direction);
    }
}
