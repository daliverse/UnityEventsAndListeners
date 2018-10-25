using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{

    public int maxDuration = 10;

    Vector3 mousePositionOnDown;
    Interactable draggingObj;


    public delegate void ClickAction();
    public static event ClickAction OnClicked;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //they dropped something
        if (Input.GetMouseButtonUp(0) && draggingObj != null)
        {


            Events.ColliderEnter(Duration());


            draggingObj.drop();
            draggingObj = null;
            return;
        }

        else if (Input.GetMouseButtonDown(0))
        {

            if (OnClicked != null)
            {
                OnClicked();
            }

            mousePositionOnDown = Input.mousePosition;
            //Get a ray from the camera to the mouse pointer
            Ray ray = Camera.main.ScreenPointToRay(mousePositionOnDown);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Interactable iO = hit.collider.GetComponent<Interactable>();
                if (iO)
                {
                    draggingObj = iO;
                    draggingObj.pickup();

                }
            }


        }

    }

    public int Duration()
    {
        int r = Random.Range(1, maxDuration);
        return r;
    }
}
