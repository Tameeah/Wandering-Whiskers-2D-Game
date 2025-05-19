using UnityEngine;

//Title: TOP DOWN MOVEMENT in Unity!
//Author:Brackeys
//Date: 20 April 2025
//Code Version: 
//Availability: https://www.youtube.com/watch?v=whzomFgjT50&list=PL0P4wU0t1XrUYMYTC2zhM71MgguxSXCmJ&index=5 

public class PlayerMovement : MonoBehaviour

{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
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

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
