using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour

{
    public Tilemap tilemap;
    public Tile[] tileassets;
    private int width = 30;
    private int height = 20;
    public Vector3Int placer;
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
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                placer.x = x;
                placer.y = y;
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    tilemap.SetTile(placer, tileassets[1]);
                }
                else
                {
                    tilemap.SetTile(placer, tileassets[0]);
                }
            }
        }

    }
}

