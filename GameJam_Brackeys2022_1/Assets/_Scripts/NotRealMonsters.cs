using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRealMonsters : MonoBehaviour
{
    GameManager gameManager;

    float currentSpeed;
    [SerializeField] float speed = 5f;
    [SerializeField] float speedExtra = 1f;

    //[SerializeField] AudioSource audioSource;
    //[SerializeField] AudioClip newClip;

    Vector2 position;
    Rigidbody2D rb;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        currentSpeed = speed;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, gameManager.player.transform.position, currentSpeed * Time.deltaTime);
        FacingDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speedExtra = speedExtra + (1 * Time.deltaTime);    
            currentSpeed = currentSpeed * speedExtra;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentSpeed = speed;
        }
    }

    private void FacingDirection()
    {
        Vector3 targetDirection = gameManager.player.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, gameManager.player.rotationSpeed * Time.deltaTime);
    }
}
