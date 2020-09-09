using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   // [SerializeField] GameObject obstacle;

    [SerializeField] GameObject[] obstaclePattern;
    [SerializeField] GameObject[] bonusPattern;

    private float timeBtwnSpawn;
    public float startTimeBtwnSpawn;

    public float decreaseTime;

    public float minTime = 0.25f;

    public int bonusTimer = 1;
   // public float bonusBtwn = 10f;

    private void Update()
    {
        SpawnObstacles();
        SpawnBonus();
    }

    void SpawnObstacles()
    {
        if (timeBtwnSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePattern.Length);

            Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity);
            timeBtwnSpawn = startTimeBtwnSpawn;
            if (startTimeBtwnSpawn > minTime)
            {
                startTimeBtwnSpawn -= decreaseTime;
            }
        }

        else
        {
            timeBtwnSpawn -= Time.deltaTime;
        }
    }

    void SpawnBonus()
    {
        
        int rand = Random.Range(0, bonusPattern.Length);
        
        //Debug.Log(bonusTimer);

        if (bonusTimer == 100)
        {
            Instantiate(bonusPattern[0], transform.position, Quaternion.identity);
            bonusTimer = 0;
        }

        else
        {
            bonusTimer++;
        }
    }

    


}
