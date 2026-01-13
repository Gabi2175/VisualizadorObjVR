using UnityEngine;

[CreateAssetMenu(menuName = "Dentistry/Patient Data")]
public class PatientData : ScriptableObject
{
    public int patientNumber;
    public GameObject patientPrefab;
}
