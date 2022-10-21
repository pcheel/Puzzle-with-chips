using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInput : MonoBehaviour
{
    //[SerializeField] private WinChecker _checker;
    private Camera _camera;
    private Ray _ray;
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;  // Camera.main.ScreenToWorldPoint(Input.mousePosition)
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Block block = hit.collider.gameObject.GetComponent<Block>();
                if (block != null)
                {
                    block.OnClicked?.Invoke(block);
                    //_checker.CheckWin();
                    //Debug.Log("2");
                }
            }
        }
    }
}
