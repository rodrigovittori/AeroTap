using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avioncito : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float fuerzaImpulso;
    [SerializeField] GameManager gameManager;

    private bool avionEstrellado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !avionEstrellado)
            { rb.velocity = Vector2.up * fuerzaImpulso; }
        
        if ((transform.position.y > 6) || (transform.position.y < -6))
            { gameManager.gameOver(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstaculo"))
            { gameManager.aumentarPuntuacion(1); }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstaculo"))
            {
             avionEstrellado = true;
             gameManager.gameOver();
            }
    }
}
