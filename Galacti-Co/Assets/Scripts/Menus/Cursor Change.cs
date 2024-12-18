using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorChange : MonoBehaviour
{
    public Camera m_Camera;
    public Texture2D cursorTexture;       // Base Hand
    public Texture2D cursorTexture2;      // Hand Grab
    public Texture2D cursorTexture3;      // Rock On!
    public float cursorHoldDelay = 0.2f;  

    private Mouse mouse;
    private Coroutine cursorResetCoroutine;

    void Awake()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        mouse = Mouse.current;
    }

    void Update()
    {
        if (mouse == null) return;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            SetCursorWithDelay(cursorTexture2);
        }
    }

    public void OnUIButtonPress()
    {
        //apply for when hit play 
        SetCursorWithDelay(cursorTexture3);
    }

    private void SetCursorWithDelay(Texture2D texture)
    {

        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);

        // Stops all ongoing reset coroutine to prevent conflicts
        if (cursorResetCoroutine != null)
        {
            StopCoroutine(cursorResetCoroutine);
        }

        cursorResetCoroutine = StartCoroutine(ResetCursorAfterDelay());
    }

    private IEnumerator ResetCursorAfterDelay()
    {
        yield return new WaitForSeconds(cursorHoldDelay);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
