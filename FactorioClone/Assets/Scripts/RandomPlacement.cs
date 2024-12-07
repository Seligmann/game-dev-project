using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject coalPrefab;
    public GameObject ironPrefab;
    public GameObject healPrefab; // Heal prefab
    public GameObject lavaPrefab; // Lava prefab

    [Header("Spawn Settings")]
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    [Header("Difficulty Settings")]
    public string difficulty = "Medium"; // Default difficulty
    private int numCoalToSpawn = 7;
    private int numIronToSpawn = 7;
    private int healAmount = 25; // Default heal amount
    private int lavaDamage = 10; // Default lava damage

    private ObjectPooler coalPooler;
    private ObjectPooler ironPooler;

    void Awake()
    {
        // Load difficulty from PlayerPrefs
        difficulty = PlayerPrefs.GetString("GameDifficulty", "Medium");

        coalPooler = new ObjectPooler(coalPrefab, numCoalToSpawn, transform);
        ironPooler = new ObjectPooler(ironPrefab, numIronToSpawn, transform);
    }

    void Start()
    {
        ApplyDifficultySettings();

        PlaceRandomly(coalPooler, numCoalToSpawn);
        PlaceRandomly(ironPooler, numIronToSpawn);
        PlaceHealTile();
        PlaceLavaTile();
    }

    public void SetDifficulty(string newDifficulty)
    {
        difficulty = newDifficulty;
        PlayerPrefs.SetString("GameDifficulty", difficulty);
        PlayerPrefs.Save();
        ApplyDifficultySettings();
        Debug.Log("Difficulty set to: " + difficulty);
    }

    private void ApplyDifficultySettings()
    {
        switch (difficulty)
        {
            case "Easy":
                numCoalToSpawn = 5;
                numIronToSpawn = 5;
                healAmount = 50;
                lavaDamage = 5;
                break;
            case "Medium":
                numCoalToSpawn = 7;
                numIronToSpawn = 7;
                healAmount = 25;
                lavaDamage = 10;
                break;
            case "Hard":
                numCoalToSpawn = 10;
                numIronToSpawn = 10;
                healAmount = 10;
                lavaDamage = 20;
                break;
        }

        Debug.Log($"Applied Difficulty: {difficulty} | Coal: {numCoalToSpawn}, Iron: {numIronToSpawn}, Heal: {healAmount}, Lava: {lavaDamage}");
    }

    private void PlaceRandomly(ObjectPooler pooler, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            GameObject obj = pooler.GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = randomPosition;
                obj.SetActive(true);

                ResourceNode resourceNode = obj.GetComponent<ResourceNode>();
                if (resourceNode != null)
                {
                    int randomResources = Random.Range(1, 101);
                    resourceNode.Initialize(randomResources);
                }
            }
        }
    }

    private void PlaceHealTile()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject healTile = Instantiate(healPrefab, randomPosition, Quaternion.identity);
        HealTile healComponent = healTile.GetComponent<HealTile>();
        if (healComponent != null)
        {
            healComponent.SetHealAmount(healAmount);
        }
        Debug.Log("Heal tile placed at position: " + randomPosition);
    }

    private void PlaceLavaTile()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject lavaTile = Instantiate(lavaPrefab, randomPosition, Quaternion.identity);
        LavaTile lavaComponent = lavaTile.GetComponent<LavaTile>();
        if (lavaComponent != null)
        {
            lavaComponent.SetDamage(lavaDamage);
        }
        Debug.Log("Lava tile placed at position: " + randomPosition);
    }
}

public class ObjectPooler
{
    private GameObject prefab;
    private List<GameObject> pooledObjects;
    private Transform parentTransform;

    public ObjectPooler(GameObject prefab, int initialSize, Transform parent)
    {
        this.prefab = prefab;
        this.parentTransform = parent;
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.SetActive(false);

            if (obj.GetComponent<ResourceNode>() == null)
            {
                obj.AddComponent<ResourceNode>();
            }

            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        GameObject newObj = GameObject.Instantiate(prefab, parentTransform);
        newObj.SetActive(false);

        if (newObj.GetComponent<ResourceNode>() == null)
        {
            newObj.AddComponent<ResourceNode>();
        }

        pooledObjects.Add(newObj);
        return newObj;
    }
}

public class ResourceNode : MonoBehaviour
{
    [SerializeField]
    private int remainingResources;

    private void OnMouseDown()
    {
        Debug.Log($"Remaining resources: {remainingResources}");
    }

    public void Initialize(int initialResources)
    {
        remainingResources = initialResources;
        Debug.Log($"Initialized node with {remainingResources} resources.");
    }

    public bool Mine(int amount)
    {
        if (remainingResources <= 0) return false;

        remainingResources -= amount;

        if (remainingResources <= 0)
        {
            DestroyNode();
        }

        return true;
    }

    private void DestroyNode()
    {
        Debug.Log("Node depleted and deactivated.");
        gameObject.SetActive(false);
    }

    public int GetRemainingResources()
    {
        return remainingResources;
    }
}
