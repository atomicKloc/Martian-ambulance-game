using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        menu = GameObject.FindWithTag("pause menu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if the escape key is pressed the menu is pulled up
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            menu.SetActive(true);
        }
    }
    //returns back to the game
    public void Continue(){
        Time.timeScale = 1;
        Cursor.visible = false;
        menu.SetActive(false);
    }
}
