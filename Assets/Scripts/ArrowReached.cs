using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReached : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
