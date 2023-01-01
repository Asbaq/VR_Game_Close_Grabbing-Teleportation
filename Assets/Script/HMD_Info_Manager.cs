using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMD_Info_Manager : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
