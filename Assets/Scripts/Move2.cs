using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
  //Variável que controla a força do pulo
  public float jumpForce = 20.0f;
  //Variável que controla a massa/peso
  public float mass = 3.0f;
  //Acessamos o componente Rigidbody através dessa variável
  private Rigidbody rigidbodyOfObject;
  //Variável de controle que nos diz se o personagem está ou não no chão
  private bool isGround = false;

  public float _velocidade = 20.0f;
  public float _girar = 60.0f;

	public float direcaoFrente = 0f;
	public float direcaoLados = 0f;

  // Start is called before the first frame update
  void Start()
  {
    //Assim que o script  é executado, obtemos o componente Rigidbody e atribuimos a nossa variável
    rigidbodyOfObject = GetComponent<Rigidbody>();
    //Definimos o valor da massa via script
    rigidbodyOfObject.mass = mass;
  }

  // Update is called once per frame
  void Update()
  {
    //hack
    //https://answers.unity.com/questions/376587/how-to-treat-inputgetaxis-as-inputgetbuttondown.html
    if(Input.GetAxis("Vertical") != 0f){
      direcaoFrente = Input.GetAxis("Vertical");
    }
    if(Input.GetAxis("Horizontal") != 0f){
      direcaoLados = Input.GetAxis("Horizontal");
    }
    float translate = (direcaoFrente * _velocidade) * Time.deltaTime;
    float rotate = (direcaoLados * _girar) * Time.deltaTime;
    transform.Translate(0, 0, translate);
    transform.Rotate(0, rotate, 0);

    if (!Input.GetKeyDown(KeyCode.Space) || !isGround)
      return;
    rigidbodyOfObject.AddForce(
    Vector3.up * jumpForce,
    ForceMode.Impulse
    );
    
  }

  //Verifica se o personagem tocou no chão
  void OnCollisionEnter(Collision collision)
  {
    isGround = true;
  }

  //Verifica se o personagem saiu do chão
  void OnCollisionExit(Collision collision)
  {
    isGround = false;
  }

  public void Jump()
  {
    Debug.Log("!!!!!!!! !!!!!!!!! PULO TOP");
    if (!isGround)
      return;
    //Adicionamos uma força ao Rigidbody
    rigidbodyOfObject.AddForce(
      Vector3.up * jumpForce, //Para fazer o personagem pular, então multiplicamos (0, 1, 0) pelo valor do pulo
      ForceMode.Impulse // Ajustamos a força para o tipo Impulse
      );
  }

  //Desculpa professor mas o onClick() deixa o codigo quebrado, tem que colocar um
  //event trigger em cada botão e adicionar pointer up e pointer down

  ///<summary>
  ///Coloca no pointer down
  ///</summary>
  public void Forward()
  {
    direcaoFrente = 1;
  }

  ///<summary>
  ///Coloca no pointer up
  ///</summary>
	public void ForwardBackUp(){
		direcaoFrente = 0;
	}

  ///<summary>
  ///Coloca no pointer down
  ///</summary>
	public void Back(){
		direcaoFrente = -1;
	}

  ///<summary>
  ///Coloca no pointer down
  ///</summary>
	public void Right(){
		direcaoLados = 1;
	}

  ///<summary>
  ///Coloca no pointer down
  ///</summary>
	public void Left(){
		direcaoLados = -1;
	}

  ///<summary>
  ///Coloca no pointer up
  ///</summary>
	public void RightLeftUp(){
		direcaoLados = 0;
	}
}
