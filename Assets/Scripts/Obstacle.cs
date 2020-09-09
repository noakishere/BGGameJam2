using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;
    public Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !FindObjectOfType<Player>().isImmune)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().health -= damage;

            //So it won't surpass the limit and bug !!
            if(spawner.bonusTimer < 90)
                spawner.bonusTimer += 10; //help the player a little :(

            Destroy(gameObject);
        }      
    }
}
