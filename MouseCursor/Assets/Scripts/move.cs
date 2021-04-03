using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D player;
    public float speed = 1f;
    public Transform colliders;
    public int frames_between = 10;
    private int frame = 0;
    private Vector3 moveto;
    private Vector3 mousepos;
    public List<Transform> mycollide;
    public int starting_length = 5;
    public PolygonCollider2D polyCollider;
    private Vector2 lastPos;
    private int trail_length;
    public int inc_amt = 1; 


    // Start is called before the first frame update
    void Start()
    {
        moveto = new Vector3(0, 1, 0);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        mycollide = new List<Transform>();
        Cursor.visible = false;
        this.trail_length = this.starting_length;
    }

    public void IncTrail() {
        this.trail_length = this.trail_length + 1;
    }

    public void ResetTrail()
    {
        int old_length = this.trail_length;
        this.trail_length = this.trail_length  < this.starting_length ? this.trail_length : this.starting_length;
        Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
        for (int i = trail_length; i < old_length; i++) {
            timer.IncTimer();
            Destroy(mycollide[i].gameObject);
        }
        this.mycollide.RemoveRange(this.trail_length, old_length - this.trail_length);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.ResetTrail();
        }
    }


    void FixedUpdate()
    {
        frame += 1;
        if (frame == 2)
        {
            frame = 0;
            if (mycollide.Count < trail_length)
            {
                mycollide.Add(Instantiate<Transform>(this.colliders, this.player.position, Quaternion.identity));
                if (mycollide.Count > 1) {
                    mycollide[mycollide.Count - 1].GetComponent<TrailFollow>().target = mycollide[mycollide.Count - 2].transform;
                } else {
                    mycollide[mycollide.Count - 1].GetComponent<TrailFollow>().target = this.transform;
                }
                mycollide[mycollide.Count - 1].GetComponent<TrailFollow>().index = mycollide.Count - 1;
            } 
        }
        this.player.position = cam.ScreenToWorldPoint(Input.mousePosition);
        
        
    }

    private void MakeCircle(int index)
    {

        List<Vector2> points = new List<Vector2>();
        for (int i = index; i >= 0; i--)
        {
            //print(mycollide[index].gameObject.transform.position);
            points.Add(new Vector2(mycollide[i].gameObject.transform.position.x, mycollide[i].gameObject.transform.position.y));
        }
        polyCollider.pathCount = 1;
        polyCollider.SetPath(0, points);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TrailFollow trailItem = collision.GetComponent<TrailFollow>();
        if (trailItem != null)
        {
            /*
            polyCollider.gameObject.SetActive(true);
            this.MakeCircle(index);
            StartCoroutine(deactivate());*/
            int index = trailItem.index;
            if (index != mycollide.Count - 1 && index >= 0)
            {
                this.MakeCircle(index);

            }
        }
    }

    IEnumerator deactivate()
    {
        yield return new WaitForSeconds(0.01f);
        polyCollider.gameObject.SetActive(false);
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    
}
