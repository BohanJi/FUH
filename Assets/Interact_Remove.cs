using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Remove : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
