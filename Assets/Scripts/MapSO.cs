using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Data/Level", order = 51)]
public class MapSO : ScriptableObject
{
    public Vector2 _mapSize;
    public List<Vector2> _stationaryBlocksPositions;
    public List<Vector2> _freeBlocksPositions;
    public List<Vector2> _checkingWinBlocksPositions;
}
