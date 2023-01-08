using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftGrip;
    public InputActionProperty rightGrip;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(leftGrip.action.ReadValue<float>());
        leftTeleportation.SetActive(leftGrip.action.ReadValue<float>() > 0.1f);
        Debug.Log(rightGrip.action.ReadValue<float>());
        rightTeleportation.SetActive(rightGrip.action.ReadValue<float>() > 0.1f);
    }
}
