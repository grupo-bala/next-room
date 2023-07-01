using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera)
        {
            transform.LookAt(mainCamera.transform);
        }
    }
}
