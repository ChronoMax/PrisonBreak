using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeightMapDisplay : MonoBehaviour
{

    private Material mat;

    public Vector2Int size = new Vector2Int(512, 512);

    [Range(1,10)]
    public int octaves = 4;

    [Range(1f,3f)]
    public float lacunarity = 1.8f;

    [Range(0f, 1f)]
    public float presistance = 0.5f;

    public Vector2 offset = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;

        GenerateMap();
    }

    void GenerateMap()
    {
        if (mat != null)
        {
            mat.mainTexture = ProceduralUtils.GenerateTexture2D(ProceduralUtils.GenerateTerainData(size.x, size.y, octaves, lacunarity, presistance, offset));
            mat.mainTexture.filterMode = FilterMode.Point;
            mat.mainTexture.wrapMode = TextureWrapMode.Clamp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        GenerateMap();
    }
}
