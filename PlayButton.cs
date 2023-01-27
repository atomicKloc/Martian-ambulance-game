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
    // disables cursor, loads new scene
    public void Play(){
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    //Exit's game
    public void Exit(){
        Application.Quit();
    }
    //activates cursor, goes back to game
    public void Back(){
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
    public void Update(){
        audioData.volume = PlayerPrefs.GetFloat("volume");
    }
}
