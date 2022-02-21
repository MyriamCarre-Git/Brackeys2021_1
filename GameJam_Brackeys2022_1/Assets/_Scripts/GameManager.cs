using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Player;
    PlayerController player;
    

    private void Awake()
    {
        player = Player.GetComponent<PlayerController>();
    }

    private void Update()
    {
    }

   
}
