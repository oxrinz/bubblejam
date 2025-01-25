using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TileType
{
    EMPTY
}

public class Tile
{
    public int x;
    public int y;
    public TileType type;

    public GameObject buildingInstance;
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

        uiSelectInstance = Instantiate(uiSelect, new Vector3(tile.x, tile.y, 0.0f), Quaternion.identity);
    }

    public void PlaceBuilding(GameObject building) {
        if (selected.buildingInstance == null) {
            GameObject binst = Instantiate(building, new Vector3(selected.x, selected.y, 0.0f), Quaternion.identity);

            selected.buildingInstance = binst;
        }
        else {
            throw new Exception("THERE'S ALREADY BUILDING HERE !");
        }
    }
}
