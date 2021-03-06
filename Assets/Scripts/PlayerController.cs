﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public variable to store the rigidbody of the player gameobject.
    public Rigidbody rb;

    // Public variable to store the movement speed of the player gameobject.
    public float speed;

    // Private vairable to store the score of the player gameobject.
    private int score = 0;

    // Public variable to store the health of the player gameobject.
    public int health = 5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called when health equals to 0.
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
            health = 0;
            score = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -500 * Time.deltaTime);
        }


        // WASD keys
        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -500 * Time.deltaTime);
        }
    }

    // Increments the value of score when the Player touches an object tagged Pickup.
    // Decrements the value of health when the Player touches an object tagged Trap.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("Score: " + score);
        }
        if (other.gameObject.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
}
