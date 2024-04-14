using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class towerProjectileController : MonoBehaviour
{
    private GameObject target;


    public float force = 10f;


    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setTarget(GameObject enemy)
    {
       
        target = enemy;
        
    }
    // Update is called once per frame
    void Update()
    {
       
        if (target != null)
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y + 0.3f, target.transform.position.z), force * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) <= 0.3f)
            {
                target.GetComponent<Stats>().Takedamage(target, damage);
                Destroy(gameObject);
            }
           
        }

      

    }


}
