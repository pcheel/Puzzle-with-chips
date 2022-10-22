using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    public ChoiceHandler choiceHandler { private get; set; }
    public Blocks blockType { get; set; }
    public IBlockState blockState { get; set; }

    public Action<Block> OnClicked;

    public void Click(Block block)
    {
        IBlockState blockStateHelper = blockState.Click(choiceHandler, this);
        if (blockStateHelper != null)
        {
            blockState = blockStateHelper;
        }
    }
    private void Awake()
    {
        OnClicked += Click;
    }
}
