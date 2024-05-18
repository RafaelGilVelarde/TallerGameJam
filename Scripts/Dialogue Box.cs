using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] float TextSpeed;
    [SerializeField] public List<string> DialogueStrings;
    int DialogueIndex = -1;

    bool HasFinished;

    public static DialogueBox Dialogue;

    private void Awake() {
        Dialogue=this;      
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Player.player.InteractKey)){
            if(HasFinished){
                StartCoroutine("ShowDialogue");
            }
            else{
                Text.text=DialogueStrings[DialogueIndex];
                HasFinished=true;
                StopCoroutine("ShowDialogue");
            }
        }
    }
    public void StartDialogue(){
        Player.player.Controllable=false;
        transform.GetChild(0).gameObject.SetActive(true);
        this.enabled=true;
        StartCoroutine("ShowDialogue");
    }

    void EndDialogue(){
        Player.player.Controllable=true;
        DialogueStrings.Clear();
        DialogueIndex=-1;
        transform.GetChild(0).gameObject.SetActive(false);
        this.enabled=false;
    }
    IEnumerator ShowDialogue(){
        Text.text="";
        DialogueIndex++;
        if(DialogueIndex==DialogueStrings.Count){
            EndDialogue();
        }
        else{
            HasFinished=false;
            string aux=DialogueStrings[DialogueIndex];
            for(int i=0;i<aux.Length;i++){
                Text.text+=aux[i];
                yield return new WaitForSeconds(1/TextSpeed);
            }
            HasFinished=true;            
        }
    }
}
