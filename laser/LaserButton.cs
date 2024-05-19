using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public LaserTrap laserTrap;
    public Sprite buttonPressedSprite;
    public Sprite buttonUnpressedSprite;

    private SpriteRenderer spriteRenderer;
    public bool isPressed = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateButtonState();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPressed)
        {
            isPressed = true;
            if (laserTrap != null)
            {
                laserTrap.ToggleLaser();
            }

            UpdateButtonState();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isPressed = false;
        if (laserTrap != null)
        {
            laserTrap.ToggleLaser();
        }

        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        spriteRenderer.sprite = isPressed ? buttonPressedSprite : buttonUnpressedSprite;
    }
}
