using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class enemyController : MonoBehaviour
{
    public float speed = 2.0f;
    private int wayPointsIndex = 0;

    public NavMeshAgent agent;
    public float rotateSpeedMovement = 0.05f;
    private float rotateVelocity;
    float motionSmoothTime = 0.1f;


    public Transform[] waypointArray;


    public Animator anim;


    private bool isAttacking = false;

    public float stoppingDIstance;







    private void attack()
    {
        //start animation
        //damage tower
        
    }

    

    void Start()
    {
        transform.LookAt(waypointArray[wayPointsIndex]);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);


        agent = gameObject.GetComponent<NavMeshAgent>();
       
    }
 

    // Update is called once per frame
    void Update()
    {
        Animation();
        

        if (isAttacking == false)
        {
            agent.SetDestination(waypointArray[wayPointsIndex].position);
            agent.stoppingDistance = stoppingDIstance;
            Rotatioh(waypointArray[wayPointsIndex].position);

            //transform.position = Vector3.MoveTo(transform.position, waypointArray[wayPointsIndex].position, speed * Time.deltaTime);
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
    public void Animation()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }
    public void Rotatioh(Vector3 lookAtPosiotn)
    {
        Quaternion rotationToLookAt = Quaternion.LookRotation(lookAtPosiotn - transform.position);
        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
        ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
