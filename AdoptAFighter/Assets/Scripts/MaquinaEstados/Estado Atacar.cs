using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadoAtacar : Estado
{
    private Character character;
    [SerializeField] private Button attackButton;

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
        attackButton.gameObject.SetActive(true);
        Debug.Log("a");
    }

    void OnDisable()
    {
        attackButton.gameObject.SetActive(false);   
    }
}
