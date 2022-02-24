using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public float baseCourage;
    public float currentCourage;
    public float currentHealth;
    public float health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float minimumSpeed;
    public float rotationSpeed;

    Vector2 axisInput;
    public bool isCourageFilling = false;
    private bool isInLight = false;

    [Header("Références")]
    [SerializeField] GameObject GameManager;
    GameManager gameManager;
    Rigidbody2D rb;
    Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.GetComponent<GameManager>();
        anim = GetComponent<Animator>();

        currentSpeed = moveSpeed;
        currentCourage = baseCourage;
        currentHealth = health;
    }

    void Update()
    {
        axisInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        CourageDepletion();
        Vitesse();
        FacingDirection();
        AnimationController();

        if (isInLight)
        {
            CourageFill();
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }


    private void CourageDepletion()
    {
        if(currentCourage > 0 && !isCourageFilling)
        {
            currentCourage -= 0.5f * Time.deltaTime;
        }
    }
    
    public void CourageFill()
    {
        if (currentCourage < baseCourage)
        {
            currentCourage += 2 * Time.deltaTime;
            isCourageFilling = true;
        }
    }
   
    private void PlayerMovement()
    {
        rb.velocity = axisInput.normalized * currentSpeed * Time.deltaTime;
    }

    private void Vitesse()
    {
        float couragePercentage = currentCourage / baseCourage;
        float courageSpeed = couragePercentage * moveSpeed;

        currentSpeed = Mathf.Clamp(courageSpeed , minimumSpeed, moveSpeed);
    }

    private void FacingDirection()
    {
        if (axisInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, axisInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightCourage"))
        {
            isInLight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightCourage"))
        {
            isCourageFilling = false;
            isInLight = false;
            
        }
    }

    private void AnimationController()
    {
        float animationSpeed = currentSpeed / moveSpeed;

        if(axisInput != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.speed = animationSpeed;
        }
        else
        {
            //anim.SetBool("isWalking", false);
            anim.SetBool("isWalking", true);
            anim.speed = 0;

        }
    }

    public void TakeDamage(float damage)
    {

        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
        }
        else
        {
            //jous l'anim de mort
        }
        
    }

    public void ResetPlayer()
    {
        currentCourage = baseCourage;
        currentHealth = health;
        currentSpeed = moveSpeed;
    }
}
