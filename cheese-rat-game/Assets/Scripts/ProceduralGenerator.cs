using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tileassets;
    public int width = 30;
    public int height = 20;
    private Vector3Int placer = new Vector3Int(0, 0, -10);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMap()
    {
        int perimeter = (2 * (width + height) - 4);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if((x * 20 + y) > perimeter)
                {

                }
                else
                {
                    placer.x = x;
                    placer.y = y;
                    tilemap.SetTile(placer, tileassets[1]);
                }
            }
        }
    }


}
