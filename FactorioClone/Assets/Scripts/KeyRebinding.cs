using System.Collections;
using UnityEngine;

public class KeyRebinding : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    public void Rebind(string action)
    {
        StartCoroutine(WaitForKeyPress(action));
    }

    private IEnumerator WaitForKeyPress(string action)
    {
        Debug.Log($"Press a key to rebind {action}");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                playerInput.RebindKey(action, key);
                Debug.Log($"{action} rebound to {key}");
                break;
            }
        }
    }
}
