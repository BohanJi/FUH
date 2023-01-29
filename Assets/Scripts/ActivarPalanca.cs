using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;


    
public class ActivarPalanca : MonoBehaviour
{
    
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;

    public InteractPalanca palanca;
    public GameObject objetActivable1;
    public GameObject objetActivable2;//palanca estado1
    public GameObject objetActivable3;//palanca estado2
    public GameObject puente2;//puente
    int fin=0;
    // Start is called before the first frame update
    void Start()
    {
        palanca=FindObjectOfType<InteractPalanca>();
        objetActivable2.SetActive(false);
        objetActivable3.SetActive(false);
        puente2.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 && palanca.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable1.SetActive(false);
                Invoke("Espera", 1);
            }
        }

        if (interaction != 0 && fin==1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                dialoguePanel.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void Espera(){
        objetActivable2.SetActive(true);
        StartDialogue();
        fin=1;
    }

    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "Genial ya puedo activar la palanca";
    }

}
