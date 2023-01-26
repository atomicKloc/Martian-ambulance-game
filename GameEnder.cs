using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    private GameObject door;
    public GameObject rover;
    private float time;
    private Vector3 oldPosition;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = new Vector3(0f,0f,0f);
        time = 0f;  
        door = gameObject;
        rover = GameObject.FindWithTag("rover");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.Distance(oldPosition,rover.transform.position)/Time.deltaTime;
            if (Vector3.Distance(door.transform.position,rover.transform.position)<10 && velocity < .05f){
            time+=Time.deltaTime;
            if(time > 3){
                Cursor.visible = true;
                SceneManager.LoadScene(3);
            }   
        }else{
            time = 0;
        }
        oldPosition = rover.transform.position;
    }
}
