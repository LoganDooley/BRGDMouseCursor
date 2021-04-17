using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker2Slider : MonoBehaviour
{
    public GameObject ticker1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position += new Vector3(-0.05f, 0, 0);
        if (this.gameObject.transform.position.x < -22)
        {
            this.gameObject.transform.position = new Vector3(ticker1.GetComponent<SpriteRenderer>().bounds.size.x + ticker1.transform.position.x - 1.65f, -1.8351f, 0);
        }
    }
}
