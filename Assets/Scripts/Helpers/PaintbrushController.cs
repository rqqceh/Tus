using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PaintbrushController - Controls the player's paintbrush and paints on textures

public class PaintbrushController : MonoBehaviour
{
    [SerializeField] private GameObject fromObject; // The object the ray is pointing at to paint
    [SerializeField] private Texture2D brush; // The brush texture used to paint
    [SerializeField] private float brushSize; // The radius / size of the brush, with 1 being the default brush texture size
    [SerializeField] private float targetTexelDensity; // The target pixels per area for all paintable objects
    [SerializeField] private Color paintColor; // The color the brush is painting with
    [SerializeField] private float rayMaxDistance; // The max distance the ray can paint

    private float paintRemaining; // The remaining paint capacity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Paints the object in front of the ray
    void PaintObject()
    {

    }

    // Paints the texture given at the given uv coordinate
    void PaintTexture(Vector2 uv, Texture2D texture)
    {

    }
}
