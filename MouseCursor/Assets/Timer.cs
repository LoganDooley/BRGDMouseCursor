using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeLeft;
    public float currentTime = 0f;
    public float startingTime = 0f;
    public int seconds;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = GetComponent<Text>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        seconds = (int)(currentTime % 60);
        
       
        if (seconds < 0){
            seconds = 0;
        }
        timeLeft.text = "Time Left: " + seconds;

    }
}
