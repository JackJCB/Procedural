using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Generator 
{
    Shape_Settings settings;
    
    public Shape_Generator(Shape_Settings settings)
    {
        this.settings = settings;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * settings.planetRadius;
    }
}
