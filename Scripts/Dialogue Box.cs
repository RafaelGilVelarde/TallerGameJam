using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] public List<string> DialogueStrings;
    int DialogueIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartDialogue(){
        
    }

    void EndDialogue(){
        DialogueStrings.Clear();
        DialogueIndex=0;
        this.gameObject.SetActive(false);
    }
    void ShowDialogue(){
        Text.text=DialogueStrings[DialogueIndex];
        DialogueIndex++;
        if(DialogueIndex==DialogueStrings.Count){
            EndDialogue();
        }
    }
}
