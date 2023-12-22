using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReached : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
