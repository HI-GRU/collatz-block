using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Row[] rows { get; private set; }
    public Cell[] cells { get; private set; }
    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;

    private void Awake()
    {
        rows = GetComponentsInChildren<Row>();
        cells = GetComponentsInChildren<Cell>();

        for (int i = 0; i < size; i++) cells[i].coordinates = new Vector2Int(i % width, i / width);
    }

    public Cell GetRandomEmptyCell()
    {
        int index = UnityEngine.Random.Range(0, cells.Length);

        int count = 0;
        while (count != size && !cells[index].empty)
        {
            index = (index + 1) % size;
            count++;
        }

        if (count == size) return null;

        return cells[index];
    }

    public Cell GetCell(int x, int y)
    {
        if (IsBounded(x, y)) return rows[y].cells[x];
        return null;
    }

    public Cell GetAdjacentCell(Cell currentCell, Vector2Int direction)
    {
        Vector2Int coordinates = currentCell.coordinates;

        return GetCell(coordinates.x + direction.x, coordinates.y - direction.y);
    }

    private bool IsBounded(int x, int y)
    {
        return y >= 0 && y < height && x >= 0 && x < width;
    }
}
