using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 10;
    public Shape_Settings shapeSettings;
    public Colour_Settings colourSettings;

    Shape_Generator shapeGenerator;

    [SerializeField, HideInInspector] MeshFilter[] meshFilters;
    Terrain_Face[] terrainFaces;

    private void OnValidate()
    {
        GeneratePlanet();
    }

    void Initialize()
    {
        shapeGenerator = new Shape_Generator(shapeSettings);

        if (meshFilters == null || meshFilters.Length == 0)
        { 
            meshFilters = new MeshFilter[6];
        }
        
        terrainFaces = new Terrain_Face[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i]==null)
            {
                    GameObject meshObj = new GameObject("mesh");
                    meshObj.transform.parent = transform;

                    meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                    meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = new Mesh();
            }
           

            terrainFaces[i] = new Terrain_Face(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }
    public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColours();
    }
    public void ShapeSettingsUpdated()
    {
        Initialize();
        GenerateMesh();
    }
    public void OnColourSettingsUpdated()
    {
        Initialize();
        GenerateColours();
    }
    void GenerateMesh()
    {
        foreach (Terrain_Face face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
    void GenerateColours()
    {
        foreach (MeshFilter m in meshFilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = colourSettings.planetColour;
        }
    }
}
