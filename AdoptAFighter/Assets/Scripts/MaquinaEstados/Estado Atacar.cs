using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadoAtacar : Estado
{
    private Character character;
    private Tile currentTile;
    private Interact interact;
    [SerializeField] private Button atackButton;
    HealthSystem healthSystem;

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
        atackButton.gameObject.SetActive(false);
        character.cercano.GetComponent<HealthSystem>().TakeDamage(100);
        //character.changeMovedata();
        //COSAS QUE HACER CCUANDO SE ACTIVE EL ESTADO
        //maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta); // Cambia al estado de alerta.
    }


}
