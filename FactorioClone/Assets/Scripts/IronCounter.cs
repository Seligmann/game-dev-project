using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IronCounter : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TextMeshProUGUI ironText;

    void Update() {
        ironText.text = playerInput.GetPlayerSlime().iron.ToString();
    }
}
