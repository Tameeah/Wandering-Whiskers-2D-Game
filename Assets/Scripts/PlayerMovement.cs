using System;
using UnityEngine;

//Title: TOP DOWN MOVEMENT in Unity!
//Author:Brackeys
//Date: 20 April 2025

//OpenAI (2025) ChatGPT response on rotating particle systems in Unity. ChatGPT. Available at: https://chat.openai.com/ (Accessed: 11 June 2025).


public class PlayerMovement : MonoBehaviour

{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public ParticleSystem Footprints;
    Vector2 movement;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Check if player is in motion
        if (movement.sqrMagnitude > 0.01f)
        {
            var main = Footprints.main;

            float angle = Mathf.Atan2(movement.y, movement.x);

            if (movement.y < 0)
            {
                angle += Mathf.PI; 
            }
            if (movement.y > 0)
            {
                angle -= Mathf.PI;
            }

            main.startRotation = angle;

            if (!Footprints.isPlaying)
                Footprints.Play();
        }
        else
        {
            if (Footprints.isPlaying)
                Footprints.Stop();
        }
        Debug.Log("Movement: " + movement);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
