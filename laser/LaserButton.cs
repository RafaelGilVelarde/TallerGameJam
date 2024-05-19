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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Button: "+collision);
        if(collision.CompareTag("Box")){
            collision.transform.parent.gameObject.GetComponent<InteractableMovingBox>().ClickButton();
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
}
