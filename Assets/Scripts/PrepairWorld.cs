using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrepairWorld : MonoBehaviour
{
    [SerializeField] GameObject[] paintableObjects;

    private GameObject[] allPaintalbeObjects;

    private void Start() {


        // List<GameObject> allObjects = new List<GameObject>();

        // foreach (GameObject paintableObject in paintableObjects) 
        // {
        //     allObjects.Add(getAllChildObjects(paintableObject)[0]);
        // }
        // allPaintalbeObjects = allObjects.ToArray();


        // foreach (GameObject obj in allPaintalbeObjects)
        // {
        //     Debug.Log(obj.name );
        // }
    }

    private GameObject[] getAllChildObjects(GameObject gameObject)
    {
        if (gameObject.transform.childCount <= 0)
        {
            return new GameObject[1] {gameObject};
        }
        else
        {
            List<GameObject> childObjects = new List<GameObject>();

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                childObjects.Add(getAllChildObjects(gameObject.transform.GetChild(i).gameObject)[0]);

            }
            return childObjects.ToArray();
        }
    }


    private void AddTextureToObjects()
    {
        foreach (GameObject gameObject in allPaintalbeObjects)
        {
            
        }
    }
}
