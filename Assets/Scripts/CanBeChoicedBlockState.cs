public class CanBeChoicedBlockState : IBlockState
{
    public IBlockState Click(ChoiceHandler choiceHandler, Block block)
    {
        return choiceHandler.ChoiñeBlock(block);
    }
}
