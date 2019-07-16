using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1_TrackableEventHandler : DefaultTrackableEventHandler
{
    public static bool object1_get = false;



    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        object1_get = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        object1_get = false;

    }



    #endregion // PROTECTED_METHODS
}