using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    public GameObject Virus;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBtnSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if( Time.time > spawnTime ){
            Spawn();
            spawnTime = Time.time + timeBtnSpawn;
        }

    }

    void Spawn(){
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(Virus,transform.position + new Vector3(randomX , randomY ,0), transform.rotation);
    }
}
