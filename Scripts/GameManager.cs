using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject obstaculo; // prefab de nuestro obstáculo
    [SerializeField] float spawnRate = 2;
    [SerializeField] float variacionAltura = 2;
    private float timer = 0; // tiempo (en segs) desde el último obstáculo spawneado
    public int puntuacion = 0;
    [SerializeField] TMP_Text txtPuntuacion;
    [SerializeField] GameObject gameOverScreen;

    void Start()
        { crearObstaculo(); } // Spawneamos primer obstáculo

    void Update()
    {
        if (timer > spawnRate)
            {
             crearObstaculo();   // Spawneamos nuevo obstáculo
             timer -= spawnRate; // Reseteamos timer
            }
        
        else
            { timer += Time.deltaTime; } // actualizar el timer
    }

    public void crearObstaculo()
    {
        Instantiate(
                    obstaculo,         // prefab a clonar
                    new Vector3((      // posición de spawn nuevo obstáculo 
                                 transform.position.x + 12),
                                 Random.Range(-variacionAltura, variacionAltura),
                                 0
                               ), // pos spawn
                    transform.rotation // rotacion del clon
                    );
    }

    public void aumentarPuntuacion(int puntos)
        { 
            puntuacion += puntos;
            txtPuntuacion.text = puntuacion.ToString();
        }

    public void reiniciarJuego()
        { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    
    public void gameOver()
        { gameOverScreen.SetActive(true); }
}