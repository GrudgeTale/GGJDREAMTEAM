using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 2;
    public int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
}
