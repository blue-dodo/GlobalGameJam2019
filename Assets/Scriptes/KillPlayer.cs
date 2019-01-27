using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameEvent deathEvent;
    [SerializeField] private IntVariable playerTurn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Ground"))
        {
            deathEvent.Raise();
            collision.gameObject.GetComponent<RestartPosition>().OnRaise();
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.tag = "Ground";
        }
    }
}
