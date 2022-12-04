using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Shape_Settings : ScriptableObject
{
    public float planetRadius = 1;
    public NoiseLayer[] noiseLayers;

    [System.Serializable]
    public class NoiseLayer
    {
        public bool useFirstLayerAsMask;
        public bool enabled = true;
        public Noise_Settings noiseSettings;
    }
}
