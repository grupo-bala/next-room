using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : LookTrigger
{
    public Transform pivot;
    private bool isOpened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.isPlayerLooking && !isOpened)
        {
            transform.RotateAround(this.pivot.position, Vector3.up, -90);
            this.isOpened = true;
        }
    }
}
