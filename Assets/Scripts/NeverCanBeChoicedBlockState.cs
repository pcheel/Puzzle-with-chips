public class NeverCanBeChoicedBlockState : IBlockState
{
    public IBlockState Click(ChoiceHandler choiceHandler, Block block)
    {
        return null;
    }
}
