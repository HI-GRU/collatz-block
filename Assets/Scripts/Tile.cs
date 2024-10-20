using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileState state { get; private set; }
    public Cell cell { get; private set; }
    public int number { get; private set; }

}
