using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlayer : MonoBehaviour
{
    [SerializeField] private IntVariable playerTurn;
    [SerializeField] private IntVariable turnPhase;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private float holdTime = 5f;
    float startTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(turnPhase.value == 2)
        {
            if(Input.GetButtonDown("Down"))
                startTime = Time.time;

            if (Input.GetButton("Down"))
            {
                if((startTime + holdTime) - Time.time <= 0)
                {
                    if (playerTurn.value == 1)
                        Explode(player1);
                    else
                        Explode(player2);
                }
            }        
        }
    }

    private void Explode(GameObject player)
    {
        player.GetComponent<RestartPosition>().OnRaise();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        startTime = Time.time;
    }
}
