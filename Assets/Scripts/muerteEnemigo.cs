using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerteEnemigo : MonoBehaviour
{
    public Item i;
    public int tiempo=5;
    // Start is called before the first frame update
    void Start()
    {
        i=FindObjectOfType<Item>();
        Invoke("Desaparecer", tiempo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        i.puntos-=5;
        Debug.Log(i.puntos);
        i.SetCountText();
        Desaparecer();
    } 

    void Desaparecer(){
        Destroy(gameObject);
    }
}

