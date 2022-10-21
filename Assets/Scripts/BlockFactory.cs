using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    [SerializeField] private BlockPackSO _blockPackSO;
    [SerializeField] private ChoiceHandler _choiceHandler;

    private List<Blocks> _colorBlockTypes;
    private List<WinCheckingRay> _winCheckingRays;

    public List<WinCheckingRay> winCheckingRays => _winCheckingRays;

    private void Awake()
    {
        _colorBlockTypes = new List<Blocks>() { Blocks.Red, Blocks.Green, Blocks.Blue };
        _winCheckingRays = new List<WinCheckingRay>();
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
        }
        else
        {
            block.blockState = new CantBeChoicedBlockState();
        }
        return block;
    }

    public List<WinCheckingRay> CreateWinCheckingBlock()
    {
        _winCheckingRays = new List<WinCheckingRay>();
        GameObject redRayGO = Instantiate(_blockPackSO._redRayBlock);
        GameObject greenRayGO = Instantiate(_blockPackSO._greenRayBlock);
        GameObject blueRayGO = Instantiate(_blockPackSO._blueRayBlock);
        WinCheckingRay redRay = redRayGO.GetComponent<WinCheckingRay>();
        WinCheckingRay greenRay = greenRayGO.GetComponent<WinCheckingRay>();
        WinCheckingRay blueRay = blueRayGO.GetComponent<WinCheckingRay>();
        redRay.blockType = Blocks.Red;
        greenRay.blockType = Blocks.Green;
        blueRay.blockType = Blocks.Blue;
        _winCheckingRays.Add(redRay);
        _winCheckingRays.Add(greenRay);
        _winCheckingRays.Add(blueRay);
        return _winCheckingRays;
    }
}
