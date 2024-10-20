using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    private void Start()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                rows[i].cells[j].coordinates = new Vector2Int(j, i);
            }
        }
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
}
