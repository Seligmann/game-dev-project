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

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            IncreaseOreCountFromMachines();
            timer = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && slimeInstance.machinesInInven > 0)
            {
                // FIXME add check to see if there's a machine already on the ore
                Debug.Log("hit collider tag = " + hitCollider.tag);
                if (hitCollider.CompareTag("Coal"))
                {
                    PlaceMachineOnTile(hitCollider.transform.position);
                    numMachinesOnCoal++;
                    slimeInstance.machinesInInven--;
                    Debug.Log("Current number of machines on coal = " + numMachinesOnCoal);
                }
                else if (hitCollider.CompareTag("Iron"))
                {
                    PlaceMachineOnTile(hitCollider.transform.position);
                    numMachinesOnIron++;
                    slimeInstance.machinesInInven--;
                    Debug.Log("Current number of machines on iron = " + numMachinesOnIron);
                }
            }
        }
    }

    private void PlaceMachineOnTile(Vector2 position)
    {
        Instantiate(machinePrefab, position, Quaternion.identity);
        Debug.Log("Placed machine at position: " + position);
    }

    private void IncreaseOreCountFromMachines()
    {
        slimeInstance.coal += numMachinesOnCoal;
        slimeInstance.iron += numMachinesOnIron;
    }
}
