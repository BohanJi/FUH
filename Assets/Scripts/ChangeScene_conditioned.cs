using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_conditioned : MonoBehaviour
{
	public string scene;
    public GameObject targetObject;

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");

        if (collision.gameObject.CompareTag("Player")){
            if (interaction != 0)
            {
                if (targetObject.activeInHierarchy == true)
                {
                    SceneManager.LoadScene(scene);
                }
            }
        }
    }

}