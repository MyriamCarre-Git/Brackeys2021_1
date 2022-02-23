using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    [HideInInspector] public Transform player;
    [HideInInspector] public Vector2 originalPos;

    public float timeBetweenAttacks;
    public float moveSpeed;
    public float chasingSpeed;
    public int enemyDamage;

    [SerializeField] private float chaseDistance;
    [SerializeField] private float stopDistance;
    [SerializeField] private float attackSpeed;
    private float attackTime;
    [SerializeField] private bool isInLight = false;


    private bool canAttack => Vector2.Distance(transform.position, player.position) < stopDistance;
    private bool isCloseToPlayer => Vector2.Distance(transform.position, player.position) < chaseDistance;
    //private bool willAttack => canAttack && isCloseToPlayer;


    private void Start()
    {
        originalPos = transform.position;
        Debug.Log(originalPos);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        ChasePlayer();

        if (isInLight)
        {
            //trigger particule ensuite
            transform.position = originalPos;
            Debug.Log(originalPos);
        }
    }

    private void ChasePlayer()
    {
        if (player != null) //check if dead
        {
            if (isCloseToPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
                if (canAttack)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private void AttackPlayer()
    {
        if (Time.time >= attackTime)
        {
            StartCoroutine(Attack());
            attackTime = Time.time + timeBetweenAttacks;
        }
    }

    IEnumerator Attack()
    {
        //player.GetComponent<PlayerController>().TakeDamage(enemyDamage);

        Vector2 originalPos = transform.position;
        Vector2 targetPos = player.transform.position;
        //Vector2 middlePoint = (targetPos - originalPos) / 2;
        float percentAttackMovement = 0f;

        while (percentAttackMovement <= 1)
        {
            percentAttackMovement += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percentAttackMovement, 2) + percentAttackMovement) * 4;
            transform.position = Vector2.Lerp(originalPos, targetPos, formula);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightCourage"))
        {
            isInLight = true;
            //trigger particule ensuite
            transform.position = originalPos;
            Debug.Log(originalPos);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightCourage"))
        {
            isInLight = false;
        }
    }


}
