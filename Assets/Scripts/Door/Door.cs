using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : LookTrigger
{
    public Animator animator;
    protected bool isOpened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.isPlayerLooking && !this.isOpened)
        {
            this.PlayAudio();
            this.ShowMessage("");
            this.animator.SetBool("IsOpened", true);
            this.isOpened = true;
        }
    }

    public override void OnPlayerLook()
    {
        base.OnPlayerLook();

        if (!isOpened)
        {
            this.ShowMessage("[E] Abrir");
        }
    }

    public override void OnPlayerStopLook()
    {
        base.OnPlayerStopLook();
        this.ShowMessage("");
    }

    protected void ShowMessage(string message)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<HUD>().ShowFeedbackMessage(message);
    }

    protected void PlayAudio()
    {
        int audioIndex = Random.Range(0, 2);
        GetComponents<AudioSource>()[audioIndex].Play();
    }
}
