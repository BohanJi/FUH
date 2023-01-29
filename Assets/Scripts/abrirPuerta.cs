using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour
{

    public InteractBoards tablon;


    public GameObject objetActivable3;
    public GameObject objetActivable4;
    public GameObject objetActivable5;//llave

    void Start()
    {
        tablon=FindObjectOfType<InteractBoards>();
        objetActivable3.SetActive(false);
        objetActivable4.SetActive(false);
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 && tablon.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable3.SetActive(true);
                objetActivable4.SetActive(true);
                objetActivable5.SetActive(false);
                Destroy(gameObject);
                

            }
        }
    }
}
