using UnityEngine;
using System.Collections;

public class Estado : MonoBehaviour {

    public Color ColorEstado; // Color asociado a este estado.

    protected MaquinaDeEstados maquinaDeEstados; // Referencia a la máquina de estados a la que pertenece este estado.

    // Método Awake, se ejecuta cuando se inicializa el objeto.
    protected virtual void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>(); // Obtenemos la referencia a la máquina de estados del objeto al que está adjunto este script.
    }

}
