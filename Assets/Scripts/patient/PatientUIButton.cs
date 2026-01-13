using UnityEngine;

public class PatientUIButton : MonoBehaviour
{
    public PatientData patientData;
    public DenturesManager denturesManager;
    public ManipulationController manipulationController;

    public void SelectPatient()
    {
        denturesManager.LoadPatient(patientData);

        if (manipulationController)
        {
            manipulationController.OnPatientLoaded();
            manipulationController.SetMode(ManipulationMode.Whole);
        }
    }
}
