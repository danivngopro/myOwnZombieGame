using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    private bool turn = true;
    private Vector2 moveVelocity;
    public float speed;

    public float temp;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
        temp = Input.GetAxisRaw("Horizontal");
        if (temp < 0 && turn) flip();
        if (temp > 0 && !turn) flip();
    }

    void flip()
    {
        turn = !turn;
        transform.Rotate(Vector3.up * 180);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
