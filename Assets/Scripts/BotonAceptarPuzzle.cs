using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAceptarPuzzle : MonoBehaviour
{
    [SerializeField] private ControladorPuzzle controladorPuzzle;
    [SerializeField] private Puzzle puzzle;
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    // Start is called before the first frame update
    void Start()
    {
        puzzle=FindObjectOfType<Puzzle>();
    }

    void OnMouseDown()
    {
        if(controladorPuzzle.tiempoActivo==false && puzzle.inicio==1){
            Debug.Log("se pasa a la siguiente escena");
        }else{
            controladorPuzzle.ActivarTemporizador();
            objetActivable1.SetActive(false);
            objetActivable2.SetActive(false);
            objetActivable3.SetActive(false);

            objetActivable3.transform.position=new Vector2(500f,170f);
        }
       
    } 
}
