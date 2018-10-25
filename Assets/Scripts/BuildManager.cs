using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public bool buildMode;
    public Text isBuildingMessage;
    public GameObject prefabToSpawn;


    // Use this for initialization
    void Start()
    {
        //buildMode = false;

        isBuildingMessage.text = buildMode ? "Building mode is ON" : "Building mode is OFF";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            buildMode = !buildMode;
            isBuildingMessage.text = buildMode ? "Building mode is ON" : "Building mode is OFF";
        }
        if (buildMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(prefabToSpawn, new Vector3(hit.point.x, 0, hit.point.z), transform.rotation);
                }
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Alpha1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(prefabToSpawn, new Vector3(hit.point.x, 0, hit.point.z), transform.rotation);
                }
            }
        }
    }
}
