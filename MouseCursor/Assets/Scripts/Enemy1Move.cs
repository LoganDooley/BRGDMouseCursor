using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    private GameObject player;
    public Rigidbody2D myrb;
    public float speed;
    void Awake()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 mypos = new Vector3(myrb.transform.position.x, myrb.transform.position.y, 0);
        this.gameObject.transform.position += (playerpos - mypos).normalized * speed * Time.deltaTime;
    }
}
