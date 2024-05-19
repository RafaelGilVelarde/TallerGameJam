using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] List<Sprite> Sprites;

    [SerializeField] KeyCode InputKey;

    [SerializeField] int Index=0, NextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(InputKey)){
            NextSlide();
        }
    }

    void NextSlide(){
        if(Index<Sprites.Count-1){
            Index++;
            image.sprite=Sprites[Index];
        }
        else{
            SceneManager.LoadScene(NextScene);
        }
    }

}
