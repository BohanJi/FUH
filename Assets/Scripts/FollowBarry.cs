using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowBarry : MonoBehaviour
{
    bool empezar = false;
    Queue<Vector2> posQueue = new Queue<Vector2>();

    PlayerController barry;
    Rigidbody2D rBody;
    int retraso = 150; //frame
    // Start is call0ed before the first frame update
    void Start()
    {
        rBody= GetComponent<Rigidbody2D>();
        barry = FindObjectOfType<PlayerController>();
        empezar = true;

        GetComponent<Dialogue>().SetInteracuable(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(empezar) 
        {
            Vector2 movement;
            movement = barry.GetPosition();
            posQueue.Enqueue(movement);
            if (posQueue.Count > retraso)
            {
                rBody.position = posQueue.Dequeue();
            }
        }
    }
}
