using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float dashSpeed = 200000;
    
    private float moveSpeed;
    private Rigidbody2D rg;
    private float horizontal;
    private float vertical;
    private SpriteRenderer _renderer;

    bool dash = true;
    int dashCooldown = 80;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<Stats>().moveSpeed;
        rg.freezeRotation = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rg.velocity = (new Vector2(horizontal, vertical)).normalized * moveSpeed;
        
        if(horizontal > 0)
            _renderer.flipX = false;
        else if(horizontal < 0)
            _renderer.flipX = true;
        // if (dashCooldown == 0)
        // {
        //     dash = true;
        // }
        // else
        // {
        //     dashCooldown--;
        // }

        //rg.velocity = Vector2.zero;

        // if (dash && Input.GetKey(KeyCode.Space))
        // {
        //     Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
        //     rg.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
        //     dash = false;
        //     dashCooldown = 80;
        // }
    }
}
