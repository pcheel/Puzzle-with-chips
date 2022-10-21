using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockAnimation : MonoBehaviour
{
    [SerializeField] private float _deltaYPos;
    [SerializeField] private float _timeMove;

    public void MoveUp(GameObject block)
    {
        block.transform.DOMove(block.transform.position + new Vector3(0f, _deltaYPos, 0f), _timeMove);
    }
    public void MoveDown(GameObject block)
    {
        block.transform.DOMove(block.transform.position - new Vector3(0f, _deltaYPos, 0f), _timeMove);
    }
    public void SwapBlocks(GameObject firstBlock, GameObject secondeBlock)
    {
        Vector3 firstBlockPosition = firstBlock.transform.position;
        Vector3 secondeBlockPosition = secondeBlock.transform.position;
        Vector3 newFirstBlockPosition = new Vector3(secondeBlockPosition.x, firstBlockPosition.y, secondeBlockPosition.z);
        Vector3 newSecondeBlockPosition = new Vector3(firstBlockPosition.x, secondeBlockPosition.y, firstBlockPosition.z);
        secondeBlock.transform.DOMove(newSecondeBlockPosition, _timeMove);
        firstBlock.transform.DOMove(newFirstBlockPosition, _timeMove);

        DOTween.Sequence()
            .Append(firstBlock.transform.DOMove(newFirstBlockPosition, _timeMove))
            .Append(firstBlock.transform.DOMove(newFirstBlockPosition - new Vector3(0f, _deltaYPos, 0f), _timeMove));
    }
}
