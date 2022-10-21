using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockPack", menuName = "Data/BlockPack", order = 51)]
public class BlockPackSO : ScriptableObject
{
    //public Dictionary<Block, GameObject> _blockPack;
    public GameObject _blueBlock;
    public GameObject _redBlock;
    public GameObject _greenBlock;
    public GameObject _freeBlock;
    public GameObject _stationaryBlock;
    public GameObject _blueRayBlock;
    public GameObject _greenRayBlock;
    public GameObject _redRayBlock;
}
