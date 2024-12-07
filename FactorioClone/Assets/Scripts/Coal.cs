using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
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
            if (resourceNode.Mine(1))
            {
                resourceNode.GetComponent<AudioSource>().Play();
                slimeInstance.IncreaseCoal();
                Debug.Log($"Gained 1 coal! Remaining coal: {resourceNode.GetRemainingResources()}");
            }
            else
            {
                Debug.Log("This coal tile is depleted!");
            }
        }
    }
}
