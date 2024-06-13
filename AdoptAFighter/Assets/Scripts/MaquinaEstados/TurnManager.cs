using System;
using System.Collections;
    using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{


    [SerializeField] private GameObject endText;

    private int totalAnimals = 4;

    private int team1Animals = 0;
    private int team2Animals = 0;

    public GameObject[] players;
    private int currentPlayerIndex = 0;
    protected MaquinaDeEstados maquinaDeEstados;
    void Start()
    {
        StartTurn();

    }

    void StartTurn()
    {
        // Activate current player
        maquinaDeEstados = players[currentPlayerIndex].GetComponent<MaquinaDeEstados>();
        maquinaDeEstados.ActivarEstado(maquinaDeEstados.Jugar);

    }

    public void EndTurn()
    {
        Debug.Log("Players: "+currentPlayerIndex);

        // PASA A ESTADO DE ESPERA
        maquinaDeEstados.ActivarEstado(maquinaDeEstados.Esperar);

        if (currentPlayerIndex < players.Length) {
            players[currentPlayerIndex].GetComponent<SphereCollider>().enabled = false;
        } else {
            currentPlayerIndex = 0; // Reiniciar el índice si es mayor o igual a la longitud de players
        }

        players[currentPlayerIndex].GetComponent<SphereCollider>().enabled = false;
        // Move to next player
        currentPlayerIndex = (currentPlayerIndex + 1) < players.Length ? (currentPlayerIndex + 1) : 0;


        foreach(GameObject player in players){
           if(player.transform.GetChild(0).gameObject.tag == "Team1"){
             team1Animals++;
           }
           if(player.transform.GetChild(0).gameObject.tag == "Team2"){
             team2Animals++;
           }
        }


        Debug.Log(team1Animals);
        Debug.Log(team2Animals);
        if ((team1Animals == 0 || team2Animals == 0 ) || (totalAnimals <=1)){
            endText.SetActive(true);
        }
        else{
        // Start next turn
        team1Animals = 0;
        team2Animals = 0;
        StartTurn();
        }

    }

    public void MoveTurn()
    {
        // PASA A ESTADO DE Moverse
        maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMoverse);
    }
    public void AtackTurn()
    {
        // PASA A ESTADO DE Moverse
        maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtacar);
    }

    public void Murio(GameObject current)
    {
        Debug.Log("ENTRA EN LA MUERTE DE:" + (currentPlayerIndex-1));
        List<GameObject> playersList = new List<GameObject>(players);

        // Eliminar el GameObject deseado de la lista
        playersList.Remove(current);

        // Convertir la lista de vuelta a un arreglo
        players = playersList.ToArray();

       
    }
}