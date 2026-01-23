using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class XRGrabScale : MonoBehaviour
{
    [Header("Scale Settings")]
    public float scaleSpeed = 0.5f;
    public float minScale = 0.1f;
    public float maxScale = 5f;

    [Header("Input Actions")]
    public InputActionProperty scaleUp;
    public InputActionProperty scaleDown;

    private XRGrabInteractable grab;
    private bool isHeld = false;
    public GameObject temp;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(_ => isHeld = true);
        grab.selectExited.AddListener(_ => isHeld = false);
    }

    void OnEnable()
    {
        scaleUp.action.Enable();
        scaleDown.action.Enable();
    }

    void OnDisable()
    {
        scaleUp.action.Disable();
        scaleDown.action.Disable();
    }

    private void Update()
    {
        if (scaleUp.action.IsPressed())
        {
            temp.transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }

        if (scaleDown.action.IsPressed())
        {
            temp.transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }

    /* void Update()
     {
         if (!isHeld) return;

         Vector3 scale = transform.localScale;

         if (scaleUp.action.IsPressed())
         {
             scale += Vector3.one * scaleSpeed * Time.deltaTime;
         }

         if (scaleDown.action.IsPressed())
         {
             scale -= Vector3.one * scaleSpeed * Time.deltaTime;
         }

         float clamped = Mathf.Clamp(scale.x, minScale, maxScale);
         transform.localScale = Vector3.one * clamped;
     }*/
}
