public class CanBeChoicedBlockState : IBlockState
{
    public IBlockState Click(ChoiceHandler choiceHandler, Block block)
    {
        return choiceHandler.Choi�eBlock(block);
    }
}
