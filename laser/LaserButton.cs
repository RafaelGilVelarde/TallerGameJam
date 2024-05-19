using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public LaserTrap laserTrap;
    public Sprite buttonPressedSprite;
    public Sprite buttonUnpressedSprite;
    public AudioClip buttonPressSound;
    [SerializeField] float buttonPressVolume = 1.0f;

    private SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;
    public bool isPressed = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>(); 
        audioSource.volume = buttonPressVolume;
        UpdateButtonState();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box")){
            collision.transform.parent.gameObject.GetComponent<InteractableMovingBox>().ClickButton();
            if (!isPressed)
            {
                isPressed = true;
                if (laserTrap != null)
                {
                    laserTrap.ToggleLaser();
                }
                PlayButtonSound();
                UpdateButtonState();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Box")){
            isPressed = false;
            if (laserTrap != null)
            {
                laserTrap.ToggleLaser();
            }

            UpdateButtonState();
        }
    }

    void UpdateButtonState()
    {
        spriteRenderer.sprite = isPressed ? buttonPressedSprite : buttonUnpressedSprite;
    }

    void PlayButtonSound()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
