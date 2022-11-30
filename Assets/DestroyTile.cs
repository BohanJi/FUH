using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTile : MonoBehaviour
{
    public Tilemap destructableTiles;

    private void Start(){
		destructableTiles = GetComponent<Tilemap>();
	}
    private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag("Player")){
			Vector3 hitposition = Vector3.zero;
			float interaction = Input.GetAxis("Interaction");
			if (interaction != 0)
				{
					destructableTiles.SetTile(destructableTiles.WorldToCell(hitposition), null);
				}
			}
		}
}