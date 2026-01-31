using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Combat c;
    public GameObject player;
    public NavMeshAgent agent;

    Animator enemyAnimator;

    public float chaseDistance = 1.5f;
    public float attackDelay = 0.5f;
    public float attackTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GetComponent<Combat>();
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!c.isAttacking)
        {
            enemyAnimator.SetBool("IsAttacking", false);
            if (Vector3.Distance(player.transform.position, transform.position) > chaseDistance)
            {
                agent.destination = player.transform.position;
                attackTimer = 0f;
            }
            else
            {
                agent.destination = transform.position;
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackDelay)
                {
                    enemyAnimator.SetBool("IsAttacking", true);
                    c.StartAttack(transform.forward);
                    attackTimer = 0f;
                }
            }
        }
    }
}
