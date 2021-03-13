using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject spawn;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        spawn = GameObject.Find("SpawnArea");
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "circle") {
            Destroy(this.gameObject);
            spawn.GetComponent<EnemySpawn>().NewEnemy();
            player.GetComponent<Points>().AddPoints(100);
        }
    }
}
