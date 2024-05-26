using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimalStats : MonoBehaviour
{


    public bool ataqueEncontrado;

    private bool ataqueDone = false;

    public ScriptableObject enemyStats;

    [SerializeField] private FloatValueSO currentHealth;

    [SerializeField] private FloatValueSO defense;

    [SerializeField] private FloatValueSO turn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth.Value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ataqueEncontrado && !ataqueDone){
            damaged(1);
            ataqueEncontrado = false;
            ataqueDone = true;
        }


    }

    public void damaged(float damage){
        currentHealth.Value -= damage * defense.Value;
    }





}
