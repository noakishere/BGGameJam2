using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameMaster>().score += 10;
        Destroy(collision.gameObject);
    }
}
