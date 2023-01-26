using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    AudioSource audioData;
    public void Start(){
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
    // Start is called before the first frame update
    public void Play(){
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Exit(){
        Application.Quit();
    }
    public void Back(){
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
