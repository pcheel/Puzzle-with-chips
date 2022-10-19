using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    [SerializeField] private BlockPackSO _blockPackSO;
    [SerializeField] private ChoiceHandler _choiceHandler;

    private List<Blocks> _colorBlockTypes;

    private void Awake()
    {
        _colorBlockTypes = new List<Blocks>() { Blocks.Red, Blocks.Green, Blocks.Blue };
    }
    public Block CreateBlock(Blocks blockType)
    {
        GameObject blockGO;
        switch (blockType)
        {
            case Blocks.Red:
                blockGO = Instantiate(_blockPackSO._redBlock);
                //blockGO.GetComponent<B>
                break;
            case Blocks.Blue:
                blockGO = Instantiate(_blockPackSO._blueBlock);
                break;
            case Blocks.Green:
                blockGO = Instantiate(_blockPackSO._greenBlock);
                break;
            case Blocks.Free:
                blockGO = Instantiate(_blockPackSO._freeBlock);
                break;
            case Blocks.Stationary:
                blockGO = Instantiate(_blockPackSO._stationaryBlock);
                break;
            default:
                blockGO = null;
                break;
        }
        Block block = blockGO.GetComponent<Block>();
        block.choiceHandler = _choiceHandler;
        block.blockType = blockType;
        if (_colorBlockTypes.Contains(blockType))
        {
            block.blockState = new CanBeChoicedBlockState();
            //Debug.Log($"name = {block.gameObject.name}, type = {blockType}");
        }
        else
        {
            block.blockState = new CantBeChoicedBlockState();
            //Debug.Log($"name = {block.gameObject.name}, type = {blockType}");
        }
        return block;
    }
}
