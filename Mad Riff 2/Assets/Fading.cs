using UnityEngine;

public class Fading: MonoBehaviour {
    
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    public void OnGui()
    {
        alpha += fadeDir * fadeSpeed  * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

    }

    //sets fadeDir to the direction paramater making the scene fade in if -1 and of if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    // This method is called when a level is loaded It takes loaded level index (int) as Applier pamater so you can limit the fade in to certain scenes
    public void OnLevelWasLoaded()
    {
        //alpha = 1; // use this if the alpha is no
        BeginFade(-1);
    }
    
}