using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Volume", value);
    }
}