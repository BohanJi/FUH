using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    private float checkTime = 0.001f;
    private Vector2 oldPos;
    private Map_PlayerIconMove BarryIcon;

    void Update()
    {
        if (checkTime <= 0) {
            oldPos = transform.position;
            checkTime = 0.001f;
        }
        else {
            checkTime -= Time.deltaTime;
        }
        if (Vector2.Distance(transform.position, oldPos) < 0.1f)
        {
            BarryIcon.speed = 0;
        }
        else
        {
            BarryIcon.speed = 0;
        }
    }
}
