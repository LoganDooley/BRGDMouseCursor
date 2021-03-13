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
    public int trail_length = 5;
    public PolygonCollider2D polyCollider;

    // Start is called before the first frame update
    void Start()
    {
        moveto = new Vector3(0, 1, 0);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        mycollide = new List<Transform>();
    }

    void FixedUpdate()
    {
        frame += 1;
        if (frame == 2)
        {
            frame = 0;
            mycollide.Add(Instantiate<Transform>(this.colliders, this.player.position, Quaternion.identity));
            if (mycollide.Count > trail_length)
            {
                Destroy(mycollide[0].gameObject);
                mycollide.RemoveAt(0);
            }
        }
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            moveto = new Vector3(mousepos.x, mousepos.y, 0f) - player.transform.position;
            player.velocity = moveto.normalized * speed;
        }
        
    }

    private void MakeCircle(int index)
    {

        List<Vector2> points = new List<Vector2>();
        for (int i = index; i < mycollide.Count; i++)
        {
            //print(mycollide[index].gameObject.transform.position);
            points.Add(new Vector2(mycollide[i].gameObject.transform.position.x, mycollide[i].gameObject.transform.position.y));
        }
        polyCollider.pathCount = 1;
        polyCollider.SetPath(0, points);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = mycollide.IndexOf(collision.gameObject.transform);
        if (index != mycollide.Count - 1 && index >= 0)
        {
            polyCollider.gameObject.SetActive(true);
            this.MakeCircle(index);
            StartCoroutine(deactivate());
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
