using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiral : MonoBehaviour
{

    private Vector2 origin;
    private float t = 0.0F;
    private float tR = 0.0F;
    public float maxR = 1.0F;
    public float distSpeed = 0.5F;
    public float rotSpeed= 2.0F;

    // Start is called before the first frame update
    void Start()
    {
        this.origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.t = Time.deltaTime + t;
        float alpha = maxR * Mathf.Sin(t * distSpeed);
        this.transform.position = new Vector3(this.origin.x + alpha * Mathf.Cos(t * this.rotSpeed), this.origin.y + alpha * Mathf.Sin(t * this.rotSpeed), this.transform.position.z);
    }
}
