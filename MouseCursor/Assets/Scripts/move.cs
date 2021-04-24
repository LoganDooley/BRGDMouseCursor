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
    public int trail_length;
    public int inc_amt = 1;
    private AudioSource cashoutSound;


    // Start is called before the first frame update
    void Start()
    {
        moveto = new Vector3(0, 1, 0);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        mycollide = new List<Transform>();
        Cursor.visible = false;
        this.trail_length = this.starting_length;
        cashoutSound = GameObject.Find("Cashout Sound").GetComponent<AudioSource>();
    }

    public void IncTrail() {
        this.trail_length = this.trail_length + 1;
    }

    public void DecTrail() {

        if (this.trail_length > this.starting_length)
        {
            this.trail_length = this.trail_length - 1;
            if (this.mycollide.Count > this.trail_length)
            {
                Destroy(this.mycollide[this.trail_length].gameObject);
                this.mycollide.RemoveAt(this.trail_length);
            }

        }
        else {
            Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
            timer.DecTimer();
        }
         

    }

    public void ResetTrail()
    {
        int old_length = this.trail_length;
        this.trail_length = this.trail_length  < this.starting_length ? this.trail_length : this.starting_length;
        Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (trail_length < old_length) {
            cashoutSound.Play();
        }
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
        this.player.position = cam.ScreenToWorldPoint(Input.mousePosition);
        // getting camera corners to keep mouse on screen
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        Vector3 botLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));

        if (this.player.position.x > topRight.x)
        {
            this.player.position = new Vector2(topRight.x, this.player.position.y);

        }
        if (this.player.position.y > topRight.y)
        {
            this.player.position = new Vector2(this.player.position.x, topRight.y);

        }
        if (this.player.position.x < botLeft.x)
        {
            this.player.position = new Vector2(botLeft.x, this.player.position.y);

        }
        if (this.player.position.y < botLeft.y)
        {
            this.player.position = new Vector2(this.player.position.x, botLeft.y);

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
        


    }

    private void MakeCircle(int index)
    {
        if (index >= mycollide.Count) {
            index = mycollide.Count - 1 ;
        }
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
