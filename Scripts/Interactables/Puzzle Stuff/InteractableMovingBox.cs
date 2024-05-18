using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMovingBox : Interactable
{
    Vector2 Direction;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] float Speed;
    public override void Interact(Player player){
        if(Mathf.Abs(player.transform.parent.position.x-transform.position.x)>Mathf.Abs(player.transform.parent.position.y-transform.position.y)){
            if(player.transform.parent.position.x-transform.position.x>0){
                Direction=Vector2.right;
            }
            else{
                Direction=Vector2.left;
            }
        }
        else{
            if(player.transform.parent.position.y-transform.position.y>0){
                Direction=Vector2.up;
            }
            else{
                Direction=Vector2.down;
            }            
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Rb.velocity=Direction*Speed;
    }
}
