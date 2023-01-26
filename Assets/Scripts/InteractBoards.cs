using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBoards : MonoBehaviour
{

    public GameObject objetActivable1;
    public GameObject objetActivable2;

    void Start()
    {
        objetActivable1.SetActive(false);
        objetActivable2.SetActive(false);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                objetActivable1.SetActive(true);

            }
        }
    }
}
