using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class RotatingDisc : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = -30.0f;
    [SerializeField] private float pulseRate = 1.0f;
    [SerializeField] private float minThickness = 16.0f;
    [SerializeField] private float maxThickness = 64.0f;

    private Disc disc;

    void Start()
    {
        disc = GetComponent<Disc>();
    }


    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime, Space.Self);

        float diff = maxThickness - minThickness;
        disc.Thickness = (Mathf.Sin(Time.time * pulseRate) * 0.5f + 0.5f) * diff + minThickness;
    }
}
