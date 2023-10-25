using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
	[SerializeField] AudioManager audioManager;
	[SerializeField] GameObject volumePopup;
	[SerializeField] GameObject loudIcon;
	[SerializeField] GameObject muteIcon;
	private bool muted = false;

	public void Start()
	{
		//Adds a listener to the main slider and invokes a method when the value changes.
		volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
		volumeSlider.value = 1.0f;
	}

	// Invoked when the value of the slider changes.
	public void ValueChangeCheck()
	{
		audioManager.SetVolume(volumeSlider.value);
        if (volumeSlider.value <= 0 && !muted)
        {
			muted = true;
			muteIcon.SetActive(true);
			loudIcon.SetActive(false);
        }
        else if (muted && volumeSlider.value > 0)
        {

			muteIcon.SetActive(false);
			loudIcon.SetActive(true);
		}
	}

	public void OpenVolumePopup()
    {
		volumePopup.SetActive(true);
	}

	public void CloseVolumePopup()
    {

		volumePopup.SetActive(false);
	}

	public float GetVolume()
    {
		return volumeSlider.value;
    }
}
