using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float attackspeed;
    public float damage;

    
    public void Update()
    {
       
    }

    public void Takedamage(GameObject target, float damage)
    {
        target.GetComponent<Stats>().health -= damage;
       
        if(target.GetComponent<Stats>().health <= 0)
        {
            Destroy(target.gameObject);
        }
    }
   
}
