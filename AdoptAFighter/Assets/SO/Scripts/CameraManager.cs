
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera fullCam;
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private Camera camera3;
    [SerializeField] private Camera camera4;

    [SerializeField] private FloatValueSO turnNumber;



    // Update is called once per frame
    void Update()
    {
        
        disableCamara(fullCam);
        disableCamara(camera1);
        disableCamara(camera2);
        disableCamara(camera3);
        disableCamara(camera4);

       switch (turnNumber.Value){
        case 1:
            //Debug.Log("si");
            enableCamara(camera1);
            break;
        case 2:
            enableCamara(camera2);
            break;
        case 3:
            enableCamara(camera3);
            break;
        case 4:
            enableCamara(camera4);
            break;
        default:
            enableCamara(fullCam);
            break;
       }

    }

    private void enableCamara(Camera cam){
        cam.enabled = true;
        cam.GetComponent<AudioListener>().enabled = true;
        cam.tag = "MainCamera";
    }

    private void disableCamara(Camera cam){
        cam.enabled = false;
        cam.GetComponent<AudioListener>().enabled = false;
        cam.tag = "NotMainCamera";
    }
}
