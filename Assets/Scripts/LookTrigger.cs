using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookTrigger : MonoBehaviour
{
    protected bool isPlayerLooking = false;
    public virtual void OnPlayerLook()
    {
        this.isPlayerLooking = true;
    }
    public virtual void OnPlayerStopLook()
    {
        this.isPlayerLooking = false;
    }
}
