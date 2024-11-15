using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật

    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy input từ bàn phím (WASD hoặc mũi tên)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY).normalized; // Chuẩn hóa hướng di chuyển
    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("asdas");
        }
    }
}

