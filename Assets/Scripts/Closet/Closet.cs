using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : LookTrigger
{
    private bool isPlayerInside = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.isPlayerLooking && !this.isPlayerInside)
        {
            this.ShowMessage("[E] Sair");
            this.isPlayerInside = true;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<PlayerMove>().BlockMove();

            player.transform.position = this.transform.position;
            player.transform.Rotate(Vector3.up, 180.0f);
        } else if (Input.GetKeyDown(KeyCode.E) && this.isPlayerInside)
        {
            this.ShowMessage("");
            this.isPlayerInside = false;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMove>().ResetMove();
            GetComponent<BoxCollider>().enabled = true;
            player.transform.position = this.transform.position + this.transform.forward * 2.0f;
            player.transform.Rotate(Vector3.up, 180.0f);
        }
    }
    public override void OnPlayerLook()
    {
        base.OnPlayerLook();

        if (!this.isPlayerInside)
        {
            this.ShowMessage("[E] Entrar");
        }
    }

    public override void OnPlayerStopLook()
    {
        base.OnPlayerStopLook();
        this.ShowMessage("");
    }
}
