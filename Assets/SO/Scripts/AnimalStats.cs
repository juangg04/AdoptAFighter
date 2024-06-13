using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalStats : MonoBehaviour
{
    private bool encontrado = false;

    private GameObject enemy;
     public GameObject personaje;


    //[SerializeField] private FloatValueSO turno;
    [SerializeField] private GridBehavior gridInfo;

    [SerializeField] private FloatValueSO currentHealth;

    [SerializeField] private FloatValueSO defense;

    [SerializeField] private FloatValueSO turn;

    public GameObject text_Enemy_notFound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth.Value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            damaged(0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Q)){

            switch(turn.Value){
                case 1:
                    foreach (GameObject obj in gridInfo.gridArray){
                        if ( obj.GetComponent<GridStat>().Ocupada ){
                            Debug.Log("si1");
                            if (obj.GetComponent<GridStat>().personaje.tag == "Animal1"){
                                Debug.Log("si2");
                                Debug.Log(obj.GetComponent<GridStat>().x);
                                Debug.Log(obj.GetComponent<GridStat>().y);
                                gridInfo.TestOcupadoAdyacente(obj.GetComponent<GridStat>().x,obj.GetComponent<GridStat>().y,encontrado,enemy);
                                if (encontrado){
                                    Debug.Log("enemigo encontrado");
                                    break;
                                }
                            }
                        }
                    } 
                

                break;
                case 2:
                    foreach (GameObject obj in gridInfo.gridArray){
                        if ( obj.GetComponent<GridStat>().personaje != null  ){
                            Debug.Log("si1");
                            if (obj.GetComponent<GridStat>().personaje.tag == "Animal2"){
                                Debug.Log("si2");
                                Debug.Log(obj.GetComponent<GridStat>().x);
                                Debug.Log(obj.GetComponent<GridStat>().y);

                            }
                        }
                    } 

                break;
                case 3:
                    foreach (GameObject obj in gridInfo.gridArray){
                        if ( obj.GetComponent<GridStat>().personaje != null  ){
                            Debug.Log("si1");
                            if (obj.GetComponent<GridStat>().personaje.tag == "Animal3"){
                                Debug.Log("si2");
                                Debug.Log(obj.GetComponent<GridStat>().x);
                                Debug.Log(obj.GetComponent<GridStat>().y);
                            }
                        }
                    } 

                break;
                case 4:
                    foreach (GameObject obj in gridInfo.gridArray){
                        if ( obj.GetComponent<GridStat>().personaje != null  ){
                            Debug.Log("si1");
                            if (obj.GetComponent<GridStat>().personaje.tag == "Animal4"){
                                Debug.Log("si2");
                                Debug.Log(obj.GetComponent<GridStat>().x);
                                Debug.Log(obj.GetComponent<GridStat>().y);
                            }
                        }
                    } 

                break;
                default:
                Debug.Log("Turno Nadie");
                break;
            }
        }
    }


    public void meleeAttack(){
        enemy.GetComponentInParent<AnimalStats>().currentHealth.Value -= 20 * enemy.GetComponentInParent<AnimalStats>().defense.Value; 
    }

    public void damaged(float damage){
        currentHealth.Value -= damage * defense.Value;
    }




}
