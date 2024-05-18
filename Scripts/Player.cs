using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Side
}

public class Player : MonoBehaviour
{
    public static Player player;

    [SerializeField] Animator Animator;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] KeyCode InteractKey;


    [SerializeField] float Speed, h, v;
    [SerializeField] Direction Direction;

    [SerializeField] public List<Item> Items;
    [SerializeField] public Interactable Interact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Animator.SetInteger("Dir",(int)Direction);
        if (Input.GetKeyDown(InteractKey)){
            if (Interact != null)
            {
                Interact.Interact(this);
            }
        }
    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(h, v) * Speed;
    }
}
