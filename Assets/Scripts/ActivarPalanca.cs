using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalanca : MonoBehaviour
{
    public InteractPalanca palanca;
    public GameObject objetActivable1;
    public GameObject objetActivable2;//palanca estado1
    public GameObject objetActivable3;//palanca estado2
    // Start is called before the first frame update
    void Start()
    {
        palanca=FindObjectOfType<InteractPalanca>();
        objetActivable2.SetActive(false);
        objetActivable3.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 && palanca.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable1.SetActive(false);
                Invoke("Espera", 1);
                

            }
        }
    }

    void Espera(){
        objetActivable2.SetActive(true);
        Destroy(gameObject);
    }
}
