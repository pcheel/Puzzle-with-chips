public class IsChoicedBlockState : IBlockState
{
    public IBlockState Click(ChoiceHandler choiceHandler, Block block)
    {
        choiceHandler.ReturnBlockToDefaultPosition(block);
        return choiceHandler.ReturnBlocksToDefaultState(block);
    }
}
