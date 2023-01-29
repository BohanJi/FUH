using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;

public class ermitaño : MonoBehaviour
{

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;
    private int dialog=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 )
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartDialogue();
            
            }
        }
    }

    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "Si encuentras madera te diré como levantar el puente";
    }
}
