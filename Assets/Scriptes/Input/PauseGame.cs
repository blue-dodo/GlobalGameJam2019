using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject timer;
    [SerializeField] private Canvas uiCanvas;
    private bool isPause;

    private void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            isPause = isPause ? false : true;
        }

        if(isPause)
        {
            uiCanvas.enabled = true;
            player1.SetActive(false);
            player2.SetActive(false);
            timer.SetActive(false);
            GameObject aux = GameObject.FindWithTag("Present");
            if(aux != null)
                aux.SetActive(false);


        }
        else
        {
            uiCanvas.enabled = false;
            player1.SetActive(true);
            player2.SetActive(true);
            timer.SetActive(true);
            GameObject aux = GameObject.FindWithTag("Present");
            if (aux != null)
                aux.SetActive(true);
        }
    }
}
