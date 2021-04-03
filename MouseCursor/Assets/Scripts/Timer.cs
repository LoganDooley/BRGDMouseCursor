using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeLeft; //text that gets printed
    public float currentTime = 0f; //variable that gets manipulated
    public float startingTime = 0f; //starting variable, is edited in unity.
    public int seconds; //actual value that gets printed
    public float incAmt = 5.0f; //amount to increment timer per trail item


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
        seconds = (int)(currentTime);
        
       //this code just makes sure that the timer doesn't count down into negative numbers
        if (seconds < 0){
            seconds = 0;
        }
        if (currentTime < 0){
            SceneManager.LoadScene (sceneName:"GameOver");    
        }
        if(seconds > 9)
        {
            timeLeft.text = "Time Left: " + "0:" + seconds;
        }
        else
        {
            timeLeft.text = "Time Left: " + "0:0" + seconds;
        }
    }

    public void IncTimer() {
        print("increasing..");
        print(currentTime);
        currentTime += this.incAmt;
        print(currentTime);
    }
}
