using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private string target;
    [SerializeField] private Canvas scoreBoardCanvas;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject timer;
    private bool isEnded = false;

    private void Start()
    {
        scoreBoardCanvas.enabled = false;
    }
    private void Update()
    {

        if(isEnded)
        {
            Debug.Log("Winner");
            scoreBoardCanvas.enabled = true;
            uiCanvas.enabled = false;
            player1.SetActive(false);
            player2.SetActive(false);
            timer.SetActive(false);
            GameObject aux = GameObject.FindWithTag("Present");
            if (aux != null)
                aux.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(target))
        {
            isEnded = true;
        }
    }
}
