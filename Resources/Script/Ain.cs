using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ain : MonoBehaviour
{
    public float MvSpeed = 5f;
    Vector2 Speed;
    public Rigidbody2D rg;
    public Animator Anim;
    private bool isFacingRight = true;

    private float AtkTime = 0.25f;
    private float AtkCounter = 0.25f;
    private bool IsAtk;

    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float BulletForce = 20f;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Speed.x = Input.GetAxisRaw("Horizontal") * MvSpeed;
        Speed.y = Input.GetAxisRaw("Vertical") * MvSpeed;
        rg.velocity = new Vector2 (Speed.x, Speed.y);
        Anim.SetFloat("Speed", Speed.sqrMagnitude);

        if (Speed.x > 0 && !isFacingRight)
        {
            Flip(); // Lật nhân vật sang phải
        }
        else if (Speed.x < 0 && isFacingRight)
        {
            Flip(); // Lật nhân vật sang trái
        }

        if (IsAtk)
        {
            rg.velocity = Vector2.zero;
            AtkCounter -= Time.deltaTime;
            if (AtkCounter <= 0)
            {
                Anim.SetBool("IsAtk", false);
                IsAtk = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AtkCounter = AtkTime;
            Anim.SetBool("IsAtk", true);
            IsAtk = true;
        }
        if (Input.GetKeyDown(KeyCode.I))  // Bắn lên
        {
            Shoot(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.K))  // Bắn xuống
        {
            Shoot(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.J))  // Bắn sang trái
        {
            Shoot(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.L))  // Bắn sang phải
        {
            Shoot(Vector2.right);
        }
    }
    void Shoot(Vector2 direction)
    {
        GameObject Bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rg = Bullet.GetComponent<Rigidbody2D>();
        rg.AddForce(direction * BulletForce, ForceMode2D.Impulse);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Đổi trạng thái
        Vector3 theScale = transform.localScale; // Lấy scale hiện tại
        theScale.x *= -1; // Đảo chiều x
        transform.localScale = theScale; // Áp dụng scale mới
    }
}
