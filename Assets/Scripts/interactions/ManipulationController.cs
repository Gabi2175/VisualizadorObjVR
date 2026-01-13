using UnityEngine;

public class ManipulationController : MonoBehaviour
{
    public DenturesManager denturesManager;

    public ManipulationMode currentMode = ManipulationMode.Whole;

    private Vector3 rootInitialPos;
    private Quaternion rootInitialRot;

    private Vector3 superiorInitialPos;
    private Quaternion superiorInitialRot;

    private Vector3 inferiorInitialPos;
    private Quaternion inferiorInitialRot;

    void Start()
    {
        SetMode(ManipulationMode.Whole);
    }

    public void OnPatientLoaded()
    {
        CacheInitialTransforms();
        UpdateColliders();
    }

    void CacheInitialTransforms()
    {
        Transform root = denturesManager.GetRoot();
        Transform sup = denturesManager.GetSuperior();
        Transform inf = denturesManager.GetInferior();

        if (root)
        {
            rootInitialPos = root.position;
            rootInitialRot = root.rotation;
        }

        if (sup)
        {
            superiorInitialPos = sup.localPosition;
            superiorInitialRot = sup.localRotation;
        }

        if (inf)
        {
            inferiorInitialPos = inf.localPosition;
            inferiorInitialRot = inf.localRotation;
        }
    }

    public void SetMode(ManipulationMode mode)
    {
        currentMode = mode;
        UpdateColliders();
        Debug.Log($"Modo ativo: {currentMode}");
    }

    void UpdateColliders()
    {
        SetCollider(denturesManager.GetRoot(), currentMode == ManipulationMode.Whole);
        SetCollider(denturesManager.GetSuperior(), currentMode == ManipulationMode.superior);
        SetCollider(denturesManager.GetInferior(), currentMode == ManipulationMode.inferior);
    }

    void SetCollider(Transform t, bool state)
    {
        if (!t) return;

        Collider col = t.GetComponent<Collider>();
        if (col)
            col.enabled = state;
    }

    public void ResetObject()
    {
        Transform root = denturesManager.GetRoot();
        Transform sup = denturesManager.GetSuperior();
        Transform inf = denturesManager.GetInferior();

        if (root)
        {
            root.position = rootInitialPos;
            root.rotation = rootInitialRot;
        }

        if (sup)
        {
            sup.localPosition = superiorInitialPos;
            sup.localRotation = superiorInitialRot;
        }

        if (inf)
        {
            inf.localPosition = inferiorInitialPos;
            inf.localRotation = inferiorInitialRot;
        }

        Debug.Log("Paciente resetado para posição inicial");
    }
}
