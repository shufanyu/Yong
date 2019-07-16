/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/
using UnityEngine;

public class ObjectRecoTrackableEventHandler : DefaultTrackableEventHandler
{
    public Animator m_Habitat;
    public Animator m_Astronaut;
   // public static bool isBezierDraw = false;
  //  public bool object1_get = false;

  

    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
 
        m_Habitat.SetBool("IsDoorOpen", true);
        m_Astronaut.SetBool("IsWaving", true);
    //    object1_get = true;
    //    isBezierDraw = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
    //    var linerendererComponents = GetComponentsInChildren<LineRenderer>(true);
        m_Habitat.SetBool("IsDoorOpen", false);
        //   foreach (var component in linerendererComponents)
        //    component.enabled = false;
   //     object1_get = false;
   //     isBezierDraw = false;
    }

    

    #endregion // PROTECTED_METHODS
}