using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[5];
    public GameObject spawnbox;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
        NewEnemy();
        StartCoroutine(SpawnAfterTime(30.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        NewEnemy();
        
    }

    public void NewEnemy()
    {

        float minx = spawnbox.transform.position.x - spawnbox.transform.localScale.x / 2;
        float miny = spawnbox.transform.position.y - spawnbox.transform.localScale.y / 2;
        float maxx = spawnbox.transform.position.x + spawnbox.transform.localScale.x / 2;
        float maxy = spawnbox.transform.position.y + spawnbox.transform.localScale.y / 2;
        Vector3 pos = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0);
        while (Vector3.Distance(pos, player.position) < 5.5) {
            pos = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0);
        }
        print(Vector3.Distance(pos, player.position));
        Instantiate(enemies[Random.Range(0, 4)], pos, Quaternion.identity);
    }
}
