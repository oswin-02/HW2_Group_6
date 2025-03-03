using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyBehavior : SimpleEnemyBehavior
{
    // Spearman run to player and attack so fast, but he need a cooldown
    //cooldown
    //public float cooldownTime;

    //animation
    //private Animator spearAnim;

    protected override void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attacking code
            //set animation
            //attack
            
            alreadyAttacked = true;
            wait = true;
            //cooldown
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    protected override void ResetAttack()
    {
        wait = false;
        alreadyAttacked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Hit da player");
            HealthManager.GetInstance().DoDamage(1);
        }
    }
}
