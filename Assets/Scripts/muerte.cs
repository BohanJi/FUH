using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : MonoBehaviour
{

    public Item i;
    public int tiempo=8;
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
        i.puntos+=10;
        Debug.Log(i.puntos);
        i.SetCountText();
        Destroy(gameObject);
    } 

    void Desaparecer(){
        i.puntos-=2;
        i.SetCountText();
        Destroy(gameObject);
    }
}
