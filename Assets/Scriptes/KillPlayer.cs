using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private string target;
    [SerializeField] private GameEvent deathEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(target))
        {
            deathEvent.Raise();

            //Somar Mais um nas mortes
            //Resetar posição do jogador
            //Destroir Objeto
        }
    }
}
