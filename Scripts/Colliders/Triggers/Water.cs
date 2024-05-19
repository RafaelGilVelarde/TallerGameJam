using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour{
void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("PlayerHitbox")){
        if(other.transform.parent.GetComponent<Player>().Controllable){
                other.transform.parent.GetComponent<Player>().Die();
            }
    }
}
}
