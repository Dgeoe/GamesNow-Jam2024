using Unity.VisualScripting;
using UnityEngine;

public class CursorStates : MonoBehaviour
{
    [SerializeField] private Texture2D cursorDefault;
    [SerializeField] private Texture2D OnDown;
    [SerializeField] private Texture2D[] cursorArray;
    Cursor cursor;
    private int currentframe;
     private float frameTimer;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    void Start()
    {
        Cursor.SetCursor(cursorDefault, new Vector2(10,10), CursorMode.Auto);
        
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0)
        {
            frameTimer += frameRate;
            currentframe = (currentframe + 1) % frameCount;
            Cursor.SetCursor(cursorArray[currentframe], new Vector2(10,10), CursorMode.Auto);

        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click!");
            Cursor.SetCursor(OnDown, new Vector2(10,10), CursorMode.Auto);
        }
    }
}
