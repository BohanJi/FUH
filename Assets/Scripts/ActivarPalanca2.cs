using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalanca2 : MonoBehaviour
{
    public GameObject objetActivable1;//palanca estado1
    public GameObject puente;//puente
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable1.SetActive(true);
                transformaciones();
                Destroy(gameObject);

            }
        }
    }

    private void transformaciones(){
        puente.transform.Rotate(0,0,-28.487f);
        Vector2 traslacion= new Vector2(48.35f,6.44f);
        puente.transform.position=traslacion;
    }
}
