using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public int CancionRandom = 0;
    public AudioSource cancion1;
    public AudioSource cancion2;
    public AudioSource cancion3;
    public AudioSource cancion4;
    public AudioSource cancion5;
    // Start is called before the first frame update
    void Start()
    {
        CancionRandom = Random.Range(1, 6);
        ReproducirCancion(CancionRandom);
    }

    void ReproducirCancion(int numeroCancion)
    {
        // Detener todas las canciones primero
        cancion1.Stop();
        cancion2.Stop();
        cancion3.Stop();
        cancion4.Stop();
        cancion5.Stop();

        // Reproducir la canción correspondiente
        switch (numeroCancion)
        {
            case 1:
                cancion1.enabled = true;
                break;
            case 2:
                cancion2.enabled = true;
                break;
            case 3:
                cancion3.enabled = true;
                break;
            case 4:
                cancion4.enabled = true;
                break;
            case 5:
                cancion5.enabled = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}