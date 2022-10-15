using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockFactory))]
public class MapCreator : MonoBehaviour
{
    [SerializeField] private MapSO _levelData;
    [SerializeField] private Transform _mapParent;

    private Dictionary<Vector2, Block> _map;
    private List<Blocks> _colorBlocks;
    private BlockFactory _blockFactory;

    private void Awake()
    {
        _map = new Dictionary<Vector2, Block>();
        _colorBlocks = ColorsBlocksListCreator();
        _blockFactory = GetComponent<BlockFactory>();
    }
    private void Start()
    {
        CreateMap();
    }
    private void CreateMap()
    {
        for (int i = 1; i <= _levelData._mapSize.x; i++)
        {
            for (int j = 1; j <= _levelData._mapSize.y; j++)
            {
                Block block;
                Vector2 blockPosition = new Vector2(i, j);
                if (_levelData._stationaryBlocksPositions.Contains(blockPosition))
                    block = _blockFactory.CreateBlock(Blocks.Stationary);
                else if (_levelData._freeBlocksPositions.Contains(blockPosition))
                    block = _blockFactory.CreateBlock(Blocks.Free);
                else
                {
                    int blockNumber = UnityEngine.Random.Range(0, _colorBlocks.Count);
                    block = _blockFactory.CreateBlock(_colorBlocks[blockNumber]);
                    _colorBlocks.Remove(_colorBlocks[blockNumber]);
                }
                block.gameObject.transform.position = new Vector3(blockPosition.x, 0f, blockPosition.y);
                block.transform.SetParent(_mapParent);
                _map.Add(blockPosition, block);
            }
        }
    }
    private List<Blocks> ColorsBlocksListCreator()
    {
        List<Blocks> blocks = new List<Blocks>();
        int listSize = Convert.ToInt32(_levelData._mapSize.x * _levelData._mapSize.y) 
            - _levelData._stationaryBlocksPositions.Count 
            - _levelData._freeBlocksPositions.Count;
        Debug.Log(listSize / 3);
        for (int i = 0; i < listSize / 3; i++)
        {
            blocks.Add(Blocks.Red);
            blocks.Add(Blocks.Green);
            blocks.Add(Blocks.Blue);
        }
        return blocks;
    }
}
