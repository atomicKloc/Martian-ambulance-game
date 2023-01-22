using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelsleft : MonoBehaviour
{
    private HingeJoint hinge;
    private JointMotor motor;
    // Start is called before the first frame update
    void Start()
    {   
        hinge = GetComponent<HingeJoint>();
        motor = hinge.motor;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Vertical"));
        motor.targetVelocity = 1000f * Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") > 0f){
            motor.targetVelocity -= 1000f;
        }else{
            //motor.freeSpin = true;
        }
        if(Input.GetAxis("Horizontal") < 0f){
            motor.targetVelocity += 1000f;
        }
        hinge.motor = motor;
    }
}
