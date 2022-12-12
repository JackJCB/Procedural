using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class Noise_Settings 
{
    public enum FilterType {Simple, Rigid};
    public FilterType filterType;

    public SimpleNoiseSettings simpleNoiseSettings;
    public RigidNoiseSettings rigidNoiseSettings;
    

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        private float randomNumber;
        [Range(0.01f, 0.4f)] public float strength;
        [Range(1, 8)] public int numLayers = 1;
        [Range(0.3f, 2f)] public float baseRoughness = 1;
        [Range(1.5f, 4f)] public float roughness = 2;
        [Range(0.4f, 0.8f)] public float persistance = 0.5f;
        public Vector3 centre;
        [Range(0, 1)] public float minValue;

        public void RandomGenerate()
        {
            if (GUILayout.Button("Generate Planet"))
            {
                strength = Random.value;
            }
            


        }
        
    }

    [System.Serializable]
    public class RigidNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultiplier;
    }

   
    
}
