# VR Game Close Grabbing and Teleportation 🚀

![VR](https://user-images.githubusercontent.com/62818241/210204533-0cea0e3c-bede-4ed8-a568-ea36846e89b1.PNG)

## 📌 Introduction
This **VR Game Close Grabbing and Teleportation** feature enhances user interaction in a VR environment by integrating close-range grabbing mechanics and teleportation functionality. Utilizing Unity's XR Toolkit and Input System, players can teleport and manipulate objects in the virtual world seamlessly using hand gestures, including pinch and grip actions.

## 🔥 Features
- 🖐️ **Close Grabbing**: Enable object interaction by gripping with the controller.
- 🚀 **Teleportation**: Activate teleportation ray with controller input.
- 🔥 **Bullet Firing**: Fire projectiles from the hand with a grab action.
- 🎮 **Hand Animation**: Smooth hand animations based on input actions.
- 🎧 **XR Headset Info**: Provides real-time status of connected VR headsets.

---

## 🏗️ How It Works
The feature includes multiple scripts that handle the different actions, such as teleportation, hand animation, bullet firing, and VR headset status checks.

### 📌 **ActivateTeleportationRay Script**
This script toggles the teleportation ray on and off based on the input from the left and right grip buttons. It enables the user to activate the teleportation functionality by gripping the controllers.

```csharp
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

    void Update()
    {
        Debug.Log(leftGrip.action.ReadValue<float>());
        leftTeleportation.SetActive(leftGrip.action.ReadValue<float>() > 0.1f);
        Debug.Log(rightGrip.action.ReadValue<float>());
        rightTeleportation.SetActive(rightGrip.action.ReadValue<float>() > 0.1f);
    }
}
```

### 📌 **AnimateHandOnInput Script**
This script animates the user's hands based on the input actions. It detects grip and pinch inputs and triggers corresponding animations for each.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
```

### 📌 **FireBullet Script**
This script allows the player to fire a bullet by grabbing and activating a specified object in the game. The bullet is instantiated and fired from the spawn point in the forward direction with a specified speed.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
    }

    public void Fire(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}
```

### 📌 **HMD_Info_Manager Script**
This script checks if a VR headset is connected and logs the status. It is useful for debugging purposes to ensure that the VR device is properly initialized and recognized.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMD_Info_Manager : MonoBehaviour
{
    void Start()
    {
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset Plugged");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockMDDisplay"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("We Have a headset " + XRSettings.loadedDeviceName);
        }
    }

    void Update() { }
}
```

---

## 🎯 Conclusion
This **VR Game Close Grabbing and Teleportation** feature provides immersive and interactive controls for VR games. With the integration of teleportation mechanics, hand animations, bullet firing, and real-time VR headset information, users can experience a more dynamic and engaging virtual world. By utilizing Unity’s XR Toolkit and Input System, it ensures smooth and responsive gameplay. 🚀🌟
