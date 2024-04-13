using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement)), RequireComponent(typeof(Stats))]
public class MeleeCombat : MonoBehaviour
{
    private Movement moveScript;
    private Stats stats;
    private Animator anim;

    [Header("Target")]
    public GameObject targetEnemy;

    [Header("Melee Attack Variables")]
    public bool performMeleeAttack = true;
    private float attackInterval;
    private float nextAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null)
        {
            anim.SetBool("isAttacking", false);
        }

       
        attackInterval = stats.attackspeed / ((500 + stats.attackspeed) * 0.01f);

        targetEnemy = moveScript.targetEnemy;

        if(targetEnemy != null && performMeleeAttack && Time.time > nextAttackTime) 
        {
            if(Vector3.Distance(transform.position, targetEnemy.transform.position) <= moveScript.stoppingDIstance )
            {
                StartCoroutine(MeleeAttackInterval()); 
            }
        }
    }
    private IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(attackInterval);

        if(targetEnemy == null)
        {
            anim.SetBool("isAttacking", false);
            performMeleeAttack = true;
        }
    }

    private void MeleeAttack()
    {
        stats.Takedamage(targetEnemy, stats.damage);

        nextAttackTime = Time.time + attackInterval;
        performMeleeAttack = true;

        anim.SetBool("isAttacking", false);
    }
}
