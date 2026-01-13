using UnityEngine;

public class DenturesManager : MonoBehaviour
{
    public Transform denturesAnchor;

    private GameObject currentPatientInstance;

    private Transform root;
    private Transform superior;
    private Transform inferior;

    public void LoadPatient(PatientData data)
    {
        if (currentPatientInstance != null)
            Destroy(currentPatientInstance);

        currentPatientInstance = Instantiate(
            data.patientPrefab,
            denturesAnchor.position,
            denturesAnchor.rotation,
            denturesAnchor
        );

        root = currentPatientInstance.transform;
        superior = root.Find("superior");
        inferior = root.Find("inferior");

        if (!superior || !inferior)
            Debug.LogError("Prefab precisa ter filhos 'superior' e 'inferior'");
    }

    public Transform GetRoot() => root;
    public Transform GetSuperior() => superior;
    public Transform GetInferior() => inferior;
}
