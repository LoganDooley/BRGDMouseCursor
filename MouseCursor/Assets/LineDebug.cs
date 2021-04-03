using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDebug : MonoBehaviour
{
    private PolygonCollider2D poly;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        poly = this.GetComponent<PolygonCollider2D>();
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.line.positionCount = this.poly.GetPath(0).Length;
        for (int i = 0; i < this.line.positionCount; i++) {
            this.line.SetPosition(i, new Vector3(this.poly.GetPath(0)[i].x, this.poly.GetPath(0)[i].y, 0));
        }
    }
}
