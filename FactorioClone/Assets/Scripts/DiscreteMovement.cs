using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class DiscreteMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float speed = 10.0f;

    public void Move(Vector3 movement)
    {
        transform.localPosition += movement * speed * Time.deltaTime;
    }
}


