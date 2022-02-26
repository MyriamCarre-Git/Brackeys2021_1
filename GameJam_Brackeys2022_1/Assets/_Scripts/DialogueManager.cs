using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //public Text text;
    public TextMeshProUGUI text;
    [SerializeField] Animator anim;
    [SerializeField]  GameObject MenuBox;
    UI_MenuBox menuBox;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        menuBox = MenuBox.GetComponent<UI_MenuBox>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log(dialogue);

        sentences.Clear();

        anim.SetBool("IsOpen", true);
        menuBox.isOpen = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        text.text = sentence;
        //Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("End of diaogue");
        anim.SetBool("IsOpen", false);
        menuBox.isOpen = false;
    }
}
