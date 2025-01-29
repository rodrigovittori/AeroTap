using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] float velMovimiento = 3; // velocidad a la que se mueven los obstáculos

    void Update()
    {
        if (transform.position.x < -12) // Si el obstáculo salió de la pantalla...
            { Destroy(gameObject); }
        else
            { transform.position += ((Vector3.left * velMovimiento) * Time.deltaTime); }
    }
}
