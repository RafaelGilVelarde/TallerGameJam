using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{

    public Sprite spriteOn;
    public Sprite spriteOff;
    public bool isOn = true;


    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        UpdateLaserState();
    }

    public void ToggleLaser()
    {
        isOn = !isOn;
        UpdateLaserState();

        collider2D.enabled = isOn;
    }

    void UpdateLaserState()
    {
        spriteRenderer.sprite = isOn ? spriteOn : spriteOff;
    }

    void OnTriggerEnter2D(Collider2D other)//Cuando el colisione con el laser prendido
    {
        if (other.CompareTag("Player"))//tag del jugador
        {
            Debug.Log("Colision laser");
        }
    }

}
