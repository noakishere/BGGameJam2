using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    
    private void Start()
    {
        int rand = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[rand], transform.position, Quaternion.identity);
    }
}
