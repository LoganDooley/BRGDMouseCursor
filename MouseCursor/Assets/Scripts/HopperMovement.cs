using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopperMovement : MonoBehaviour
{
    public Rigidbody2D myrb;
    // Start is called before the first frame update
    void Start()
    {
        myrb.angularVelocity = 60;
        StartCoroutine("Cycle");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.value*4);
            float angle = (transform.eulerAngles.z+180)%360;
            Debug.Log(angle);
            Vector2 norm = new Vector2(Mathf.Cos(angle*Mathf.PI/180), Mathf.Sin(angle*Mathf.PI/180)).normalized;
            myrb.velocity = norm*4;
            myrb.angularVelocity = 0;
            myrb.freezeRotation = true;
            yield return new WaitForSeconds(1f);
            myrb.velocity = new Vector2(0, 0);
            myrb.freezeRotation = false;
            myrb.angularVelocity = 60;
        }
    }
}
