﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private string target;
    [SerializeField] private GameEvent deathEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Ground"))
        {
            deathEvent.Raise();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.tag = "Ground";
        }
    }


}
