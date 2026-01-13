using UnityEngine;

public class DebugLoader : MonoBehaviour
{
    public DenturesManager manager;
    public ManipulationController manipulationController;
    public PatientData testPatient;

    void Start()
    {
        manager.LoadPatient(testPatient);

        if (manipulationController != null)
        {
            manipulationController.OnPatientLoaded();
            manipulationController.SetMode(ManipulationMode.Whole);
        }
    }

}
