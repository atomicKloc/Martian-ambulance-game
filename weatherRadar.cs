using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherRadar : MonoBehaviour
{
    private float direction;

    // Update is called once per frame
    void Update()
    {
        //spins weather radar
        direction += Time.deltaTime*360;
        transform.rotation = Quaternion.Euler(-90f, 0f, direction);
    }
}
