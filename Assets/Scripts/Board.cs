using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Tile tilePrefab;
    public TileState[] tileStates;
    private Grid grid;
    private List<Tile> tiles;

    private void Awake()
    {
        grid = GetComponentInChildren<Grid>();
        tiles = new List<Tile>();
    }

    private void Start()
    {
        CreateTile();
        CreateTile();
    }

    private void CreateTile()
    {
        // create prefab
        Tile tile = Instantiate(tilePrefab, grid.transform);

        // random tile
        float rand = UnityEngine.Random.Range(0F, 1F);
        if (rand < 0.9) tile.SetState(tileStates[1], 2);
        else tile.SetState(tileStates[2], 3);

        // spawn tile
        tile.Spawn(grid.GetRandomEmptyCell());
        tiles.Add(tile);
    }
}
