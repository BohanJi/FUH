using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;
using TMPro;

public class PlayerMinijuego : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform limitD;
    [SerializeField] Transform limitI;
    Animator animator;
    private bool cambiar=false;

    bool isInfected;
    [SerializeField] Color infectedColor;
    SpriteRenderer srpiteRende;
    public TextMeshProUGUI contador;
    int puntos;
    

    private void Awake(){
        srpiteRende=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isInfected){

            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("JuegoFinal");
            }
        }else{
            if(Input.GetMouseButtonDown(0)){
            cambiar=!cambiar;
            ChangeDirect();
            }
            transform.position= new Vector2(transform.position.x+speed*Time.deltaTime,transform.position.y);
            if(transform.position.x>=limitD.position.x){
                cambiar=true;
                transform.position= new Vector2(limitD.position.x,transform.position.y);   
                ChangeDirect();
            }

            if(transform.position.x<limitI.position.x){
                cambiar=false;
                transform.position= new Vector2(limitI.position.x,transform.position.y);
                ChangeDirect();
            }
            
        }
        
    }

    void ChangeDirect(){
        animator.SetBool("cambio",cambiar);
        speed=-speed;
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("enemy")){
            isInfected=true;
            animator.SetBool("Infected",isInfected);
            srpiteRende.color=infectedColor;
            collision.gameObject.GetComponentInParent<Spawner>().stop=true;
            collision.gameObject.SetActive(false);
            Debug.Log("over");
        }
        if(collision.CompareTag("point")){

            if(!isInfected){
                puntos++;
                SetCountText(); 
                Debug.Log(puntos);
                collision.gameObject.SetActive(false);
            }
            
        }
    }

    public void SetCountText()
	{        
		contador.text = "Puntos: " + puntos.ToString();
        
	}

}
