using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadoMuerto : Estado
{
    private TurnManager manager;
    [SerializeField] private Image image;
    [SerializeField]Sprite sprite;
    HealthSystem healthSystem;

    protected override void Awake()
    {
        base.Awake();
        //LOGICA AL INICIAR PRIMERA VEZ
        manager = GameObject.Find("GameManager").GetComponent<TurnManager>();


    }

    void Update()
    {
        //LOGICA DE ESPERA


    }

    // Método llamado cuando el estado se activa.
    void OnEnable()
    {
        image.sprite = sprite;
        gameObject.SetActive(false);
        manager.Murio(gameObject);
        //character.changeMovedata();
        //COSAS QUE HACER CCUANDO SE ACTIVE EL ESTADO
        //maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta); // Cambia al estado de alerta.
    }
}
