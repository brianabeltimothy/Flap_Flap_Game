using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    private LogicScript logic;
    public bool birdIsAlive = true;
    public Transform birdPosition;
    public AudioClip flapSound;
    private AudioSource playerAudio;

    void Start()
    {
        //assign logic script and player audio source
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //press space to flap the bird and play the sound
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            playerAudio.PlayOneShot(flapSound, 1.0f);
        }
    }

    //if there is a collision, game over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
