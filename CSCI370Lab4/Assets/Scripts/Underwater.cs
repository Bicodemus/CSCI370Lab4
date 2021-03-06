using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public float waterHeight = 1000;

    private bool isUnderwater;
    private Color normalColor;
    private Color underwaterColor;

    // Use this for initialization
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        SetUnderwater();
    }

    void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.01f;

    }

    void SetUnderwater()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = 0.1f;

    }
}