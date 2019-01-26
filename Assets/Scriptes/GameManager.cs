using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> randomList;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private IntVariable turnTime;
    [SerializeField] private IntVariable turnOfPlayer;
    [SerializeField] private IntVariable turnPhase;

    public void OnChangePlayerTurn()
    {
        if (turnOfPlayer.value <= 1)
        {
            turnPhase.value = 1;
            turnOfPlayer.value = 2;
            Player1.GetComponent<PlayerMovement>().enabled = false;
            Player2.GetComponent<PlayerMovement>().enabled = false;
            int random = Random.Range(0, randomList.Count - 1);
            present.GetComponent<ObjectMovement>().randomObject = randomList[(int)random];
            Instantiate(present);
        }
        else if (turnOfPlayer.value >= 2)
        {
            turnPhase.value = 1;
            turnOfPlayer.value = 1;
            Player1.GetComponent<PlayerMovement>().enabled = false;
            Player2.GetComponent<PlayerMovement>().enabled = false;
            int random = Random.Range(0, randomList.Count - 1);
            present.GetComponent<ObjectMovement>().randomObject = randomList[(int)random];
            Instantiate(present);
        }
    }

    public void OnChangeTurnPhase()
    {
        if (turnPhase.value <= 1)
        {
            turnPhase.value = 2;
            if(turnOfPlayer.value == 1)
            {
                Player1.GetComponent<PlayerMovement>().enabled = true;
                Player2.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                Player1.GetComponent<PlayerMovement>().enabled = false;
                Player2.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        else if (turnPhase.value >= 2)
        {
            turnPhase.value = 1;
            Player1.GetComponent<PlayerMovement>().enabled = false;
            Player2.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
