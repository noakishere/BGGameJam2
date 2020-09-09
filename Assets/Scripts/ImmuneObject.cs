using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneObject : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    public Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            //Triggers the function
            collision.GetComponent<Player>().isImmune = true;

            spawner.bonusTimer -= 500; //you dont want it to spawn way too frequently

            Destroy(gameObject);
        }
    }
}
