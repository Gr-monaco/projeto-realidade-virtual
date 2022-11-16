using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinBehavior : MonoBehaviour
{

  private GameManager gameManagerComponent;


  // Start is called before the first frame update
  void Start()
  {
    gameManagerComponent = FindObjectOfType<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.transform.parent.name == "Player" && GetComponent<MeshRenderer>().enabled)
    {
        Debug.Log(gameManagerComponent.pointsTextObject.GetComponent<Text>().text);
        Debug.Log(gameManagerComponent.timeRemaining);
      gameManagerComponent.endGameWithText("O jogador venceu! Teve " + (int.Parse(gameManagerComponent.pointsTextObject.GetComponent<Text>().text) * gameManagerComponent.timeRemaining).ToString() + "pontos " );
      GetComponent<MeshRenderer>().enabled = false;
    }
  }

  public void reabilitar()
  {
    GetComponent<MeshRenderer>().enabled = true;

  }
}
