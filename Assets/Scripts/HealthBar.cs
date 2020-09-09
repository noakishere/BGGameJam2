using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject[] healthArr;

    [SerializeField] Sprite deadSprite;

    
    // Update is called once per frame
    void Update()
    {
        ChangeSprite();   
    }

    void ChangeSprite()
    {
        int index = FindObjectOfType<Player>().health;
        if (index < 3)//a ameliorer
        {
            healthArr[index].GetComponent<Image>().sprite = deadSprite;
        }
    }
}
