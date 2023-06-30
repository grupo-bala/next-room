using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        LookTrigger obj = other.GetComponent<LookTrigger>();

        if (obj != null)
        {
            obj.OnPlayerLook();
        }
    }

    void OnTriggerExit(Collider other)
    {
        LookTrigger obj = other.GetComponent<LookTrigger>();

        if (obj != null)
        {
            obj.OnPlayerStopLook();
        }
    }
}
