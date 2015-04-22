using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Renderer))]
public class VisibleHeating : TemperatureController {

    Color heatColor = Color.red;

    private Renderer selfRenderer;
    Color defaultColor;

    private Dictionary<Renderer, Color> children = new Dictionary<Renderer, Color>();

    void Start()
    {
        selfRenderer = GetComponent<Renderer>();
        defaultColor = selfRenderer.material.color;

        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer child in childRenderers)
        {
            if (child is LineRenderer) continue;
            if (child is ParticleRenderer) continue;
            if (child.material == null) continue;
            if (!child.material.HasProperty("_Color")) continue;

            children.Add(child, child.material.color);
        }
    }

    protected override void CustomUpdate()
    {
        Color color = Color.Lerp(defaultColor, heatColor, GetTemperature());
        selfRenderer.material.color = color;

        foreach (Renderer key in children.Keys)
        {
            color = Color.Lerp(children[key], heatColor, GetTemperature());
            key.material.color = color;
        }
    }
}
