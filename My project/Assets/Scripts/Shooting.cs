using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    private Vector2 direction;
    private float speed;
    // Start is called before the first frame update
    void Start(){
        speed = bullet.GetComponent<Stats>().moveSpeed;
    }

    // Update is called once per frame
    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal != 0 || vertical != 0)
            direction = (new Vector2(horizontal, vertical)).normalized;

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = transform.position + (new Vector3(direction.x, direction.y, 0.0f)).normalized;
            newBullet.transform.up = new Vector3(direction.x, direction.y, 0.0f);
            newBullet.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            newBullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
