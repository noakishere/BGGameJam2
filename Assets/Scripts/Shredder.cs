using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
