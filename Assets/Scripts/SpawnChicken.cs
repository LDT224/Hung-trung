using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChicken : MonoBehaviour
{
    public GameObject chicken;
    public GameObject[] spawnPoint;
    private List<GameObject> chickenList = new List<GameObject>();
    private List<int> pointList = new List<int>();
    private float minSpawnTime = 0.5f;
    private float maxSpawnTime = 1;
    private float lastSpawnTime = 0;
    private float spawnTime = 0;
    private int point;
    private int numChicken=10;

    public GameObject egg;
    public GameObject shit;
    //public GameObject spawnegg;
    // Start is called before the first frame update
    void Start()
    {
        updateSpawnEgg();
        spawnChicken();

    }
    void spawnChicken()
    {
        for(int i = 0; i < numChicken; i++)
        {
            point = Random.Range(0, spawnPoint.Length);
            checkPoint();
            pointList.Add(point);
            GameObject chick = Instantiate(chicken, spawnPoint[point].transform.position, Quaternion.identity);
            chickenList.Add(chick);
        }
    }
    void checkPoint()
    {
            for(int j = 0; j < pointList.Count; j++)
            {
                if(point == pointList[j])
                {
                    point = Random.Range(0, spawnPoint.Length);
                    checkPoint();
                    break;
                }
            }

    }
    void updateSpawnEgg()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void spawnEgg()
    {
        int i = Random.Range(0, chickenList.Count);

        int ran = Random.Range(0, 5);
        if (ran == 0)
        {
            Instantiate(shit, chickenList[i].transform.GetChild(0).position, Quaternion.identity);
        }
        else
        {
            Instantiate(egg, chickenList[i].transform.GetChild(0).position, Quaternion.identity);
        }

        updateSpawnEgg();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            spawnEgg();
        }
    }
}
