using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class TwoHandRotationLock : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Quaternion rotationAtTwoHandStart;
    private bool lockingRotation = false;
    int lastInteractorCount = 0;



    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(HandleSelectEnter);
        grab.selectExited.AddListener(HandleSelectExit);

    }

    void LateUpdate()
    {
        if (grab.interactorsSelecting.Count == 2)
        {
            grab.trackPosition = false;
            grab.trackRotation = false;
            
        }


        else
        {
            if(grab.interactorsSelecting.Count == 1&& grab.trackPosition == false)
            {

            }
            grab.trackPosition = true;
            grab.trackRotation = true;
           
        }

    }

    void HandleSelectEnter(SelectEnterEventArgs args)
    {

    }
    void HandleSelectExit(SelectExitEventArgs args)
    {

    }
}
