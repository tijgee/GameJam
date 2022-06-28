using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector2 bulletDirection;
    public float bulletSpeed = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal != 0 || vertical != 0)
            bulletDirection = (new Vector2(horizontal, vertical)).normalized;

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = transform.position + ((new Vector3(bulletDirection.x, bulletDirection.y, 0.0f)).normalized * 2);
            bullet.transform.up = new Vector3(bulletDirection.x, bulletDirection.y, 0.0f);
            bullet.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        }
    }
}
