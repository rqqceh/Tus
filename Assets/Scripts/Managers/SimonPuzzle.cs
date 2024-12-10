using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**************************************************
 * Attached to: idk
 * Purpose: simon puzzle interact / game
 * Author: reece
 * Version: 1.0
 *************************************************/

public class SimonPuzzle : MonoBehaviour
{
    [SerializeField] GameObject fromObject;
    [SerializeField] float rayMaxDistance = 30f;

    private TusInputAction controls;

    private List<string> gameActions = new List<string>();
    private List<string> madeActions = new List<string>();

    // Start is called before the first frame update

    private void Awake()
    {
        controls = new TusInputAction();
    }

    void OnEnable()
    {
        controls.Enable();

        controls.DominantArm_RightHanded.ObjectInteract.performed += ctx => Interact();

        gameActions.Add("Red");
        gameActions.Add("Green");
        gameActions.Add("Blue");
        gameActions.Add("Yellow");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interact()
    {
        Debug.Log("Simon interact started");

        RaycastHit hit;
        Physics.Raycast(fromObject.transform.position, fromObject.transform.forward, out hit, rayMaxDistance);

        if (hit.transform == null)
            return;

        if (hit.transform.gameObject.name == "SimonRed")
        {
            if (gameActions[0] == "Red")
            {

            }
        }

    }
}
