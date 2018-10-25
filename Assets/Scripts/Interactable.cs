using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public bool placed;
    public bool snapped;

    // Use this for initialization
    void Start() {
        placed = true; //FIXME, if user spawned, s/b picked up
    }

    // Update is called once per frame
    void Update() {
        if (!placed)
        {
            //Get a ray from the camera to the mouse pointer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //check if it collides (with terrain)
            RaycastHit[] hits = Physics.RaycastAll(ray);
            for (int i = 0; i < hits.Length; i++)
            {
                hit = hits[i];
                if (hit.transform.tag == "Floor")
                {
                    //move this to there but at 0 altitude
                    this.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    break;
                }
            }
        }
    }

    public bool isSnapped()
    {
        return snapped;
    }
    public bool isPlaced()
    {
        return placed;
    }

    public void drop()
    {
        // stop following the mouse pointer
        placed = true;
        //Debug.Log("Dropped");
    }


    public void pickup()
    {
        placed = false;
        snapped = false;
        //Debug.Log("picked up");
    }

    public void ChangeColor(int duration)
    {
        if (!LerpColorRunning)
        StartCoroutine("LerpColor", duration);
    }

    bool LerpColorRunning;
    public IEnumerator LerpColor(int duration)
    {

        Material mat = GetComponentInParent<MeshRenderer>().material;

        float smoothness = 0.02f;

        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness / duration; //The amount of change to apply.

        if (mat != null)
        {
            LerpColorRunning = true;

            Color oldColor = mat.color;
            Color newColor = new Color(Random.value, Random.value, Random.value);


            while (progress < 1)
            {
                mat.color = Color.Lerp(oldColor, newColor, progress);
                progress += increment;
                yield return new WaitForSeconds(smoothness);
                LerpColorRunning = false;
            }
        }
    }


}
