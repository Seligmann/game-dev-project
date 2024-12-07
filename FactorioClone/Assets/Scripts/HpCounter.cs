using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpCounter : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TextMeshProUGUI hpText;

    void Update()
    {
        hpText.text = playerInput.GetPlayerSlime().hp.ToString();
    }
}
