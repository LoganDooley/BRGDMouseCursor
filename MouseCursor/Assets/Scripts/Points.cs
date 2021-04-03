using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    static int points;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int pt)
    {
        points += pt;
    }

    public int GetPoints()
    {
        return points;
    }
}
