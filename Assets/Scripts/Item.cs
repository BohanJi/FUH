using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Item : MonoBehaviour
{

    public GameObject[] misobjs;
    public float tmin=0.5f;
    public float tmax=1f;
    private int inicio=0;

    public TextMeshProUGUI contador;
    public int puntos;
    // Start is called before the first frame update
    void Start()
    {
        puntos=0;
        SetCountText();
        Generar(); 

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Generar(){
        if(inicio!=0){
            Vector2 randomSpawn=new Vector2(Random.Range(-11,11),Random.Range(-5,5));
            Instantiate(misobjs[Random.Range(0,misobjs.Length)], randomSpawn, Quaternion.identity);
        }
        inicio=1;
        Invoke("Generar", Random.Range(tmin,tmax));
    }

    public void SetCountText()
	{        
		contador.text = "Puntos: " + puntos.ToString();
        
	}

    
}


