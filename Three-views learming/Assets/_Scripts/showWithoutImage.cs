using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class showWithoutImage : MonoBehaviour,ITrackableEventHandler {
    TrackableBehaviour _mTrackableBehaviour;
    bool isTrack=false;
   
    Transform childTrans;
    public Canvas _UI;
    void Start () {
        _mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (_mTrackableBehaviour)
            _mTrackableBehaviour.RegisterTrackableEventHandler(this);
       
        childTrans = transform.Find("Eye_prot");

        _UI.enabled = false;
    }
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + _mTrackableBehaviour.TrackableName + " found");
            isTrack = true;
            OnTrackingFound();
            _UI.enabled = true;
        }
        else {
            if(isTrack==true)
            {
                childTrans.parent = null;
                childTrans.localPosition = new Vector3(0, 0, 1f);
            }
        }
        
    }
    protected virtual void OnTrackingFound()
    {
        

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

      
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }
}
