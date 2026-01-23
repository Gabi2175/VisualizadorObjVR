using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class TwoHandScaleInteractable : MonoBehaviour
{
    public float minScale = 0.1f;
    public float maxScale = 5f;

    private XRGrabInteractable grabInteractable;

    private float initialHandsDistance;
    private Vector3 initialScale;
    private bool isTwoHandScaling = false;
    public GameObject temp;
    private Vector3 scalaInicial;
    private bool isGrabbed = false;


    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(HandleSelectEnter);
        grabInteractable.selectExited.AddListener(HandleSelectExit);
    }

    void Update()
    {
        if (grabInteractable.interactorsSelecting.Count == 2)
        {
            if (!isTwoHandScaling)
                BeginTwoHandScale();
            else
                UpdateTwoHandScale();
        }
        else
        {
            if (isTwoHandScaling)
                EndTwoHandScale();
            isTwoHandScaling = false;
        }
    }

    void BeginTwoHandScale()
    {
        Transform handA = grabInteractable.interactorsSelecting[0].transform;
        Transform handB = grabInteractable.interactorsSelecting[1].transform;

        initialHandsDistance = Vector3.Distance(handA.position, handB.position);
        initialScale = transform.localScale;

        scalaInicial = temp.transform.localScale;
        grabInteractable.trackPosition = false;
        grabInteractable.trackRotation = false;
        grabInteractable.trackScale = false;

        isTwoHandScaling = true;
    }

    void EndTwoHandScale()
    {
        grabInteractable.trackPosition = true;
        grabInteractable.trackRotation = true;
        grabInteractable.trackScale = true;
    }

    void UpdateTwoHandScale()
    {
        Transform handA = grabInteractable.interactorsSelecting[0].transform;
        Transform handB = grabInteractable.interactorsSelecting[1].transform;

        float currentDistance = Vector3.Distance(handA.position, handB.position);


        float scaleFactor = currentDistance / initialHandsDistance;
        Vector3 targetScale = initialScale * scaleFactor;

        temp.transform.localScale = scalaInicial * scaleFactor;


        /*float clampedValue = Mathf.Clamp(targetScale.x, minScale, maxScale);
        transform.localScale = new Vector3(clampedValue, clampedValue, clampedValue);*/
    }
    void HandleSelectEnter(SelectEnterEventArgs args)
    {
       
    }
    void HandleSelectExit(SelectExitEventArgs args)
    {

    }
}
