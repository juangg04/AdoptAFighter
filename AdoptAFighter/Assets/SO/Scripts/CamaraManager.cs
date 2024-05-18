
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private Camera camera1;

    [SerializeField] private Camera camera2;

    [SerializeField] private Camera camera3;

    [SerializeField] private FloatValueSO turnNumber;




    // Update is called once per frame
    void Update()
    {
        disableCamara(mainCamera);
        disableCamara(camera1);
        disableCamara(camera2);
        disableCamara(camera3);

       switch (turnNumber.Value){
        case 1:
            enableCamara(camera1);
            break;
        case 2:
            enableCamara(camera2);
            break;
        case 3:
            enableCamara(camera3);
            break;
        default:
            enableCamara(mainCamera);
            break;
       }
    }

    private void enableCamara(Camera cam){
        cam.enabled = true;
        cam.GetComponent<AudioListener>().enabled = true;
    }

    private void disableCamara(Camera cam){
        cam.enabled = false;
        cam.GetComponent<AudioListener>().enabled = false;
    }
}
