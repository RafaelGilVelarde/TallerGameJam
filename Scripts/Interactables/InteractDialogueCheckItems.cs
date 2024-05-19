using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDialogueCheckItems : InteractableDialogue
{
    [SerializeField] [TextArea] List<string> Dialogue1, Dialogue2;
    [SerializeField] List<int> ItemIndex;
    public override void Interact(Player player)
    {
        if(!CheckItems(player)){
            Dialogue=Dialogue1;
        }
        else{
            Dialogue=Dialogue2;
            DialogueBox.Dialogue.dialogueEnd+=EndGame;
        }
        base.Interact(player);
    }
    bool CheckItems(Player player){
        int aux=0;

        for(int i=0;i<ItemIndex.Count;i++){
            for (int j=0;j<player.Items.Count;j++){
                if(ItemIndex[i]==player.Items[j].Base.ID){
                    aux++;
                }
            }
        }
        if(aux==4){
            return true;
        }
        else{
            return false;
        }
    }

    void EndGame(){
        DialogueBox.Dialogue.dialogueEnd-=EndGame;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
