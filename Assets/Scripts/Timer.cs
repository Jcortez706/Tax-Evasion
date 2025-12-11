using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] TMP_Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        countdownText.SetText(currentTime .ToString("F2"));

        if (currentTime <= 0)
        {
            currentTime = 0;
            Application.Quit();
        }
    }
}