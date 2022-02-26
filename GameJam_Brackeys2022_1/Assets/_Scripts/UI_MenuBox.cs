using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuBox : MonoBehaviour
{
    Animator anim;
    //private bool isWaiting = true;
    //public bool isOpen = false;

    [SerializeField] DialogueManager dialogueManager;
    
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        anim = GetComponent<Animator>();
        
    }

    /*
    void Update()
    {
        if (isOpen)
        {
            Debug.Log("1");

            StartCoroutine(Wait());

            
            if (!isWaiting)
            {
                if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
                {
                    dialogueManager.DisplayNextSentence();
                }
            }
        }
    }
}




IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        isWaiting = false;
    }*/
}
