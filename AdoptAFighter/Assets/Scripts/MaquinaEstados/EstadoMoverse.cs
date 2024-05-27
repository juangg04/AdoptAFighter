using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadoMoverse : Estado
{
    private Character character;
    private int contadorMoves =0;
    [SerializeField] private Button button;
    private SphereCollider sphereCollider;


    protected override void Awake()
    {
        base.Awake();
        //LOGICA AL INICIAR PRIMERA VEZ
        character = GetComponent<Character>();
        character.changeMovedata();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {

        //LOGICA DE ESPERA
        if(character.isMoving)
        {
            button.gameObject.SetActive(false);
            character.ChangeWaitData();
            character.isMoving = false;
            Debug.Log("Entro: " + contadorMoves);
        }

        

    }

    // Método llamado cuando el estado se activa.
    void OnEnable()
    {
        sphereCollider.enabled = true;
        character.changeMovedata();
        contadorMoves++;
        //COSAS QUE HACER CCUANDO SE ACTIVE EL ESTADO
        //maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta); // Cambia al estado de alerta.
    }
}
