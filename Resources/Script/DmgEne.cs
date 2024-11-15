using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgEne : MonoBehaviour
{
    public int DmgGiven = 2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ene")
        {
            HealthEne Health;
            Health = other.gameObject.GetComponent<HealthEne>();
            Health.EneDmg(DmgGiven);
        }
    }
}
