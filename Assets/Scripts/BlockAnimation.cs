using UnityEngine;
using DG.Tweening;

public class BlockAnimation : MonoBehaviour
{
    [SerializeField] private float _deltaYPos;
    [SerializeField] private float _timeMove;
    [SerializeField] private PlayerInput _playerInput;

    public void MoveUp(GameObject block)
    {
        _playerInput.canClick = false;
        DOTween.Sequence()
            .Append(block.transform.DOMove(block.transform.position + new Vector3(0f, _deltaYPos, 0f), _timeMove))
            .AppendCallback(() => _playerInput.canClick = true);
    }
    public void MoveDown(GameObject block)
    {
        _playerInput.canClick = false;
        DOTween.Sequence()
            .Append(block.transform.DOMove(block.transform.position - new Vector3(0f, _deltaYPos, 0f), _timeMove))
            .AppendCallback(() => _playerInput.canClick = true);
    }
    public void SwapBlocks(GameObject firstBlock, GameObject secondeBlock)
    {
        _playerInput.canClick = false;
        Vector3 firstBlockPosition = firstBlock.transform.position;
        Vector3 secondeBlockPosition = secondeBlock.transform.position;
        Vector3 newFirstBlockPosition = new Vector3(secondeBlockPosition.x, firstBlockPosition.y, secondeBlockPosition.z);
        Vector3 newSecondeBlockPosition = new Vector3(firstBlockPosition.x, secondeBlockPosition.y, firstBlockPosition.z);
        secondeBlock.transform.DOMove(newSecondeBlockPosition, _timeMove);
        firstBlock.transform.DOMove(newFirstBlockPosition, _timeMove);

        DOTween.Sequence()
            .Append(firstBlock.transform.DOMove(newFirstBlockPosition, _timeMove))
            .Append(firstBlock.transform.DOMove(newFirstBlockPosition - new Vector3(0f, _deltaYPos, 0f), _timeMove))
            .AppendCallback(() => _playerInput.canClick = true);
    }
}
