using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour
{
    public Transform target;
    public int index = 0;
    public float maxDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetJoint2D joint = this.GetComponent<TargetJoint2D>();
        joint.target = target.position;
        if (Vector3.Distance(target.position, this.transform.position) > maxDist) {
            this.transform.position = target.position + (maxDist * Vector3.Normalize(this.transform.position - target.position));
            //this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
