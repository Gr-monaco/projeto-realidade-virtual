﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 5f;

    public GameObject timerTextObject;
    public GameObject pointsTextObject;
    public GameObject endGameTextObject;
    private Text timerText;
    private Text pointsText;
    private Text endGameFieldText;

    private bool endGame = false;
    void Start()
    {
        timerText = timerTextObject.GetComponent<Text>();
        pointsText = pointsTextObject.GetComponent<Text>();
        endGameFieldText = endGameTextObject.GetComponent<Text>();
        endGameTextObject.SetActive(false);
        pointsText.text = "0";
    }

    void Update()
    {
        updateTimer();
        timerText.text = timeRemaining.ToString("0.00");
    }

    void updateTimer(){
        if(timeRemaining > 0 && !endGame){
            timeRemaining-=Time.deltaTime;
            if (timeRemaining < 0){
                endGame = true;
                endGameTextObject.SetActive(true);
                endGameText("Acabou o tempo");
                timeRemaining = 0;
            }
        }
    }

    public void updatePoint(int pointToAdd){
        //Tbm garanta que isso é possivel mudar para int, se não vai quebrar
        int beforePoints = int.Parse(pointsText.text);
        int newPointValue = pointToAdd + beforePoints;
        pointsText.text = newPointValue.ToString();
    }

    public void endGameText(string textToEndGame){
        endGameFieldText.text = textToEndGame;
    }
}