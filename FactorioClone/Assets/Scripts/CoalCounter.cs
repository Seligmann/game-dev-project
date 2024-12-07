using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TextMeshProUGUI coalText;

    void Update()
    {
        coalText.text = playerInput.GetPlayerSlime().coal.ToString();
    }
}
