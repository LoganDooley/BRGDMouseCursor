using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextControl : MonoBehaviour
{
    GameObject myCarrierObject;
    public Text myText;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        myCarrierObject = GameObject.Find("PointsHolder");
        int points = myCarrierObject.GetComponent<Points>().GetPoints();
        myText.text = "FINAL SCORE: " + points;
    }
}
