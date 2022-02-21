using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public float baseCourage;
    public float currentCourage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float minimumSpeed;
    [SerializeField] float rotationSpeed;

    Vector2 axisInput;
    public bool isCourageFilling = false;
    private bool isInLight = false;

    [Header("Références")]
    [SerializeField] GameObject GameManager;
    GameManager gameManager;
    Rigidbody2D rb;
    //Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.GetComponent<GameManager>();

        currentSpeed = moveSpeed;
        currentCourage = baseCourage;

       
    }

    void Update()
    {
        axisInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        CourageDepletion();
        Vitesse();
        FacingDirection();

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
        currentSpeed = Mathf.Clamp(currentCourage * 15, minimumSpeed, moveSpeed);
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
}
