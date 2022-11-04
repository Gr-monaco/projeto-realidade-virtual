using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerComponent;
    void Start()
    {
        if(gameManager ==  null){
            //Pelo amor de deus garantir que só tenha um objeto com o component GameManager
            gameManagerComponent = FindObjectOfType<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.parent.name == "Player"){
            gameManagerComponent.updatePoint(1);
            Destroy(this.gameObject);
        }
    }
}
