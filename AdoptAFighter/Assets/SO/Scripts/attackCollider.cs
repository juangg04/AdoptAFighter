using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollider : MonoBehaviour
{
    [SerializeField] private AnimalStats enemy_Script;

    [SerializeField] private GameObject enemy_Count; //Recibe el dummy grid


    public void OnTriggerStay(Collider other) {
        enemy_Count = other.gameObject;

        if (other.gameObject.tag == "Animal"){
            Debug.Log("si");
            enemy_Script = other.gameObject.GetComponentInParent<AnimalStats>(); 
            if (Input.GetKeyDown(KeyCode.H)){
                Debug.Log("si2");
                enemy_Script.ataqueEncontrado = true;
            }
           
        }
    }
}

