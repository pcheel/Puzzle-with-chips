using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInput : MonoBehaviour
{
    public bool canClick { set { _canClick = value; } }

    private Camera _camera;
    private Ray _ray;
    private bool _canClick = true;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_canClick)
                {
                    Block block = hit.collider.gameObject.GetComponent<Block>();
                    if (block != null)
                    {
                        block.OnClicked?.Invoke(block);
                    }
                }
            }
        }
    }
}
