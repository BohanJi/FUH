using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    public Transform playerPos;
    public Transform offscreenPos;
    public float showSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, showSpeed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, offscreenPos.position, showSpeed * Time.deltaTime);
        }
    }
}
