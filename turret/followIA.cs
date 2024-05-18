using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class followIA : MonoBehaviour
{
    [SerializeField] private Transform player; //Astronauta

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteRight;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
    }
}
