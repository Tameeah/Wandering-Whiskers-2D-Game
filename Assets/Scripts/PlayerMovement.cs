using System;
using UnityEngine;

//Title: TOP DOWN MOVEMENT in Unity!
//Author:Brackeys
//Date: 20 April 2025


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
            if (!Footprints.isPlaying)
            {
                Footprints.Play();
            }
        }
        else
        {
            if (Footprints.isPlaying)
            {
                Footprints.Stop();
            }
        }

}
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
