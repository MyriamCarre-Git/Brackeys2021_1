using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    [SerializeField] float courageNeeded;
    [SerializeField] Transform target;
    [Range(1, 10)] [SerializeField] float lerpSpeed = 8.47f;
    [SerializeField] GameObject GameManager;
    GameManager gameManager;
    Animator anim;

    void Start()
    {
        gameManager = GameManager.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Glitching();
        FollowPlayer();
    }


    void Glitching()
    {
        if (gameManager.player.currentCourage <= courageNeeded)
        {
            anim.SetBool("isGlitching", true);
        }
        else
        {
            anim.SetBool("isGlitching", false);
        }
    }

    void FollowPlayer()
    {
        Vector3 LerpPosition = Vector2.Lerp(transform.position, target.position, lerpSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(LerpPosition.x, LerpPosition.y, 0);
    }
}
