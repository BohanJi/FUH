using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPalanca : MonoBehaviour
{
    public GameObject objetActivable1;
    public bool agarrado=false;
   

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                agarrado=true;
                Destroy(gameObject);
                objetActivable1.SetActive(true);

            }
        }
    }
}
