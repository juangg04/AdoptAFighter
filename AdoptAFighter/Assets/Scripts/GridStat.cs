using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;
    public GameObject personaje;
    public bool Ocupada = false;
    public bool movimientoalcanzable = false; 
    void Start()
    {
        // Inicializa cualquier cosa adicional aqu� si es necesario.
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto colisionado es del tipo MovimientoPersonaje
        MovimientoPersonaje movimientoPersonaje = other.GetComponent<MovimientoPersonaje>();
        if (movimientoPersonaje != null)
        {
            personaje = other.gameObject;
            Ocupada = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto colisionado es del tipo MovimientoPersonaje
        MovimientoPersonaje movimientoPersonaje = other.GetComponent<MovimientoPersonaje>();
        if (movimientoPersonaje != null)
        {
            personaje = null;
            Ocupada = false;
        }
    }
}
