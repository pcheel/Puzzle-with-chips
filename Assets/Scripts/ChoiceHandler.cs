using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] private BlockAnimation _blockAnimation;
    [SerializeField] private MapCreator _mapCreator;

    //public MapCreator _mapCreator;
    public Action _OnBlocksSwap;

    private List<Block> _choiñedBlocks;
    private List<Blocks> _colorBlockTypes;
    private List<Block> _changedBlocks;
    private List<Vector3> _additionPositions;
    private List<WinCheckingRay> _winChickingRays;

    private void Awake()
    {
        _additionPositions = new List<Vector3>() { 
            new Vector3(0f, 0f, 1f), 
            new Vector3(1f, 0f, 0f), 
            new Vector3(-1f, 0f, 0f), 
            new Vector3(0f, 0f, -1f) };
        _choiñedBlocks = new List<Block>();
        _changedBlocks = new List<Block>();
        _colorBlockTypes = new List<Blocks>() { Blocks.Blue, Blocks.Red, Blocks.Green };
    }
    public IBlockState ChoiñeBlock(Block block)
    {
        _choiñedBlocks.Add(block);
        return CheckBlockList(block);
    }
    private void SwapPosition()
    {
        Vector3 firstPos = _choiñedBlocks[0].transform.position;
        firstPos.y = 0f;
        Vector3 secondePos = _choiñedBlocks[1].transform.position;
        _mapCreator.map[firstPos] = _choiñedBlocks[1];
        _mapCreator.map[secondePos] = _choiñedBlocks[0];
        _blockAnimation.SwapBlocks(_choiñedBlocks[0].gameObject, _choiñedBlocks[1].gameObject);
        StartCoroutine(CheckWinCoroutine());
    }
    public IBlockState CheckBlockList(Block block)
    {
        if (_choiñedBlocks.Count < 2)
        {
            _blockAnimation.MoveUp(block.gameObject);
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
        //_blockAnimation.MoveDown(block.gameObject);
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
    public void ReturnBlockToDefaultPosition(Block block)
    {
        _blockAnimation.MoveDown(block.gameObject);
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
        foreach (Vector3 additionPosition in _additionPositions)
        {
            Vector3 adjacentPosition = position + additionPosition;
            if (_mapCreator.map.ContainsKey(adjacentPosition))
            {
                //Debug.Log($"pos: {adjacentPosition}, type: {_mapCreator.map[adjacentPosition].blockType}");
                Blocks blockType = _mapCreator.map[adjacentPosition].blockType;
                if (blockType == Blocks.Free)
                {
                    //Debug.Log("free");
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
