using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f; 
    }

    void OnGUI()
    {
        float fps = 1.0f / deltaTime; 
        string fpsText = Mathf.Ceil(fps).ToString(); //rounding

        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white; 
        style.alignment = TextAnchor.UpperRight; 

        
        GUI.Label(new Rect(Screen.width - 100, 10, 100, 30), fpsText, style);
    }
}
