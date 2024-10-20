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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveTiles(Vector2Int.up, 0, 1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTiles(Vector2Int.left, 1, 1, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveTiles(Vector2Int.down, 0, 1, grid.height - 2, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTiles(Vector2Int.right, grid.width - 2, -1, 0, 1);
        }
    }

    private void MoveTiles(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
    {
        for (int x = startX; x >= 0 && x < grid.width; x += incrementX)
        {
            for (int y = startY; y >= 0 && y < grid.height; y += incrementY)
            {
                Cell cell = grid.GetCell(x, y);

                if (!cell.empty)
                {
                    MoveTile(cell.tile, direction);
                }
            }
        }
    }

    private void MoveTile(Tile tile, Vector2Int direction)
    {
        Cell nextCell = null;
        Cell adjacentCell = grid.GetAdjacentCell(tile.cell, direction);

        while (adjacentCell != null)
        {
            if (!adjacentCell.empty)
            {
                // TODO: merging
                break;
            }

            nextCell = adjacentCell;
            adjacentCell = grid.GetAdjacentCell(adjacentCell, direction);
        }

        if (nextCell != null)
        {
            tile.MoveTo(nextCell);
        }
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
