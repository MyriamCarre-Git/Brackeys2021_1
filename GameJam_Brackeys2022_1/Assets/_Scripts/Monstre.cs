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
   

    private bool canAttack => Vector2.Distance(transform.position, player.position) < stopDistance;
    private bool isCloseToPlayer => Vector2.Distance(transform.position, player.position) < chaseDistance;
    private bool playerisLowSanity =>
       player.GetComponent<PlayerController>().currentCourage < player.GetComponent<PlayerController>().baseCourage / 2;
    private bool playerisLowHealth =>
        player.GetComponent<PlayerController>().currentHealth < player.GetComponent<PlayerController>().health / 4;
    private bool isMoving = false;


    GameManager gameManager;
    Animator anim;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        originalPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        ChasePlayer();
        FacingDirection();
    }

    private void ChasePlayer()
    {
        if (player != null) //check if dead
        {
            if (!canAttack && isCloseToPlayer)
            {
                isMoving = true;
                transform.position = Vector2.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
            }
            else if (isCloseToPlayer)
            {
                if (canAttack)
                {
                    isMoving = false;
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
        
        if(playerisLowSanity && !playerisLowHealth)
        {
            player.GetComponent<PlayerController>().TakeDamage(enemyDamage + 1);
        }
        else
        {
            player.GetComponent<PlayerController>().TakeDamage(enemyDamage);
        } 
        
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
            //trigger particule ensuite
            transform.position = originalPos;
            Debug.Log(originalPos);
        }
    }

    private void FacingDirection()
    {
        Vector3 targetDirection = gameManager.player.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, gameManager.player.rotationSpeed * Time.deltaTime);
    }

    private void AnimationController()
    {
        if (isMoving)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;

        }
    }
}
