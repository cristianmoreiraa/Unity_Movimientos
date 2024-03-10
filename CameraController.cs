using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referencia al GameObject del jugador.
    public GameObject player;

    // La distancia entre la cámara y el jugador.
    private Vector3 offset;

    // Start se llama antes de la primera actualización de fotograma.
    void Start()
    {
        // Calcula el desplazamiento incial de la camara desde la posicion del jugador
        offset = transform.position - player.transform.position;
        
        /*
        // Asegura que la cámara mire en la misma dirección que el jugador
        transform.rotation = player.transform.rotation;
        */
    }

    // LateUpdate se llama una vez por fotograma después de que se han completado todas las funciones de actualización.
    void LateUpdate()
    {
        // Mueve la cámara a la posición de los ojos del jugador
        transform.position = player.transform.position + offset;
        
        /*
        // Asegura que la cámara mire en la misma dirección que el jugador
        transform.rotation = player.transform.rotation;
        */
    }
}