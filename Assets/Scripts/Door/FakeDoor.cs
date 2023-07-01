using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoor : Door
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.isPlayerLooking && !this.isOpened)
        {
            this.PlayAudio();
            this.ShowMessage("");
            this.SetPlayerAnimation();
            this.animator.SetBool("IsOpened", true);
            this.isOpened = true;
        }
    }

    private void SetPlayerAnimation()
    {
        Animator animator = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<Animator>();
        
        animator.SetTrigger("IsMimicAttacking");
    }
}
