using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FromCameraPainter : MonoBehaviour
{
    private Camera cam;

    [SerializeField] GameObject mainCamera; 
    [SerializeField] Texture2D brush;
    [SerializeField] float brushSize = .5f;
    [SerializeField] float targetTexelDensity = .5f;
    [SerializeField] Color paintColor = Color.white;
    public float paintRemaining = 50f;

    // Start is called before the first frame update
    void Start()
    {
        cam = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && paintRemaining >= 0)
        {
            PaintObject();
            paintRemaining -= 5 * Time.deltaTime;

            //Debug.Log(paintRemaining);
        }
    }
    
    private void PaintObject()
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit);
        
        
        if(hit.transform == null)
            return;
        
        Texture2D texture = GetOrCreateObjectsTexture(hit.transform.gameObject);

        PaintTexure(hit.textureCoord, texture);
    }

    

    private Texture2D GetOrCreateObjectsTexture(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Texture2D texture;

        if(renderer.material.mainTexture == null)
        {
            //does not have a texture. Creates a new texute
            renderer.material.mainTexture = ObjectStatisticsUtility.CreateObjectTextue(gameObject, targetTexelDensity);
            texture = (Texture2D)renderer.material.mainTexture;
        }
        else
        {
            // has a texture, uses existing texture
            texture = (Texture2D) renderer.material.mainTexture;
        }
        return texture;
    }

    // private Texture2D CreateObjectTextue(GameObject gameObject)
    // {
    //     float uvPersentage = ObjectUVAreaPercentage(gameObject);
    //     float objectArea = ObjectArea(gameObject);

    //     float fullTextureArea = objectArea + ((1 - uvPersentage) * objectArea);
        
    //     int textureSize = (int)Math.Round(Math.Sqrt(fullTextureArea) * targetTexelDensity);

    //     Debug.Log("objectArea: " +  fullTextureArea + " uvPersentage: " + uvPersentage + " textueSize: " + textureSize );
        
    //     return new Texture2D(textureSize, textureSize);
    // }

    //paints the texure at the UV cordenate with diamiter of the brushSize and shape of brush 
    private void PaintTexure(Vector2 uv, Texture2D texture)
    {
        uv.x *= texture.width;
        uv.y *= texture.height; 

        int brushWidth = (int)(brush.width * brushSize);
        int brushHeight = (int)(brush.height * brushSize);

        //paints the paintColor where the r value of the brush is 255
        for(int x = 0; x < brushWidth; x++)
        {
            for (int y = 0; y < brushHeight; y++)
            {
                int currentTextureX = (int)(uv.x + x - (brushWidth / 2));
                int currentTextureY = (int)(uv.y + y - (brushHeight / 2));

                Color brushColor = brush.GetPixel((int)(x / brushSize), (int)(y / brushSize));
                brushColor = Color.Lerp(texture.GetPixel(currentTextureX, currentTextureY), paintColor, brushColor.r);
                texture.SetPixel(currentTextureX, currentTextureY, brushColor);
            }
        }

        texture.Apply();
    }

    // //calculates the area of the object in meters(1 unity unit) squared 
    // private float ObjectArea(GameObject gameObject)
    // {
    //     float area = 0;

    //     Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
    //     for (int i = 0; i < mesh.triangles.Length; i += 3)
    //     {
    //         Vector3 vertA = mesh.vertices[mesh.triangles[i]];
    //         Vector3 vertB = mesh.vertices[mesh.triangles[i + 1]];
    //         Vector3 vertC = mesh.vertices[mesh.triangles[i + 2]];

    //         Vector3 vectorAB = vertB - vertA;
    //         Vector3 vectorAC = vertC - vertA;

    //         Vector3 cros = Vector3.Cross(vectorAB, vectorAC);

    //         area += cros.magnitude;
    //     }
    //     //Debug.Log(area);

    //     return area / 2;
    // }

    // //calculates a # between 0 and 1, 1 being 100% of the uv map corilates to a point on the object
    // private float ObjectUVAreaPercentage(GameObject gameObject)
    // {
    //     float uvArea = 0;

    //     Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
    //     for (int i = 0; i < mesh.triangles.Length; i += 3)
    //     {
    //         Vector2 vertA = mesh.uv[mesh.triangles[i]];
    //         Vector2 vertB = mesh.uv[mesh.triangles[i + 1]];
    //         Vector2 vertC = mesh.uv[mesh.triangles[i + 2]];

    //         Vector2 vectorAB = vertB - vertA;
    //         Vector2 vectorAC = vertC - vertA;

    //         Vector3 cros = Vector3.Cross(vectorAB, vectorAC);

    //         uvArea += cros.magnitude;
    //     }


    //     return uvArea / 2;
    // }

}
