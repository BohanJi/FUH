using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAceptar : MonoBehaviour
{

    [SerializeField] private ControladorJuego controladorjuego; 
    public Item i;

    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;


    // Start is called before the first frame update
    void Start()
    {        
        i=FindObjectOfType<Item>();
        objetActivable3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(controladorjuego.tiempoActivo==false && i.inicio==1){
            Debug.Log("se pasa a la siguiente escena");
        }else{
            controladorjuego.ActivarTemporizador();
            objetActivable1.SetActive(false);
            objetActivable2.SetActive(false);
            objetActivable3.SetActive(false);
            objetActivable4.SetActive(false);
        }
        
    } 
}