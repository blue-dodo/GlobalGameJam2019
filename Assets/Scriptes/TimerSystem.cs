using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private IntVariable timer;
    private float startTimer;
    private float currentTimer = 0;

    private void Start()
    {
        startTimer = Time.time;
    }

    private void Update()
    {
        if ((startTimer + timer.value) - Time.time <= 0)
            startTimer = Time.time;

        text.SetText("Time: " +(int)( (startTimer + timer.value) - Time.time));
    }
}
