using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] float size = 2;

    // Start is called before the first frame update
    void Start()
    {
        Resize();
        RandomizeColor();
    }

    public void Resize(float newSize) {
        size = newSize;
        Resize();
    }

    public void RandomizeColor() {
        float brightness = Random.Range(0, 0.25f);
        GetComponent<SpriteRenderer>().color = new Color(brightness, brightness, brightness);
    }

    public void Resize() {
        transform.localScale = Vector3.one * size;
    }
}
