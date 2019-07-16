using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2_TrackableEventHandler : DefaultTrackableEventHandler
{
  //  public Animator m_Habitat;
  //  public Animator m_Astronaut;
  //  public static bool isBezierDraw = false;
    public static bool object2_get = false;



#region PROTECTED_METHODS

protected override void OnTrackingFound()
{
    base.OnTrackingFound();
    object2_get = true;
}

protected override void OnTrackingLost()
{
    base.OnTrackingLost();
    object2_get = false;

}



    #endregion // PROTECTED_METHODS
}