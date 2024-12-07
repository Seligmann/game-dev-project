using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMachine : MonoBehaviour
{
    public GameObject machinePrefab;
    [SerializeField] private Slime slimeInstance;
    [SerializeField] private int numMachinesOnCoal = 0;
    [SerializeField] private int numMachinesOnIron = 0;
    [SerializeField] float spawnTime = 1f;
    public float timer = 0;
    private const int NUM_IRON_REQ_MACHINE = 20;

    private List<MachineNode> activeMachines = new List<MachineNode>();

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            HarvestResourcesFromMachines();
            timer = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && slimeInstance.machinesInInven > 0)
            {
                ResourceNode resourceNode = hitCollider.GetComponent<ResourceNode>();
                if (resourceNode != null && resourceNode.GetRemainingResources() > 0)
                {
                    PlaceMachineOnTile(hitCollider.transform.position, resourceNode);
                    slimeInstance.machinesInInven--;
                }
                else
                {
                    Debug.Log("Cannot place a machine here. Resource is depleted or invalid.");
                }
            }
        }
    }

    private void PlaceMachineOnTile(Vector2 position, ResourceNode resourceNode)
    {
        Instantiate(machinePrefab, position, Quaternion.identity);
        activeMachines.Add(new MachineNode(resourceNode));
        Debug.Log("Placed machine at position: " + position);
    }

    private void HarvestResourcesFromMachines()
    {
        for (int i = activeMachines.Count - 1; i >= 0; i--)
        {
            MachineNode machine = activeMachines[i];
            if (machine.ResourceNode.Mine(1))
            {
                if (machine.ResourceNode.CompareTag("Coal"))
                {
                    slimeInstance.IncreaseCoal();
                }
                else if (machine.ResourceNode.CompareTag("Iron"))
                {
                    slimeInstance.IncreaseIron();
                }
            }
            else
            {
                Debug.Log("Machine resource depleted. Machine is now inactive.");
                activeMachines.RemoveAt(i);
            }
        }
    }

    private class MachineNode
    {
        public ResourceNode ResourceNode { get; }

        public MachineNode(ResourceNode resourceNode)
        {
            ResourceNode = resourceNode;
        }
    }
}
