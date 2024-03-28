using UnityEngine;

public class VolumeSetter : MonoBehaviour
{

    private DataManager data_Manager;
    public GameObject audio_source;

    void Start()
    {
        data_Manager = FindObjectOfType<DataManager>();
    }
    private void Update()
    {
        audio_source.GetComponent<AudioSource>().volume = data_Manager.soud_volume;
    }
}
