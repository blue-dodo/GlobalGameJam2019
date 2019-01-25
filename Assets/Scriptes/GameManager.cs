using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> randomList;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private IntVariable turnTime;
    [SerializeField] private IntVariable turnOfPlayer;
    [SerializeField] private IntVariable turnPhase;

    private void OnChangePlayerTurn()
    {

    }
}
