using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField] Item item;
    public bool Interacted;
    // Start is called before the first frame update
    public override void Interact(Player player)
    {
        if (!Interacted)
        {
            player.Items.Add(item);
            Interacted = true;
        }
    }
}
