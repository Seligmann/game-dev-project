using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour
{
    [SerializeField] private Slime slimeInstance;

    private ResourceNode resourceNode;

    private void Start()
    {

        slimeInstance = FindObjectOfType<Slime>();
        resourceNode = GetComponent<ResourceNode>();
    }

    private void OnMouseDown()
    {
        if (resourceNode != null)
        {
            // try to mine a unit
            if (resourceNode.Mine(1))
            {
                slimeInstance.IncreaseIron();
                resourceNode.GetComponent<AudioSource>().Play();

                Debug.Log($"Gained 1 iron! Remaining iron: {resourceNode.GetRemainingResources()}");
            }
            else
            {
                Debug.Log("This iron tile is depleted!");
            }
        }
    }
}
