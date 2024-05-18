using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    [SerializeField] Animator Animator;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] KeyCode InteractKey;


    [SerializeField] float Speed, h, v;

    [SerializeField] public List<Item> Items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(h, v) * Speed;
    }
}
