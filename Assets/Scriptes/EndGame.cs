using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] private string target;
    [SerializeField] private IntVariable numberOfDeaths;
    [SerializeField] private Canvas scoreBoardCanvas;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private TextMeshProUGUI deaths;
    [SerializeField] private TextMeshProUGUI totalTime;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject timer;
    private bool isEnded = false;
    private float time;

    private void Start()
    {
        time = Time.time;
        scoreBoardCanvas.enabled = false;
    }
    private void Update()
    {
        if(isEnded)
        {
            Debug.Log("Winner");
            scoreBoardCanvas.enabled = true;
            totalTime.SetText(""+(int)(Time.time - time));
            deaths.SetText(""+numberOfDeaths.value);
            uiCanvas.enabled = false;
            player1.SetActive(false);
            player2.SetActive(false);
            timer.SetActive(false);
            GameObject aux = GameObject.FindWithTag("Present");
            if (aux != null)
                aux.SetActive(false);
            this.enabled = false;
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
