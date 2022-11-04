using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
  public GameObject gameManager;
  private GameManager gameManagerComponent;
  void Start()
  {
    if (gameManager == null)
    {
      //Pelo amor de deus garantir que só tenha um objeto com o component GameManager
      gameManagerComponent = FindObjectOfType<GameManager>();
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.transform.parent.name == "Player" && GetComponent<MeshRenderer>().enabled)
    {
      gameManagerComponent.updatePoint(1);
      GetComponent<MeshRenderer>().enabled = false;
    }
  }

  public void reabilitarMoeda()
  {
    GetComponent<MeshRenderer>().enabled = true;

  }
}
