using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Player;
    public PlayerController player;

    public bool gotKey = false;
    public bool isSafe = false;
    public bool isEnding = false;
    

    private void Awake()
    {
        player = Player.GetComponent<PlayerController>();
    }

    private void Start()
    {
        gotKey = false;
    }

   


}
