using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI feedbackMessage;

    public void ShowFeedbackMessage(string message)
    {
        this.feedbackMessage.text = message;
    }
}
