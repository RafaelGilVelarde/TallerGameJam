using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    [SerializeField] private float speed;
    private Transform player; 
    private Rigidbody2D rb;

 
    void Start()
    {
        player = FindObjectOfType<Player>().transform; //busca la clase jugador, cambiar cuando se asocie
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        Vector2 direccionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = direccionToPlayer * speed;
        StartCoroutine(DestroyProyectile());
    }

    IEnumerator DestroyProyectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }


}
