using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerController : MonoBehaviour
{
    public float intervalOfShooting = 5f;

    private bool isStart = false;

    public GameObject projectile;
    private GameObject enemy = null;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        if (isStart == false)
        {
          
            StartCoroutine(towerShoot(enemy, intervalOfShooting));
        }
    }
    private IEnumerator towerShoot(GameObject target, float interval)
    {
        
        if (enemy != null)
        {
            isStart = true;
            GameObject proj = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion());
            proj.GetComponent<towerProjectileController>().setTarget(target);
            proj.transform.LookAt(target.transform.position);
         // proj.transform.rotation = Quaternion.Euler(proj.transform.rotation.eulerAngles.x, proj.transform.rotation.eulerAngles.y, proj.transform.rotation.eulerAngles.z);
            yield return new WaitForSeconds(interval);
            StartCoroutine(towerShoot(target, interval));
           
        }
        else 
            isStart = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy" &&  enemy == null)
        {
            enemy = other.gameObject;
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == enemy)
        {   
            enemy = null;
            StartCoroutine(towerShoot(enemy, intervalOfShooting));
        }
        
    }
    
}
