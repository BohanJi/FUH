using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMinijuego : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform limitD;
    [SerializeField] Transform limitI;
    Animator animator;
    private bool cambiar=false;
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            cambiar=!cambiar;
            ChangeDirect();
        }
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
        transform.position= new Vector2(transform.position.x+speed*Time.deltaTime,transform.position.y);
    }

    void ChangeDirect(){
        animator.SetBool("cambio",cambiar);
        speed=-speed;
    }

}
