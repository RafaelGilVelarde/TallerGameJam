using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{

    public Sprite spriteOn;
    public Sprite spriteOff;
    public bool isOn = true;

    public AudioClip laserSound;//Sonido
    public float volume = 1.0f;


    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        audioSource.clip = laserSound;
        audioSource.loop = true; // Hacer que el sonido se reproduzca en bucle
        audioSource.volume = volume; // Configura el volumen del sonido
        UpdateLaserState();
    }

    public void ToggleLaser()
    {
        isOn = !isOn;
        UpdateLaserState();

        collider2D.enabled = isOn;

        if (isOn)
        {
            audioSource.Play(); 
        }
        else
        {
            audioSource.Stop(); 
        }
    }

    void UpdateLaserState()
    {
        spriteRenderer.sprite = isOn ? spriteOn : spriteOff;
    }

    void OnTriggerEnter2D(Collider2D other)//Cuando el colisione con el laser prendido
    {
        if (other.CompareTag("Player"))//tag del jugador
        {
            Player.player.Die();
        }
    }

}
