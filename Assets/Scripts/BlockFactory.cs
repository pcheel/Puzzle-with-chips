using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    //[SerializeField] private Dictionary<Blocks, GameObject> _blockVariants;
    [SerializeField] private BlockPackSO _blockPackSO;

    private void Awake()
    {
        //_blockPack = _blockPackSO._blockPack;

    }

    public Block CreateBlock(Blocks blockType)
    {
        GameObject block;
        switch (blockType)
        {
            case Blocks.Red:
                block = Instantiate(_blockPackSO._redBlock);
                break;
            case Blocks.Blue:
                block = Instantiate(_blockPackSO._blueBlock);
                break;
            case Blocks.Green:
                block = Instantiate(_blockPackSO._greenBlock);
                break;
            case Blocks.Free:
                block = Instantiate(_blockPackSO._freeBlock);
                break;
            case Blocks.Stationary:
                block = Instantiate(_blockPackSO._stationaryBlock);
                break;
            default:
                block = null;
                break;
        }
        return block.GetComponent<Block>();
    }
}
