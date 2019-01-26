using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private IntVariable timer;
    [SerializeField] private IntVariable turnPhase;
    [SerializeField] private GameEvent changePlayer;
    [SerializeField] private GameEvent changePhase;
    private float startTimer;

    private void Start()
    {
        startTimer = Time.time;
    }

    private void Update()
    {
        if((startTimer + timer.value) - Time.time <= 0)
        {
            changePlayer.Raise();
            startTimer = Time.time;
        }
            
        if (Input.GetButtonDown("Jump") && turnPhase.value == 1)
            changePhase.Raise();

        text.SetText("" + (int)( (startTimer + timer.value) - Time.time));
    }
}
