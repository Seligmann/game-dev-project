using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineCounter : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TextMeshProUGUI machinesInInvenText;

    void Update()
    {
        machinesInInvenText.text = playerInput.GetPlayerSlime().machinesInInven.ToString();
    }
}