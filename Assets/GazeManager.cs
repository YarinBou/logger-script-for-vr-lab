using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public Camera viewCamera;
    private GameObject lastGazedUpon;

    void Update()
    {
        CheckGaze();
    }

    private void CheckGaze()
    {
        if (lastGazedUpon)
        {
            lastGazedUpon.SendMessage("NotGazingUpon", SendMessageOptions.DontRequireReceiver);
        }
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit[] hits = Physics.RaycastAll(gazeRay, 100f);
        foreach (RaycastHit hit in hits)
        {
            hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
            lastGazedUpon = hit.transform.gameObject;
        }
    }
}
