using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    private TextMeshProUGUI mText;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        //define components
        Debug.Log("highscore");
        value = -(PlayerPrefs.GetFloat("highScore")-600);
        mText = GetComponent<TMPro.TextMeshProUGUI>();
        //set highscore
        mText.text = (value/60f).ToString("0")+":"+(value%60f).ToString("0.00000");
    }   

}
