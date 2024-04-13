using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyController : MonoBehaviour
{
    public float speed = 2.0f;
    private int wayPointsIndex = 0;

    

    
    public Transform[] waypointArray;




    private bool isAttacking = false;




 

    private void attack()
    {
        //start animation
        //damage tower
        
    }

    

    void Start()
    {
        transform.LookAt(waypointArray[wayPointsIndex]);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointArray[wayPointsIndex].position, speed * Time.deltaTime);
        }
        else
        {
            attack();
        }
        




        if (Vector3.Distance(transform.position, waypointArray[wayPointsIndex].position) < 2f)
        {
            if (waypointArray.Length - 1 <= wayPointsIndex)
            {
                isAttacking = true;
            }

            else
            {
                
                wayPointsIndex++;
                transform.LookAt(waypointArray[wayPointsIndex]);
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            }

        }

    }
}
