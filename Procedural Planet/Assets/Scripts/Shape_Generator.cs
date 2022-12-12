using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Generator 
{
    Shape_Settings settings;
    iNoise_Filter[] noiseFilters;

    public Shape_Generator(Shape_Settings settings)
    {
        this.settings = settings;
        noiseFilters = new iNoise_Filter[settings.noiseLayers.Length];
        for (int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = Noise_Filter_Factory.CreateNoiseFilter(settings.noiseLayers[i].noiseSettings);
                
        }
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 0;
        float elevation = 0;
        if(noiseFilters.Length > 0)
        {
            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSphere); 
            if (settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }
        for (int i = 1; i < noiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = settings.noiseLayers[i].useFirstLayerAsMask ? firstLayerValue : 1;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }
        return pointOnUnitSphere * settings.planetRadius * (1 + elevation);
    }
}
