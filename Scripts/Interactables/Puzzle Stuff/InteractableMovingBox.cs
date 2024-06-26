using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class InteractableMovingBox : Interactable
{
    Vector2 Direction;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Collider2D Collider;
    [SerializeField] float Speed;
    [SerializeField] public bool ClickedButton;
    [SerializeField] LayerMask ObstacleMask;
    Vector2 OriginPosition;

    void Start()
    {
        OriginPosition=transform.position;
        ScreenTransition.screenTransition.changeSignal+=OnRoomExit;
    }
    public override void Interact(Player player){
        if(!ClickedButton){
            Rb.bodyType=RigidbodyType2D.Kinematic;
            Rb.gravityScale=0;
            Rb.constraints=RigidbodyConstraints2D.FreezeRotation;
            if(Mathf.Abs(player.transform.parent.position.x-transform.position.x)>Mathf.Abs(player.transform.parent.position.y-transform.position.y)){
                if(player.transform.parent.position.x-transform.position.x>0){
                    Direction=Vector2.left;
                }
                else{
                    Direction=Vector2.right;
                }
            }
            else{
                if(player.transform.parent.position.y-transform.position.y>0){
                    Direction=Vector2.down;
                }
                else{
                    Direction=Vector2.up;
                }            
            }
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch(Rb.bodyType){
            case RigidbodyType2D.Kinematic:
                Rb.velocity=Direction*Speed;
                RaycastHit2D Hit=Physics2D.Raycast(transform.position,Direction,(Direction*Collider.bounds.extents).magnitude, ObstacleMask);
                if(Hit){
                    Direction=Vector2.zero;
                    Rb.bodyType=RigidbodyType2D.Static;
                }
            break;
        }
    }

    public void ClickButton(){
        ClickedButton=true;
        Rb.bodyType=RigidbodyType2D.Static;
    }

    public void OnRoomExit(){
        if(!ClickedButton){
            Rb.bodyType=RigidbodyType2D.Static;
            transform.position=OriginPosition;
        }
    }
}
