using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour {

    //2. define methods to call the events
    //3. subscribe gameobjects to the events
    //4. find a way to call the events

    //1. define delegates and events
    public delegate void ColliderHandler(int duration);

    public static event ColliderHandler OnColliderEnter;
    public static event ColliderHandler OnColliderExit;


    //2. define methods to call the events
    public static void ColliderEnter(int duration)
    {
        if (OnColliderEnter != null)
        {
            OnColliderEnter(duration);
        }
    }

    public static void ColliderExit(int duration)
    {
        if (OnColliderExit != null)
        {
            OnColliderExit(duration);
        }
    }




}
