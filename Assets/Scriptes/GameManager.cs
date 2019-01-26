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
            //Player1 to Player2
            DefaultTurnSettings(2);
        else 
            //Player2 to Player1
            DefaultTurnSettings(1);
    }

    private void DefaultTurnSettings(int player)
    {
        turnPhase.value = 1;
        turnOfPlayer.value = player;
        Player1.GetComponent<PlayerMovement>().enabled = false;
        Player2.GetComponent<PlayerMovement>().enabled = false;

        //se tiver elimina o outro e cria outro
        GameObject aux = GameObject.FindWithTag("Present");
        if(aux != null)
            Destroy(aux);
        
        //se não tem um presente na cena cria outro
        int random = Random.Range(0, randomList.Count);
        present.GetComponent<ObjectMovement>().randomObject = randomList[random];
        Instantiate(present);

    }

    public void OnChangeTurnPhase()
    {
        if (turnPhase.value <= 1)
        {
            turnPhase.value = 2;
            if(turnOfPlayer.value == 1)
                Player1.GetComponent<PlayerMovement>().enabled = true;
            else
                Player2.GetComponent<PlayerMovement>().enabled = true;
        }
        else if (turnPhase.value >= 2)
        {
            turnPhase.value = 1;
        }
    }
}
