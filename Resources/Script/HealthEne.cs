using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEne : MonoBehaviour
{
    public int BaseHealth;
    public int MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EneDmg(int DmgGiven)
    {
        BaseHealth -= DmgGiven;
        if (BaseHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
