using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    void Start()
    {
        RandomizeColor();
    }
    public void RandomizeColor() {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        GetComponent<SpriteRenderer>().color = new Color(r, g, b);
    }
}
