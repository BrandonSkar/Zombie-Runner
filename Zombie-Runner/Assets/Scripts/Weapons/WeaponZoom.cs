using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController controller;

    [SerializeField] float zoomedInValue = 30;
    [SerializeField] float zoomedOutValue = 60;

    [SerializeField] float zoomedInMouseSensitivity = 0.75f;
    [SerializeField] float zoomedOutMouseSensitivity = 2.0f;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        controller.mouseLook.XSensitivity = zoomedInMouseSensitivity;
        controller.mouseLook.YSensitivity = zoomedInMouseSensitivity;
        fpsCamera.fieldOfView = zoomedInValue;
    }

    private void ZoomOut()
    {
        controller.mouseLook.XSensitivity = zoomedOutMouseSensitivity;
        controller.mouseLook.YSensitivity = zoomedOutMouseSensitivity;
        fpsCamera.fieldOfView = zoomedOutValue;
    }

}
