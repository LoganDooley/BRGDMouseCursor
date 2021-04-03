using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject spawn;
    public GameObject pointsholder;

    // Start is called before the first frame update
    void Awake()
    {
        spawn = GameObject.Find("SpawnArea");
        pointsholder = GameObject.Find("PointsHolder");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "circle") {
            GameObject.Find("player").GetComponent<move>().IncTrail();
            Destroy(this.gameObject);
            spawn.GetComponent<EnemySpawn>().NewEnemy();
            pointsholder.GetComponent<Points>().AddPoints(100);
        }
    }
}
