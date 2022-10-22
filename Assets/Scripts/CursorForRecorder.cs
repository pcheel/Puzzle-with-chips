using UnityEngine;

public class CursorForRecorder : MonoBehaviour
{
    [SerializeField] private Texture2D _curcorTexture;
    void Start()
    {
        Cursor.SetCursor(_curcorTexture, new Vector2(0.5f, 0.5f), CursorMode.ForceSoftware);
    }
}
