using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    #region Datos

    [SerializeField] private Button attackButton;

    public GameObject tagTeam;
    public List<GameObject> cercanos = new List<GameObject>();
    public bool Moving { get; private set; } = false;
    public bool isMoving { get; set; } = false;

    public CharacterMoveData movedata;
    public CharacterMoveData waitdata;
    public CharacterMoveData moverdata;
    public Tile characterTile;
    [SerializeField]
    LayerMask GroundLayerMask;

    private bool isSelectingTarget = false;
    private EstadoAtacar estadoAtacar;
    #endregion

    private void Awake()
    {
        FindTileAtStart();
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        estadoAtacar = GetComponent<EstadoAtacar>();
    }

    void FindTileAtStart()
    {
        if (characterTile != null)
        {
            FinalizePosition(characterTile);
            return;
        }

        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 50f, GroundLayerMask))
        {
            FinalizePosition(hit.transform.GetComponent<Tile>());
            return;
        }

        Debug.Log("Unable to find a start position");
    }

    IEnumerator MoveThroughPath(Path path)
    {
        int step = 0;
        int pathlength = Mathf.Clamp(path.tilesInPath.Length, 0, movedata.MaxMove + 1);
        Tile currentTile = path.tilesInPath[0];
        float animationtime = 0f;
        const float minimumistanceFromNextTile = 0.05f;

        while (step < pathlength)
        {
            yield return null;
            Vector3 nextTilePosition = path.tilesInPath[step].transform.position;

            MoveAndRotate(currentTile.transform.position, nextTilePosition, animationtime / movedata.MoveSpeed);
            animationtime += Time.deltaTime;

            if (Vector3.Distance(transform.position, nextTilePosition) > minimumistanceFromNextTile)
            {
                continue;
            }

            currentTile = path.tilesInPath[step];
            step++;
            animationtime = 0f;
        }

        isMoving = true;

        FinalizePosition(path.tilesInPath[pathlength - 1]);
    }

    public void Move(Path _path)
    {
        Moving = true;
        characterTile.Occupied = false;
        StartCoroutine(MoveThroughPath(_path));
    }

    void FinalizePosition(Tile tile)
    {
        transform.position = tile.transform.position;
        characterTile = tile;
        Moving = false;
        tile.Occupied = true;
        tile.occupyingCharacter = this;
    }

    void MoveAndRotate(Vector3 origin, Vector3 destination, float duration)
    {
        transform.position = Vector3.Lerp(origin, destination, duration);
        transform.rotation = Quaternion.LookRotation(origin.DirectionTo(destination).Flat(), Vector3.up);
    }

    public void changeMovedata()
    {
        movedata = moverdata;
    }

    public void ChangeWaitData()
    {
        movedata = waitdata;
    }

    void OnTriggerEnter(Collider other)
    {
        if (attackButton == null)
        {
            Debug.LogError("attackButton no está asignado.");
            return; // Salir temprano si attackButton es null
        }

        if (other.CompareTag("Player"))
        {
            if (other.gameObject.transform.GetChild(0).gameObject.tag == tagTeam.tag)
            {
                Debug.Log("Mismo Equipo");
            }
            else
            {
                cercanos.Add(other.gameObject);
                attackButton.gameObject.SetActive(true);
                Debug.Log("ENTRO EN COLISION");
            }
        }
    }

    void OnAttackButtonClicked()
    {
        if (cercanos.Count > 0)
        {
            estadoAtacar.enabled = true;
            isSelectingTarget = true;
            Debug.Log("Selecciona un objetivo para atacar.");
        }
        else
        {
            Debug.Log("No hay enemigos cercanos para atacar.");
        }
    }

    void Update()
    {
        if (isSelectingTarget && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (cercanos.Contains(hit.collider.gameObject))
                {
                    AttackEnemy(hit.collider.gameObject);
                    isSelectingTarget = false;
                    estadoAtacar.enabled = false;
                    Debug.Log("b");
                }
            }
        }
    }

    void AttackEnemy(GameObject enemy)
    {
        // Lógica para atacar al enemigo seleccionado
        enemy.GetComponent<HealthSystem>().TakeDamage(100);
        Debug.Log($"Atacando a {enemy.name}");
    }
}
