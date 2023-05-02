using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    
    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float offset = 10;
        float randomNum = Random.Range(0, offset);
        Instantiate(pipe, new Vector3(transform.position.x, randomNum, transform.position.z), transform.rotation);
    }
}
