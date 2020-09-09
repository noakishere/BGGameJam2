using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Player player;

    public int score;

    public GameObject gameOverText;
    public Text scoreText;

    [SerializeField] GameObject spawner;

    void Start()
    {
        Cursor.visible = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessDeath();
        scoreText.text = score.ToString();
    }
    
    void ProcessDeath()
    {
        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }       
    } 
}
