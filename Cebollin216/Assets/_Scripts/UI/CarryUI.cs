using UnityEngine;
using TMPro;
using System;

public class CarryUI : MonoBehaviour
{
    public PlayerGrab playerGrab;

    public TextMeshProUGUI carryInfoText;

    public PlayerJump playerJump;

    void Update()
    {
        carryInfoText.text = "Carrying: " + playerGrab.carriedItemName + "\nweight: " + playerGrab.carriedWeight + "\nJump Force: " + playerJump.CurrentJumpForce.ToString("F1");
    }
}