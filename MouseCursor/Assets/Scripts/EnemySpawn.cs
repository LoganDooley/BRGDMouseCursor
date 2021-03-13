using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[5];
    public GameObject spawnbox;
    // Start is called before the first frame update
    void Start()
    {
        float minx = spawnbox.transform.position.x - spawnbox.transform.localScale.x / 2;
        float miny = spawnbox.transform.position.y - spawnbox.transform.localScale.y / 2;
        float maxx = spawnbox.transform.position.x + spawnbox.transform.localScale.x / 2;
        float maxy = spawnbox.transform.position.y + spawnbox.transform.localScale.y / 2;
        Instantiate(enemies[0], new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewEnemy()
    {
        float minx = spawnbox.transform.position.x - spawnbox.transform.localScale.x / 2;
        float miny = spawnbox.transform.position.y - spawnbox.transform.localScale.y / 2;
        float maxx = spawnbox.transform.position.x + spawnbox.transform.localScale.x / 2;
        float maxy = spawnbox.transform.position.y + spawnbox.transform.localScale.y / 2;
        Instantiate(enemies[0], new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0), Quaternion.identity);
    }
}
