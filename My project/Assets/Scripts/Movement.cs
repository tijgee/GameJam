using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;

    float horizontal;
    float vertical;
    public float dashSpeed = 200000;

    public float runSpeed = 20.0f;
    public Rigidbody2D rg;

    bool dash = true;
    int dashCooldown = 80;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (dashCooldown == 0)
        {
            dash = true;
        }
        else
        {
            dashCooldown--;
        }

        //rg.velocity = Vector2.zero;

        if (dash && Input.GetKey(KeyCode.Space))
        {
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            rg.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            dash = false;
            dashCooldown = 80;
        }
    }
}
