using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float attackspeed;
    public float damage;
    public float coast;
    public float money;

    GameObject plyaer;

    public void Awake()
    {
        plyaer = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void Update()
    {
       
    }

    public void Takedamage(GameObject target, float damage)
    {
        target.GetComponent<Stats>().health -= damage;
       
        if(target.GetComponent<Stats>().health <= 0)
        {
            if (target.tag == "Enemy")
            {
                plyaer.GetComponent<Stats>().money += target.GetComponent<Stats>().coast;
            }
            Destroy(target.gameObject);
        }
    }
   
}
