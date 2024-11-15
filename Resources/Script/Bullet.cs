using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 2; // Sát thương của viên đạn

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với đối tượng có tag "Enemy"
        if (collision.gameObject.CompareTag("Ene"))
        {
            // Lấy script Enemy của đối tượng va chạm
            Ene enemy = collision.gameObject.GetComponent<Ene>();

            // Kiểm tra nếu đối tượng có script Enemy (quái vật)
            if (enemy != null)
            {
                HealthEne Health;
                Health = collision.gameObject.GetComponent<HealthEne>();
                Health.EneDmg(damage);
            }
        }

        // Xóa viên đạn sau khi va chạm với bất kỳ đối tượng nào
        Destroy(gameObject);
    }
}
