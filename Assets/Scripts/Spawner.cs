using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemilist;
    [SerializeField] float spwanTime=1;
    float timer;
    [SerializeField] Transform limitD;
    [SerializeField] Transform limitI;
    // Start is called before the first frame update
    void Start()
    {
        enemilist=new List<GameObject>();
        timer=spwanTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;

        if(timer<0){
            Spawn();
        }
        
    }

    void Spawn()
    {
        Vector2 spawnPos= new Vector2(Random.Range(limitI.position.x, limitD.position.x), transform.position.y);
        GameObject newEnemy=getFirstEnmyNoActive();
        newEnemy.transform.position=spawnPos;
        newEnemy.SetActive(true);
        timer=spwanTime;
    }

    GameObject getFirstEnmyNoActive(){
        for(int i=0; i<enemilist.Count;i++){
            if(!enemilist[i].activeInHierarchy){
                return enemilist[i];
            }
        }
        return createEnemy();
    }

    GameObject createEnemy(){
        GameObject newEnemy= Instantiate(enemyPrefab);
        newEnemy.transform.parent=gameObject.transform;
        newEnemy.SetActive(false);
        enemilist.Add(newEnemy);
        return newEnemy;
    }
}
