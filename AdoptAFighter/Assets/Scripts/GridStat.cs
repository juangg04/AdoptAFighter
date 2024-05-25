using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;
<<<<<<< Updated upstream
=======
    public GameObject personaje;
    public bool Ocupada = false;
    public bool movimientoalcanzable = true; // Asegúrate de que esta propiedad se inicializa correctamente.

>>>>>>> Stashed changes
    void Start()
    {
        // Inicializa cualquier cosa adicional aquí si es necesario.
    }
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
}
