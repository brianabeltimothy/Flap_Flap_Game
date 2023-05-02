using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float additionalSpace; //bcs every background has different size

    private BoxCollider2D boxCollider2D;
    private float width;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x * 10 - additionalSpace;
    }

    // Update is called once per frame
    void Update()
    {
        //make the backgrounds move to the left
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        //to check if the background needed to be repositioned
        if (transform.position.x <= -width - 10)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 position = new Vector2(width * 4f, 0);
        transform.position = (Vector2)transform.position + position;
    }
}
