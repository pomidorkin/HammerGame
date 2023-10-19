using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    //[SerializeField] AudioSource audioSourceMuted;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float delayLength = 1.0f;
    private AudioDataSelector audioDataSelector;
    [SerializeField] EventSubcriber eventSubcriber;



    private void Awake()
    {
        audioDataSelector = FindObjectOfType<AudioDataSelector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MyExposedParam", -80.0f);
        //audioSource.PlayDelayed(delayLength);
        ConfigureAudioData();
    }

    public void SetVolume(float val)
    {
        audioSource.volume = val;
    }

    public void PauseAudio()
    {
        audioSource.Pause();
        //audioSourceMuted.Pause();
    }

    public void ResumeAudio()
    {
        audioSource.Play();
        //audioSourceMuted.Play();
    }

    /*public AudioSource GetAudioSource()
    {
        return audioSourceMuted;
    }*/

    private void ConfigureAudioData()
    {
        audioSource.clip = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].loudTrack;
        //audioSourceMuted.clip = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].silentBeatTrack;
        eventSubcriber.trackLength = audioSource.clip.length;
        eventSubcriber.beats = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].beats;
        eventSubcriber.visualizerManager.animTriggerValue = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].triggerValue;
        eventSubcriber.visualizerManager.band = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].bufferBand;
        eventSubcriber.visualizerManager.timeLimit = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].timeLimit;
        //audioSourceMuted.Play();
        audioSource.PlayDelayed(delayLength);
    }
}
