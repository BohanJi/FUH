using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour
{

    public InteractBoards tablon;


    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;

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
                Destroy(gameObject);
                objetActivable1.SetActive(false);
                objetActivable2.SetActive(false);
                objetActivable3.SetActive(true);
                objetActivable4.SetActive(true);

            }
        }
    }
}
