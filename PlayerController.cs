using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody del jugador
    private Rigidbody rb; 

    // Movimiento a lo largo de los ejes X y Y.
    private float movementX;
    private float movementY;

    // Velocidad a la que se mueve el jugador.
    public float speed = 0;
    
    // Variable para llevar el seguimiento de los objetos "PickUp" recolectados.
    private int count;
    
    // Componente de texto UI para mostrar el contador de objetos "PickUp" recolectados.
    public TextMeshProUGUI countText;
    
    // Objeto UI para mostrar el texto de victoria.
    public GameObject winTextObject;

    // Start se llama antes de la primera actualización de fotograma.
    void Start()
    {
        // Obtén y almacena el componente Rigidbody adjunto al jugador.
        rb = GetComponent<Rigidbody>();
        // Cambiar masa del jugador
        rb.mass = 2f;
        
        count = 0;
        SetCountText();
        // Inicialmente, desactiva el texto de victoria.
        winTextObject.SetActive(false);
    }
 
    // Esta función se llama cuando se detecta una entrada de movimiento.
    void OnMove(InputValue movementValue)
    {
        // Convierte el valor de entrada en un Vector2 para el movimiento.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Almacena los componentes X e Y del movimiento.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

	

    // FixedUpdate se llama una vez por fotograma de velocidad fija.
    private void FixedUpdate() 
    {
        // Crea un vector de movimiento 3D utilizando las entradas X y Y.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        // Aplica fuerza al Rigidbody para mover al jugador.
        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó el jugador tiene la etiqueta "PickUp".
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Desactiva el objeto colisionado (haciéndolo desaparecer).
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    // Función para actualizar el contador de objetos "PickUp" recolectados.
    void SetCountText() 
    {
        // Actualiza el texto del contador con el contador actual.
        countText.text = "Count: " + count.ToString();
        
        // Verifica si el contador ha alcanzado o superado la condición de victoria.
        if (count >= 8)
        {
            // Muestra el texto de victoria.
            winTextObject.SetActive(true);
        }
    }

	// Método llamado cuando se activa el evento "Fire" configurado en el Input System.
	void OnFire()
	{
		rb.AddForce(Vector3.up * 8.0f, ForceMode.Impulse);
		Debug.Log("OnFire() llamado");
	}
}