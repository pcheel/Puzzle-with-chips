using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    //private IBlockState _blockState;


    public Action<Block> OnClicked;
    public ChoiceHandler choiceHandler { private get; set; }
    public Blocks blockType { get; set; }
    public IBlockState blockState { get; set; }
    public bool canBeClicked;

    private void Awake()
    {
        OnClicked += Click;
    }

    public void Click(Block block)
    {
        Debug.Log(blockState);
        IBlockState blockStateHelper = blockState.Click(choiceHandler, this);
        if (blockStateHelper != null)
        {
            blockState = blockStateHelper;
        }
    }
}
