using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private ChoiceHandler _choiceHandler;
    [SerializeField] private BlockFactory _blockFactory;
    [SerializeField] private GameObject _winPanel;

    private const int COLOR_CHECKING_COUNT = 3;

    private void Awake()
    {
        _choiceHandler._OnBlocksSwap += CheckWin;
    }

    public void CheckWin()
    {
        //Debug.Log("CheckWin");
        int counter = 0;
        foreach (WinCheckingRay winCheckingRay in _blockFactory.winCheckingRays)
        {
            counter += winCheckingRay.CheckWin();
        }
        if (counter == COLOR_CHECKING_COUNT)
        {
            Win();
        }
    }

    private void Win()
    {
        _winPanel.SetActive(true);
        //Debug.Log("win");
    }
}
