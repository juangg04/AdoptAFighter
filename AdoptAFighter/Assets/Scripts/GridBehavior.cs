using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    public bool encontrarDistancia = false;
    public int filas = 10;
    public int columnas = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBotomLocation = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int movX = 5;
    public int movY = 7;
    public List<GameObject> path = new List<GameObject>();
    public GameObject Personaje1;
    public GameObject Personaje2;
    public int Personaje = 0;
    public ControlRaton control;

    void Awake()
    {
        gridArray = new GameObject[columnas, filas];
        GenerarGrid();

        GameObject startCell = gridArray[startX, startY];

        if (startCell != null)
        {
            Vector3 startPosition = startCell.transform.position;
            startPosition.y += 1.0f;
            Personaje1.transform.position = startPosition;
            Personaje2.transform.position = startPosition;
        }
        else
        {
            Debug.LogError("No se pudo encontrar la casilla de inicio en las coordenadas especificadas.");
        }
    }

    void Update()
    {
        if (encontrarDistancia)
        {
            Distancia();
            SetPath();
            encontrarDistancia = false;
        }
    }

    void GenerarGrid()
    {
        for (int i = 0; i < columnas; i++)
        {
            for (int j = 0; j < filas; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(leftBotomLocation.x + scale * i, leftBotomLocation.y, leftBotomLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x = i;
                obj.GetComponent<GridStat>().y = j;
                gridArray[i, j] = obj;
            }
        }
    }

    void SetUp()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridStat>().visited = 0;
    }

    bool Comprobardirecion(int x, int y, int paso, int direccion)
    {
        switch (direccion)
        {
            case 1:
                if (y + 1 < filas && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited == paso)
                    return true;
                else
                    return false;
            case 2:
                if (x + 1 < columnas && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == paso)
                    return true;
                else
                    return false;
            case 3:
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited == paso)
                    return true;
                else
                    return false;
            case 4:
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<GridStat>().visited == paso)
                    return true;
                else
                    return false;
        }
        return false;
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    void Visitado(int x, int y, int paso)
    {
        if (gridArray[x, y])
            gridArray[x, y].GetComponent<GridStat>().visited = paso;
    }

<<<<<<< Updated upstream
=======
    bool Ocupado(int x, int y)
    {
        if (gridArray[x, y])
        {
            return gridArray[x, y].GetComponent<GridStat>().Ocupada;
        }
        return false;
    }

    public void TestOcupadoAdyacente(int x, int y, bool ocupado, GameObject enemigo)
    {
        if (Ocupado(x - 1, y + 1))
        {
            ocupado = true;
            enemigo = gridArray[x - 1, y + 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x, y + 1))
        {
            ocupado = true;
            enemigo = gridArray[x, y + 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x + 1, y + 1))
        {
            ocupado = true;
            enemigo = gridArray[x + 1, y + 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x + 1, y))
        {
            ocupado = true;
            enemigo = gridArray[x + 1, y].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x + 1, y - 1))
        {
            ocupado = true;
            enemigo = gridArray[x + 1, y - 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x, y - 1))
        {
            ocupado = true;
            enemigo = gridArray[x, y - 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x - 1, y - 1))
        {
            ocupado = true;
            enemigo = gridArray[x - 1, y - 1].GetComponent<GridStat>().personaje;
        }
        if (Ocupado(x - 1, y))
        {
            ocupado = true;
            enemigo = gridArray[x - 1, y].GetComponent<GridStat>().personaje;
        }
        ocupado = false;
        enemigo = null;
    }
>>>>>>> Stashed changes

    void Distancia()
    {
        SetUp();
        int x = startX;
        int y = startY;
        int[] testArray = new int[filas * columnas];
        for (int paso = 1; paso <= filas * columnas; paso++)
        {
            foreach (GameObject obj in gridArray)
            {
                if (obj && obj.GetComponent<GridStat>().visited == paso - 1)
                    Test4Direcciones(obj.GetComponent<GridStat>().x, obj.GetComponent<GridStat>().y, paso);
            }
        }
    }

    void Test4Direcciones(int x, int y, int paso)
    {
        if (Comprobardirecion(x, y, -1, 1))
        {
            Visitado(x, y + 1, paso);
        }

        if (Comprobardirecion(x, y, -1, 2))
        {
            Visitado(x + 1, y, paso);
        }

        if (Comprobardirecion(x, y, -1, 3))
        {
            Visitado(x, y - 1, paso);
        }

        if (Comprobardirecion(x, y, -1, 4))
        {
            Visitado(x - 1, y, paso);
        }
    }

    void SetPath()
    {
        int paso = 0;
        int x = movX;
        int y = movY;
        List<GameObject> tempList = new List<GameObject>();
        path.Clear();

        // Verifica si la celda objetivo es alcanzable
<<<<<<< Updated upstream
        if (gridArray[movX, movY] && gridArray[movX, movY].GetComponent<GridStat>().visited > 0)
=======
        GridStat targetCellStat = gridArray[movX, movY].GetComponent<GridStat>();
        if (gridArray[movX, movY] && targetCellStat.visited > 0 && !targetCellStat.Ocupada && targetCellStat.movimientoalcanzable)
>>>>>>> Stashed changes
        {
            path.Add(gridArray[x, y]);
            paso = targetCellStat.visited - 1;
        }
        else
        {
<<<<<<< Updated upstream
            print("No se puede alcanzar esa localización");
            return; // Salir de la función si no se puede alcanzar
=======
            control.movible = true;
            Debug.Log("No se puede alcanzar esa localizaciÃ³n. Estado - Visited: " + targetCellStat.visited + ", Ocupada: " + targetCellStat.Ocupada + ", Alcanzable: " + targetCellStat.movimientoalcanzable);
            return; // Salir de la funciÃ³n si no se puede alcanzar
>>>>>>> Stashed changes
        }

        // Recorre desde el objetivo hasta el inicio
        while (paso >= 0)
        {
            if (Comprobardirecion(x, y, paso, 1))
            {
                tempList.Add(gridArray[x, y + 1]);
            }
            if (Comprobardirecion(x, y, paso, 2))
            {
                tempList.Add(gridArray[x + 1, y]);
            }
            if (Comprobardirecion(x, y, paso, 3))
            {
                tempList.Add(gridArray[x, y - 1]);
            }
            if (Comprobardirecion(x, y, paso, 4))
            {
                tempList.Add(gridArray[x - 1, y]);
            }

            if (tempList.Count > 0)
            {
                GameObject tempObj = EncontrarMasCercano(gridArray[x, y].transform, tempList);
                path.Add(tempObj);
                x = tempObj.GetComponent<GridStat>().x;
                y = tempObj.GetComponent<GridStat>().y;
                tempList.Clear();
                paso--;
            }
            else
            {
                Debug.Log("Ruta no encontrada correctamente");
                break;
            }
        }

        // Mueve al personaje seleccionado a la celda objetivo
        Vector3 targetPosition = gridArray[movX, movY].transform.position;
        switch (Personaje)
        {
<<<<<<< Updated upstream
            Personaje1.GetComponent<MovimientoPersonaje>().SetTargetPosition(gridArray[movX, movY].transform.position);
        }
        if (Personaje == 2)
        {
            Personaje2.GetComponent<MovimientoPersonaje>().SetTargetPosition(gridArray[movX, movY].transform.position);
=======
            case 1:
                Personaje1.GetComponent<MovimientoPersonaje>().SetTargetPosition(targetPosition);
                break;
            case 2:
                Personaje2.GetComponent<MovimientoPersonaje>().SetTargetPosition(targetPosition);
                break;
            case 3:
                Personaje3.GetComponent<MovimientoPersonaje>().SetTargetPosition(targetPosition);
                break;
            case 4:
                Personaje4.GetComponent<MovimientoPersonaje>().SetTargetPosition(targetPosition);
                break;
            default:
                Debug.LogError("Personaje no vÃ¡lido seleccionado");
                break;
>>>>>>> Stashed changes
        }
    }

    GameObject EncontrarMasCercano(Transform targetlocation, List<GameObject> list)
    {
        float distanciaActual = scale * filas * columnas;
        int Numero = 0;
        for (int i = 0; i < list.Count; i++)
        {
            float distancia = Vector3.Distance(targetlocation.position, list[i].transform.position);
            if (distancia < distanciaActual)
            {
                distanciaActual = distancia;
                Numero = i;
            }
        }
        return list[Numero];
    }
}
