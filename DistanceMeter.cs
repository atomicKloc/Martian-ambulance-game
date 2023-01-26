using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceMeter : MonoBehaviour
{
    public GameObject rover;
    public GameObject marsBase;
    private TextMeshProUGUI mText;
    private float distance;

    
    // Start is called before the first frame update
    void Start()
    {
        rover = GameObject.FindWithTag("rover");
        marsBase = GameObject.FindWithTag("base");
        mText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(rover.transform.position,marsBase.transform.position);
        if(distance>1000){
            mText.text = "Distance: " + (distance/1000f).ToString("0.0000")+"km";
        } else {
            mText.text = "Distance: " + distance.ToString("0.00")+"m";
        }
    }
}
