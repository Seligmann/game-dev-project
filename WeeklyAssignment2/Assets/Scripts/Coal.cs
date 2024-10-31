using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coal : MonoBehaviour
{
    [SerializeField] private Slime slimeInstance;

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
    }

    private void OnMouseDown()
    {
        slimeInstance.IncreaseCoal();
        Debug.Log("Gained 1 coal!");
    }
}
