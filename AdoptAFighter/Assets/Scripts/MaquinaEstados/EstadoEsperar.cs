using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoEsperar : Estado
{
   private Character character;

    protected override void Awake()
    {
        base.Awake();
        //LOGICA AL INICIAR PRIMERA VEZ
        character = GetComponent<Character>();
    }

    void Update()
    {
        //LOGICA DE ESPERA


    }

    // Método llamado cuando el estado se activa.
    void OnEnable()
    {
        character.ChangeWaitData();
        //COSAS QUE HACER CCUANDO SE ACTIVE EL ESTADO
        //maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta); // Cambia al estado de alerta.
    }



}
