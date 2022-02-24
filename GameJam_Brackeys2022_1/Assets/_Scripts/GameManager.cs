using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Player;
    public PlayerController player;

    public bool gotKey;
    

    private void Awake()
    {
        player = Player.GetComponent<PlayerController>();
    }

    private void Start()
    {
        gotKey = false;
    }

   


}
