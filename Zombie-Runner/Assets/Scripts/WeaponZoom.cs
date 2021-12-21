using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;

    [SerializeField] float zoomedInValue = 30;
    [SerializeField] float zoomedOutValue = 60;

    [SerializeField] float zoomedInMouseSensitivity = 0.75f;
    [SerializeField] float zoomedOutMouseSensitivity = 2.0f;

    RigidbodyFirstPersonController controller;

    private void Start()
    {
        controller = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            controller.mouseLook.XSensitivity = zoomedInMouseSensitivity;
            controller.mouseLook.YSensitivity = zoomedInMouseSensitivity;
            fpsCamera.fieldOfView = zoomedInValue;
        }
        else
        {
            controller.mouseLook.XSensitivity = zoomedOutMouseSensitivity;
            controller.mouseLook.YSensitivity = zoomedOutMouseSensitivity;
            fpsCamera.fieldOfView = zoomedOutValue;
        }
    }
}
