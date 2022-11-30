using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject FPCamera, SPCamera;
    public bool FPCOn;

    void Start()
    {
        FPCOn = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            FPCOn = !FPCOn;
            if (FPCOn == true)
            {
                FPCamera.SetActive(true);
                SPCamera.SetActive(false);
            }
            if (FPCOn == false)
            {
                FPCamera.SetActive(false);
                SPCamera.SetActive(true);
            }
        }
    }
}
