using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStat : MonoBehaviour
{
    // Start is called before the first frame update
    public int visited = -1;
    public int x = 0;
    public int y = 0;
    public GameObject personaje;
    public bool Ocupada = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        personaje = other.gameObject;
        Ocupada = true;
    }

    private void OnTriggerExit(Collider personaje)
    {
        personaje = null;
        Ocupada = false;
    }
}
