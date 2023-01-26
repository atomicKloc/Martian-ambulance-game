using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navArrow : MonoBehaviour
{
    public GameObject rover;
    public GameObject marsBase;
    private float direction;
    private Vector3 roverPos;
    private Vector3 roverForward;
    private Vector3 basePos;
    private float adjust1;
    private float adjust2;
    // Start is called before the first frame update
    void Start()
    {
        rover = GameObject.FindWithTag("rover");
        marsBase = GameObject.FindWithTag("base");
        UpdatePos();
        
    }
    void UpdatePos(){
        roverPos = rover.transform.position;
        basePos = marsBase.transform.position;
        roverForward = rover.transform.up;
        if(roverPos.z-basePos.z<0){
            adjust1 = Mathf.PI;
        }else{
            adjust1 = 0f;
        }
        if(roverForward.z<0){
            adjust2 = Mathf.PI;
        }else{
            adjust2 = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        direction = (Mathf.Atan((roverPos.x-basePos.x)/(roverPos.z-basePos.z))+adjust1-Mathf.Atan(roverForward.x/roverForward.z)-adjust2)*180f/Mathf.PI;
        transform.rotation = Quaternion.Euler(0f, 0f, direction);
        Debug.Log(roverForward);
        
    }
}
