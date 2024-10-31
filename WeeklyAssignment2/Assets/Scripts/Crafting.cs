using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crafting : MonoBehaviour
{
    private const int NUM_IRON_REQ_MACHINE = 20;
    private Slime slimeInstance;

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
    }

    public void CraftMachine() {
        if (slimeInstance.iron < NUM_IRON_REQ_MACHINE)
        {
            return;
        }

        slimeInstance.iron -= NUM_IRON_REQ_MACHINE;
        slimeInstance.machinesInInven++;
    }
}
