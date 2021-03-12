using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
