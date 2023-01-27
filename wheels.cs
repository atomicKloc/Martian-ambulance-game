using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class wheels : MonoBehaviour
{
    private HingeJoint hinge;
    private JointMotor motor;
    // Start is called before the first frame update
    void Start()
    {   
        //definind components
        hinge = GetComponent<HingeJoint>();
        motor = hinge.motor;
    }

    // Update is called once per frame
    void Update()
    {
        // goes forward if you press forward backwards if you want to go backwards
        motor.targetVelocity = 1000f * Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") < 0f){      
            motor.targetVelocity -= 1000f;
        }
        //goes forward or backwards depending on where you want to turn
        if(Input.GetAxis("Horizontal") > 0f){
            motor.targetVelocity += 1000f;
        }
        hinge.motor = motor;
    }
}
