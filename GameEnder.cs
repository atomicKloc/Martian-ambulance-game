using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    private float journeyTime = 0f;
    private GameObject door;
    public GameObject rover;
    private float time;
    private Vector3 oldPosition;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        //Defining elements
        oldPosition = new Vector3(0f,0f,0f);
        time = 0f;  
        door = gameObject;
        rover = GameObject.FindWithTag("rover");
        Debug.Log(PlayerPrefs.GetFloat("highScore"));
    }

    // Update is called once per frame
    void Update()
    {
        journeyTime +=Time.deltaTime;
        //calculates velocity
        velocity = Vector3.Distance(oldPosition,rover.transform.position)/Time.deltaTime;
            //checks if player is still, and near the door, if so, it moves to the win screen
            if (Vector3.Distance(door.transform.position,rover.transform.position)<10 && velocity < .05f){
            time+=Time.deltaTime;
            if(time > 3){
                Cursor.visible = true;
                //Sets high score
                if(PlayerPrefs.GetFloat("highScore")<600f-journeyTime){
                    Debug.Log("oh");
                    PlayerPrefs.SetFloat("highScore",600f-journeyTime);
                    Debug.Log(PlayerPrefs.GetFloat("highScore"));
                }
                Debug.Log(PlayerPrefs.GetFloat("highScore"));
                //PlayerPrefs.SetFloat("highScore",0f);
                //score.scores = score.scores.Add(journeyTime);
                SceneManager.LoadScene(3);
            }   
        }else{
            time = 0;
        }
        //finds old position for velocity calculations
        oldPosition = rover.transform.position;
    }
}
