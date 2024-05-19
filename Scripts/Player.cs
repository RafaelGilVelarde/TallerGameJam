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
    [SerializeField] SpriteRenderer Sprite;


    [SerializeField] float Speed, h, v;
    [SerializeField] bool Moving;
    [SerializeField] Direction Direction;

    [SerializeField] public KeyCode InteractKey;
    [SerializeField] public List<Item> Items;
    [SerializeField] public Interactable Interact;
    [SerializeField] public bool Controllable;
    [SerializeField] Collider2D  InteractCollider;
    [SerializeField] Collider2D Hitbox;
    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        player=this;
    }
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
            Animator.SetBool("Moving",Moving);

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

        if(new Vector2(h,v)==Vector2.zero){
            Moving=true;
        }else{
            Moving=false;
        }
    }

    void CheckFlip()
    {
        if (h < 0 == (transform.parent.localScale.x==1) && h!=0)
        {
            
            float positionX = transform.parent.localScale.x*-1;
            transform.parent.localScale=new Vector2(positionX,transform.parent.localScale.y);
        }
    }

    public void ChangeControllable()
    {
        Controllable = !Controllable;
        if (!Controllable)
        {
            Hitbox.enabled=false;
            h = 0;
            v = 0;
        }
        else{
            Hitbox.enabled=true;
        }
    }
    public void Die(){
        ChangeControllable();
        ScreenTransition.screenTransition.Begin();
    }
}
