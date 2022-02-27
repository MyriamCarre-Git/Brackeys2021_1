using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuBox : MonoBehaviour
{
    private bool isWaiting = true;
    public bool isOpen = false;

    [SerializeField] DialogueManager dialogueManager;
    
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
    }

   
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
                    Debug.Log("next sentence");
                   dialogueManager.DisplayNextSentence();
               }
           }
       } 
   }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.75f);
        isWaiting = false;
    }
}   
