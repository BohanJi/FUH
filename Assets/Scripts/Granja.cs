using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granja : MonoBehaviour
{
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable1.SetActive(false);
                objetActivable2.SetActive(false);
                objetActivable3.SetActive(false);
                objetActivable4.SetActive(false);
                

            }
        }
    }
}
