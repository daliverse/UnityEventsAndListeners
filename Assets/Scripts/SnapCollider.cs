using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCollider : MonoBehaviour
{

    Interactable occupied;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        

        Events.OnColliderEnter += other.GetComponent<Interactable>().ChangeColor;


    }
    /*
        // if an Interactable collided ...
        // and it's not already snapped ...
        // and it's not already colliding ...
        Interactable iO = other.GetComponentInParent<Interactable>();
        if (occupied || iO == null || iO.isSnapped() || iO.isPlaced()) { return; }



        // then snap its center to my parent's center ...
        // and make it drop itself from the mouse pointer ...
        iO.transform.position = transform.position;
        iO.transform.rotation = transform.rotation;

        iO.snapped = true;
        iO.placed = true;
        iO.GetComponent<Rigidbody>().isKinematic = true;

        occupied = iO;

        /** FIXME Make it like this, using an event listener
        // then wait for the user to drop it ...
        // and when that happens see if it's still colliding ...
        // if so, snap it to me
        **//*

    }
*/

    private void OnTriggerExit(Collider other)
    {
        Events.OnColliderEnter -= other.GetComponent<Interactable>().ChangeColor;

    }

    void SnapToMe()
    {

    }


}
