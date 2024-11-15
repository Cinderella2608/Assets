using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene : MonoBehaviour
{
    private Animator Anim;
    private Transform target;
    public Transform FPs;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Maxrange;
    [SerializeField]
    private float Minrange;

    private bool isFacingRight = true;
    void Start()
    {
        Anim = GetComponent<Animator>();
        target = FindObjectOfType<Ain>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= Maxrange && Vector3.Distance(transform.position, target.position) >= Minrange)
        {
            FlAin();
        }
        else if (Vector3.Distance(target.position, transform.position) >= Maxrange)
        {
            ComeBack();
        }
    }

    public void FlAin()
    {
        Anim.SetBool("Mv", true);
        Anim.SetFloat("Horizontal", (target.position.x - transform.position.x));
        Anim.SetFloat("Vertical", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);

        if (target.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (target.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }

    }

    public void ComeBack()
    {
        Anim.SetFloat("Horizontal", (FPs.position.x - transform.position.x));
        Anim.SetFloat("Vertical", (FPs.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, FPs.transform.position, Speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, FPs.position) == 0)
        {
            Anim.SetBool("Mv", false);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // Reverse the x axis of the sprite
        transform.localScale = localScale;
    }
}
