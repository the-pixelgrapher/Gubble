using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = -30.0f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
