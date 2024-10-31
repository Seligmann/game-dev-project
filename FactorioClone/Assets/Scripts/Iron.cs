using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour
{
    [SerializeField] private Slime slimeInstance;

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
    }

    private void OnMouseDown()
    {
        slimeInstance.IncreaseIron();
        Debug.Log("Gained 1 iron!");
    }
}
