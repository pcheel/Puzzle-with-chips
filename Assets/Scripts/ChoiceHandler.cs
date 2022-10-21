using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public MapCreator _mapCreator;
    public Action _OnBlocksSwap;

    private List<Block> _choi�edBlocks;
    private List<Blocks> _colorBlockTypes;
    private List<Block> _changedBlocks;
    private List<Vector2> _additionPositions;
    private List<WinCheckingRay> _winChickingRays;

    private void Awake()
    {
        _additionPositions = new List<Vector2>() { new Vector2(0, 1), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, -1) };
        _choi�edBlocks = new List<Block>();
        _changedBlocks = new List<Block>();
        _colorBlockTypes = new List<Blocks>() { Blocks.Blue, Blocks.Red, Blocks.Green };
    }
    public IBlockState Choi�eBlock(Block block)
    {
        _choi�edBlocks.Add(block);
        Debug.Log($"choiseBlockType:{block.blockType}");
        return CheckBlockList(block);
    }
    private void SwapPosition()
    {
        Vector3 firstPos = _choi�edBlocks[0].transform.position;
        Vector3 secondePos = _choi�edBlocks[1].transform.position;
        Block block = _choi�edBlocks[0];
        _choi�edBlocks[0].transform.position = secondePos;
        _mapCreator.map[new Vector2(firstPos.x, firstPos.z)] = _choi�edBlocks[1];
        _choi�edBlocks[1].transform.position = firstPos;
        _mapCreator.map[new Vector2(secondePos.x, secondePos.z)] = block;

        //_OnBlocksSwap?.Invoke();
        StartCoroutine(CheckWinCoroutine());
    }
    public IBlockState CheckBlockList(Block block)
    {
        if (_choi�edBlocks.Count < 2)
        {
            ChangeBlocksState(block);
            return new IsChoicedBlockState();
        }
        else if (_choi�edBlocks.Count == 2)
        {
            SwapPosition();
            //_OnBlocksSwap?.Invoke();
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
        }
        //_OnBlocksSwap?.Invoke();
        if (_colorBlockTypes.Contains(block.blockType))
        {
            state = new CanBeChoicedBlockState();
        }
        else if (block.blockType == Blocks.Free)
        {
            state = new CantBeChoicedBlockState();
        }
        _choi�edBlocks.Clear();
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
                if (blockType == Blocks.Free)
                {
                    _mapCreator.map[adjacentPosition].blockState = new CanBeChoicedBlockState();
                }
            }
        }
    }
    private IEnumerator CheckWinCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _OnBlocksSwap?.Invoke();
    }
}
