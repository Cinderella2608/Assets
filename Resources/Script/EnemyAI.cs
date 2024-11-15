using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 5f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position; // Lưu vị trí bắt đầu
    }

    void Update()
    {
        // Di chuyển chướng ngại vật qua lại
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}

