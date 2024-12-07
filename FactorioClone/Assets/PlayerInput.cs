using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Slime slimeInstance;

    // Default movement keys
    private KeyCode moveUp = KeyCode.W;
    private KeyCode moveDown = KeyCode.S;
    private KeyCode moveLeft = KeyCode.A;
    private KeyCode moveRight = KeyCode.D;

    private void Start()
    {
        slimeInstance = FindObjectOfType<Slime>();
        LoadKeyBindings(); // Load saved keybindings
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(moveLeft))
        {
            Debug.Log("pressed Left");
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(moveRight))
        {
            movement += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(moveUp))
        {
            movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(moveDown))
        {
            movement += new Vector3(0, -1, 0);
        }

        slimeInstance.Move(movement);
    }

    // Rebinding logic
    public void RebindKey(string action, KeyCode newKey)
    {
        switch (action)
        {
            case "MoveUp":
                moveUp = newKey;
                SaveKeyBinding("MoveUp", newKey);
                break;
            case "MoveDown":
                moveDown = newKey;
                SaveKeyBinding("MoveDown", newKey);
                break;
            case "MoveLeft":
                moveLeft = newKey;
                SaveKeyBinding("MoveLeft", newKey);
                break;
            case "MoveRight":
                moveRight = newKey;
                SaveKeyBinding("MoveRight", newKey);
                break;
        }

        Debug.Log($"{action} is now bound to {newKey}");
    }

    // Save a keybinding to PlayerPrefs
    private void SaveKeyBinding(string action, KeyCode key)
    {
        PlayerPrefs.SetString(action, key.ToString());
        PlayerPrefs.Save();
    }

    // Load saved keybindings from PlayerPrefs
    private void LoadKeyBindings()
    {
        moveUp = GetSavedKey("MoveUp", KeyCode.W);
        moveDown = GetSavedKey("MoveDown", KeyCode.S);
        moveLeft = GetSavedKey("MoveLeft", KeyCode.A);
        moveRight = GetSavedKey("MoveRight", KeyCode.D);
    }

    // Helper to retrieve saved key or default value
    private KeyCode GetSavedKey(string action, KeyCode defaultKey)
    {
        string savedKey = PlayerPrefs.GetString(action, defaultKey.ToString());
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), savedKey);
    }

    public Slime GetPlayerSlime()
    {
        return slimeInstance;
    }
}
