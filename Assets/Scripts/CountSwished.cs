using UnityEngine;
using System.Collections;

public class CountSwished : MonoBehaviour
{

    private int targetWidth, targetHeight;
    private Texture2D tex;

    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        targetHeight = cam.targetTexture.height;
        targetWidth = cam.targetTexture.width;
        tex = new Texture2D(targetWidth, targetHeight);
    }

    void OnPostRender()
    {
        int mipLevel = 5;

        tex.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
        tex.Apply();

        int count = 0;
        float avg = 0;

        Color[] pixels = tex.GetPixels(mipLevel);
        foreach (Color color in pixels)
        {
            avg += color.r;
            count++;

        }
        float swished = avg / count;
        Debug.Log(swished * 100);
    }

}