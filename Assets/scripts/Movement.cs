using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    public NavMeshAgent agent;
    public float rotateSpeedMovement = 0.05f;
    private float rotateVelocity;

    public Animator anim;
    float motionSmoothTime = 0.1f;

    [Header("Enemy Targeting")]
    public GameObject targetEnemy;
    public float stoppingDIstance;
   // private HighlightManager hmscript;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
      //  hmscript = GetComponent<HighlightManager>();
    }


    void Update()
    {
        Animation();
        Move();
    }

    public void Animation()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }

    public void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Ground")
                {
                    MoveToPosition(hit.point);
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    MoveTowardsEnemy(hit.collider.gameObject);
                }
            }
        }
        if(targetEnemy != null)
        {
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) > stoppingDIstance)
            {
                agent.SetDestination(targetEnemy.transform.position);
            }
        }
    }
    public void MoveToPosition(Vector3 position)
    {
        agent.SetDestination(position);
        agent.stoppingDistance = 0;

        Rotatioh(position);

        if(targetEnemy != null) 
        {
          //  hmscript.DeselectHighlight();
            targetEnemy = null;
        }
    }

    public void MoveTowardsEnemy(GameObject enemy)
    {
        targetEnemy = enemy;
        agent.SetDestination(targetEnemy.transform.position);
        agent.stoppingDistance = stoppingDIstance;

        Rotatioh(targetEnemy.transform.position);
       // hmscript.SelectedHighlight();
    }

    public void Rotatioh(Vector3 lookAtPosiotn)
    {
        Quaternion rotationToLookAt = Quaternion.LookRotation(lookAtPosiotn - transform.position);
        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
        ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
