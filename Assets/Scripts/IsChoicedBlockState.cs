using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsChoicedBlockState : IBlockState
{
    public IBlockState Click(ChoiceHandler choiceHandler, Block block)
    {
        choiceHandler.ReturnBlockToDefaultPosition(block);
        return choiceHandler.ReturnBlocksToDefaultState(block);
        //return new CanBeChoicedBlockState();
        //return null;
    }
}
