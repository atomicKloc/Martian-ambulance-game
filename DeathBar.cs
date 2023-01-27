using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathBar : MonoBehaviour
{
    
    public float death = 0f;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        death = 0f;
        slider = GetComponent<Slider>();
        slider.value = death;
    }

    // Update is called once per frame
    void Update()
    {
        //slowly counts until death, if it reaches it, it will to to the death screen
        death += 1f/600f*Time.deltaTime;
        slider.value = death;
        if(death >= 1f){
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }
}
