using UnityEngine;

public class ScreenBordersAndWrap : MonoBehaviour
{
    Camera cam;
    float left, right, top, bottom;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        UpdateBounds();
        ApplyHorizontalWrap();
        ApplyVerticalClamp();
    }

    void UpdateBounds()
    {
        float ortho = cam.orthographicSize;
        top    = cam.transform.position.y + ortho;
        bottom = cam.transform.position.y - ortho;
        float width = ortho * cam.aspect;
        right = cam.transform.position.x + width;
        left  = cam.transform.position.x - width;
    }

    void ApplyHorizontalWrap()
    {
        Vector3 p = transform.position;
        if (p.x > right) p.x = left;
        if (p.x < left)  p.x = right;
        transform.position = p;
    }

    void ApplyVerticalClamp()
    {
        Vector3 p = transform.position;
        p.y = Mathf.Clamp(p.y, bottom, top);
        transform.position = p;
    }
}
