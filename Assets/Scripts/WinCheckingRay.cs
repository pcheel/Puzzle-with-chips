using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckingRay : MonoBehaviour
{

    private Ray _ray;
    private const int CORRECT_BLOCK_MAX = 5;
    public Blocks blockType { get; set; }

    public int CheckWin()
    {
        int correctBlockCounter = 0;
        _ray = new Ray(transform.position, transform.forward);
        var hits = Physics.RaycastAll(transform.position, Vector3.back, 8f);
        //Debug.Log(hits.Length);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.GetComponent<Block>().blockType == blockType)
            {
                //Debug.Log("blockType");
                correctBlockCounter++;
            }
        }
        //Debug.Log($"CheckWinRays/name: {gameObject.name}/ correctHits: {correctBlockCounter}");
        return correctBlockCounter == CORRECT_BLOCK_MAX ? 1 : 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back * 6);
    }
}


