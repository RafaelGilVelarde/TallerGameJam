using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public static ScreenTransition screenTransition;
    [SerializeField] Animator animator;
    public delegate void ChangeSignal();
    public ChangeSignal changeSignal;

    // Start is called before the first frame update

    private void Awake()
    {
        if (ScreenTransition.screenTransition == null)
        {
            screenTransition = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if(ScreenTransition.screenTransition != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Begin()
    {
        animator.SetTrigger("Start");
    }
    
    public void EmitChangeSignal()
    {
        changeSignal.Invoke();
    }
}
