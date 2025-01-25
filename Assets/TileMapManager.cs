using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public enum ResourceType
{
    NONE,
    COAL,
    IRON,
    WATER
}

public enum TileType
{
    EMPTY,
    RESOURCE,
    LIQUID
}

public class Tile
{
    public int x;
    public int y;
    public TileType type;

    public GameObject buildingInstance;

    public ResourceType resourceType;
    public float resourceAmount;
}

public class TileMapManager : MonoBehaviour
{
    public int WIDTH;
    public int HEIGHT;


    public GameObject uiSelect;
    GameObject uiSelectInstance;


    public Tile[,] tileMatrix;
    public Tile selected;

    public static TileMapManager instance;

    public Tilemap resourceTilemap;
    public Tilemap liquidTilemap;

    private void Awake()
    {
        instance = this;
        tileMatrix = new Tile[WIDTH, HEIGHT];
        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                tileMatrix[i, j] = new Tile();
                tileMatrix[i, j].x = i;
                tileMatrix[i, j].y = j;
            }
        }

        SetupTileMapData();
    }

    void SetupTileMapData()
    {
        List<(string name, Tile tile)> resultArray;

        for (int x = 0; x < 1000; x++)
        {
            for (int y = 0; y < 1000; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                TileBase resourceTile = resourceTilemap.GetTile(tilePosition);
                TileBase liquidTile = liquidTilemap.GetTile(tilePosition);

                TileBase finalTile = resourceTile == null ? liquidTile : resourceTile;

                if (finalTile != null)
                {
                    Tile foundTile = GetTile((int)tilePosition.x, (int)tilePosition.y);

                    Sprite tileSprite = resourceTilemap.GetSprite(tilePosition);

                    resultArray.add((tileSprite.name, foundTile))

                    if (tileSprite.name == "coal")
                    {
                        foundTile.type = TileType.RESOURCE;
                        foundTile.resourceType = ResourceType.COAL;
                    }

                    if (tileSprite.name == "iron")
                    {
                        foundTile.type = TileType.RESOURCE;
                        foundTile.resourceType = ResourceType.IRON;
                    }
                }
            }
        }
    }

    public Tile GetTile(int x, int y)
    {
        return tileMatrix[x, y];
    }

    public void SelectTile(int x, int y)
    {
        SelectTile(tileMatrix[x, y]);
    }

    public void SelectTile(Tile tile)
    {
        selected = tile;

        Destroy(uiSelectInstance);

        uiSelectInstance = Instantiate(uiSelect, new Vector3(tile.x + 0.5f, tile.y + 0.5f, 0.0f), Quaternion.identity);
    }

    public void PlaceBuilding(GameObject building)
    {
        if (selected.buildingInstance == null)
        {
            GameObject binst = Instantiate(building, new Vector3(selected.x + 0.5f, selected.y + 0.5f, 0.0f), Quaternion.identity);

            selected.buildingInstance = binst;
        }
        else
        {
            throw new Exception("THERE'S ALREADY BUILDING HERE !");
        }
    }
}
