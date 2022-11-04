using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public float timeRemaining = 5f;

  public GameObject timerTextObject;
  public GameObject pointsTextObject;
  public GameObject endGameTextObject;
  public GameObject resetButton;
  public GameObject player;
  private Transform playerTransform;

  private Text timerText;
  private Text pointsText;
  private Text endGameFieldText;

  private bool endGame = false;
  void Start()
  {
    timerText = timerTextObject.GetComponent<Text>();
    pointsText = pointsTextObject.GetComponent<Text>();
    endGameFieldText = endGameTextObject.GetComponent<Text>();
    playerTransform = player.GetComponent<Transform>();
    endGameTextObject.SetActive(false);
    pointsText.text = "0";
  }

  void Update()
  {
    updateTimer();
    checkIfPlayerFell();
    timerText.text = timeRemaining.ToString("0.00");
  }

  void updateTimer()
  {
    if (timeRemaining > 0 && !endGame)
    {
      timeRemaining -= Time.deltaTime;
      if (timeRemaining < 0)
      {
        endGameWithText("Acabou o tempo!");
      }
    }
  }

  public void endGameWithText(string textoDeFim)
  {
    endGame = true;
    endGameTextObject.SetActive(true);
    resetButton.SetActive(true);
    endGameText(textoDeFim);
    timeRemaining = 0;

  }

  public void checkIfPlayerFell()
  {
    if (playerTransform.position.y < -3f)
    {
      endGameWithText("Jogador caiu!");
    }
  }

  public void updatePoint(int pointToAdd)
  {
    //Tbm garanta que isso é possivel mudar para int, se não vai quebrar
    int beforePoints = int.Parse(pointsText.text);
    int newPointValue = pointToAdd + beforePoints;
    pointsText.text = newPointValue.ToString();
  }

  public void endGameText(string textToEndGame)
  {
    endGameFieldText.text = textToEndGame;
  }

  public void novoJogo()
  {
    playerTransform.position = new Vector3(0, 0, 0);
    playerTransform.rotation = Quaternion.identity;
    timeRemaining = 30;
    endGameTextObject.SetActive(false);
    resetButton.SetActive(false);
    endGame = false;

  }
}
