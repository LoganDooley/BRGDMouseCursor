using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject spawn;
    private bool dying;
    private AudioSource circledSound;
    private AudioSource hitSound;
    public GameObject pointsholder;

    // Start is called before the first frame update
    void Start()
    {
        this.dying = false;
    }

    void Awake()
    {
        spawn = GameObject.Find("SpawnArea");
        pointsholder = GameObject.Find("PointsHolder");
        circledSound = GameObject.Find("Circled Sound").GetComponent<AudioSource>();
        hitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "circle" && !this.dying)
        {
            this.dying = true;
            GameObject.Find("player").GetComponent<move>().IncTrail();
            circledSound.Play();
            Destroy(this.gameObject);
            spawn.GetComponent<EnemySpawn>().NewEnemy();
            pointsholder.GetComponent<Points>().AddPoints(100);
        }
        else if (collision.gameObject.tag == "trail" && !this.dying)
        {
            this.dying = true;
            print("starting collision with trail");
            GameObject.Find("player").GetComponent<move>().DecTrail();
            hitSound.Play();
            //print("colliding with trail");
            Destroy(this.gameObject);
            spawn.GetComponent<EnemySpawn>().NewEnemy();
            print("ending collision with trail");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player" && !this.dying) {
            this.dying = true;
            print("starting collision with player");
            collision.gameObject.GetComponent<move>().DecTrail();
            hitSound.Play();
            Destroy(this.gameObject);
            spawn.GetComponent<EnemySpawn>().NewEnemy();
            print("ending collision with player");
        }
        

    }
}
