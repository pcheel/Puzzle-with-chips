using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorForRecorder : MonoBehaviour
{
    [SerializeField] private Texture2D _curcorTexture;
    void Start()
    {
        //var tex = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/tex.png");
        Cursor.SetCursor(_curcorTexture, new Vector2(0.5f, 0.5f), CursorMode.ForceSoftware);
    }
}
