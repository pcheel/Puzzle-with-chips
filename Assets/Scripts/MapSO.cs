using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Data/Map", order = 51)]
public class MapSO : ScriptableObject
{
    public Vector2 _mapSize;
    public List<Vector3> _stationaryBlocksPositions;
    public List<Vector3> _freeBlocksPositions;
    public List<Vector3> _checkingWinBlocksPositions;
}
