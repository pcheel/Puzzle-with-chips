using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public MapCreator _mapCreator;

    private List<Block> _choiñedBlocks;
    private List<Blocks> _colorBlockTypes;
    private List<Block> _changedBlocks;
    private List<Vector2> _additionPositions;

    private void Awake()
    {
        _additionPositions = new List<Vector2>() { new Vector2(0, 1), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, -1) };
        _choiñedBlocks = new List<Block>();
        _changedBlocks = new List<Block>();
        _colorBlockTypes = new List<Blocks>() { Blocks.Blue, Blocks.Red, Blocks.Green };
    }
    public IBlockState ChoiñeBlock(Block block)
    {
        _choiñedBlocks.Add(block);
        Debug.Log($"choiseBlockType:{block.blockType}");
        return CheckBlockList(block);
    }
    private void SwapPosition()
    {
        Vector3 firstPos = _choiñedBlocks[0].transform.position;
        Vector3 secondePos = _choiñedBlocks[1].transform.position;
        Block block = _choiñedBlocks[0];
        //Vector3 firstPos = _choiñedBlocks[1].transform.position;
        _choiñedBlocks[0].transform.position = secondePos;
        _mapCreator.map[new Vector2(firstPos.x, firstPos.z)] = _choiñedBlocks[1];
        _choiñedBlocks[1].transform.position = firstPos;
        _mapCreator.map[new Vector2(secondePos.x, secondePos.z)] = block;
    }
    public IBlockState CheckBlockList(Block block)
    {
        if (_choiñedBlocks.Count < 2)
        {
            ChangeBlocksState(block);
            return new IsChoicedBlockState();
        }
        else if (_choiñedBlocks.Count == 2)
        {
            SwapPosition();
            return ReturnBlocksToDefaultState(block);
            //
        }
        else return null;
    }
    public IBlockState ReturnBlocksToDefaultState(Block block)
    {
        IBlockState state = null;
        foreach (Block changedBlock in _mapCreator.blocks)
        {
            if (_colorBlockTypes.Contains(changedBlock.blockType))
            {
                changedBlock.blockState = new CanBeChoicedBlockState();
            }
            else if (changedBlock.blockType == Blocks.Free)
            {
                changedBlock.blockState = new CantBeChoicedBlockState();
            }
            //Debug.Log($"type = {changedBlock.blockType}, pos = {changedBlock.transform.position}");
        }
        foreach(var paar in _mapCreator.map)
        {
            Debug.Log($"type = {paar.Value.blockType}, pos = {paar.Key}");
        }
        if (_colorBlockTypes.Contains(block.blockType))
        {
            state = new CanBeChoicedBlockState();
        }
        else if (block.blockType == Blocks.Free)
        {
            state = new CantBeChoicedBlockState();
        }
        _choiñedBlocks.Clear();
        return state;
    }
    private void ChangeBlocksState(Block block)
    {
        Vector3 position = block.transform.position;
        foreach (Block changedBlock in _mapCreator.blocks)
        {
            if (_colorBlockTypes.Contains(changedBlock.blockType))
            {
                changedBlock.blockState = new CantBeChoicedBlockState();
            }
        }
        foreach (Vector2 additionPosition in _additionPositions)
        {
            Vector2 adjacentPosition = new Vector2(position.x + additionPosition.x, position.z + additionPosition.y);
            if (_mapCreator.map.ContainsKey(adjacentPosition))
            {
                Blocks blockType = _mapCreator.map[adjacentPosition].blockType;
                //Debug.Log(blockType);
                if (blockType == Blocks.Free)
                {
                    Debug.Log("is free");
                    _mapCreator.map[adjacentPosition].blockState = new CanBeChoicedBlockState();
                }
            }
        }
    }
}
