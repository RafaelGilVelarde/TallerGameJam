using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public enum TurretState{
    Idle,
    Shoot
}
public class followIA : MonoBehaviour
{
    [SerializeField] private Transform player; //Astronauta

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteRight;
    private SpriteRenderer spriteRenderer;
    public TurretState turretState;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player=Player.player.transform;
    }

    void Update()
    {
        switch(turretState){
            case TurretState.Idle:
            break;

            case TurretState.Shoot:
                Vector2 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                if (angle > -45 && angle <= 45)
                {// Derecha
                    spriteRenderer.sprite = spriteRight;
                    spriteRenderer.flipX = false;
                }
                else if (angle > 45 && angle <= 135)
                {// Arriba
                    spriteRenderer.sprite = spriteUp; 
                }
                else if (angle > -135 && angle <= -45)
                {// Abajo
                    spriteRenderer.sprite = spriteDown; 
                }
                else
                {// Izquierda
                    spriteRenderer.sprite = spriteRight;
                    spriteRenderer.flipX = true;
                }
            break;
        }
    }
}
