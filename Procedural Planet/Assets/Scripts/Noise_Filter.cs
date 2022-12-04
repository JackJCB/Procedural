using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise_Filter 
{
    Noise_Settings settings;
    Noise noise = new Noise();
    private Noise_Filter noiseSettings;

    public Noise_Filter(Noise_Settings settings)
    {
        this.settings = settings;
    }

    public Noise_Filter(Noise_Filter noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;
        for (int i = 0; i < settings.numLayers; i++)
        {
            float v = noise.Evaluate(point * frequency + settings.centre);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= settings.roughness;
            amplitude *= settings.persistance;
        }
        noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
        return noiseValue * settings.strength;

    }
}
