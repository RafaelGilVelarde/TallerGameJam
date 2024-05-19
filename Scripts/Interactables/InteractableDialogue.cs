using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDialogue : Interactable
{
    [SerializeField] [TextArea] protected List<string> Dialogue;
    public override void Interact(Player player)
    {
        DialogueBox Aux=DialogueBox.Dialogue;
        for(int i=0;i<Dialogue.Count;i++){
            Aux.DialogueStrings.Add(Dialogue[i]);
        }
        DialogueBox.Dialogue.StartDialogue();
    }
}
