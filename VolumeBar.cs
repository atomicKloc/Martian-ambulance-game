using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    public Slider slider;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        //defining components
        volume = PlayerPrefs.GetFloat("volume");
        slider = GetComponent<Slider>();
        slider.value = volume;
    }

    // Update is called once per frame
    public void SetVolume()
    {
        //save volume
        volume = slider.value;
        PlayerPrefs.SetFloat("volume",volume); 
    }
}
