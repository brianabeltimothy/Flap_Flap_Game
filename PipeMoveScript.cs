using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    public float incrementRate = 5f; //increase rate in 5s

    void Update()
    {
        //move the object to the left
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        //destroy the pipe when it is no longer needed
        if (transform.position.x <= -40)
        {
            Destroy(gameObject);
        }

        //to make the pipe moves faster
        floatIncreaser();
    }

    private void floatIncreaser()
    {
        float elapsedTime = Time.deltaTime; // Time elapsed since last frame
        moveSpeed += elapsedTime / incrementRate;
    }
}
