using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookTrigger : MonoBehaviour
{
    protected bool isPlayerLooking = false;
    public void OnPlayerLook()
    {
        this.isPlayerLooking = true;
    }
    public void OnPlayerStopLook()
    {
        this.isPlayerLooking = false;
    }
}
