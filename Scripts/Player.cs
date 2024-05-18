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
    [SerializeField] SpriteRenderer Sprite;


    [SerializeField] float Speed, h, v;
    [SerializeField] Direction Direction;

    [SerializeField] public List<Item> Items;
    [SerializeField] public Interactable Interact;
    [SerializeField] public bool Controllable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controllable)
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

            ChooseDirection();
            CheckFlip();
        }
    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(h, v) * Speed;
    }

    void ChooseDirection()
    {
        if (Mathf.Abs(h) > Mathf.Abs(v))
        {
            Direction = Direction.Side;
        }
        else if (v > 0)
        {
            Direction = Direction.Up;
        }
        else if (v < 0)
        {
            Direction = Direction.Down;
        }
    }

    void CheckFlip()
    {
        if (h > 0 == !Sprite.flipX && h!=0)
        {
            Sprite.flipX = !Sprite.flipX;
        }
    }

    public void ChangeControllable()
    {
        Controllable = !Controllable;
        if (!Controllable)
        {
            h = 0;
            v = 0;
        }
    }
}
