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
    private List<Transform> mycollide;
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
        if (frame == 10)
        {
            frame = 0;
            mycollide.Add(Instantiate(colliders, player.position, Quaternion.identity));
            if (mycollide.Count > 22)
            {
                mycollide.RemoveAt(0);
            }
        }
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            moveto = new Vector3(mousepos.x, mousepos.y, 0f) - player.transform.position;
        }
        player.velocity = moveto.normalized*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = mycollide.IndexOf(collision.gameObject.transform);
        if(index != mycollide.Count && index != mycollide.Count - 1 && index != 0 && index != -1)
        {
            print(index);
        }
    }
}
