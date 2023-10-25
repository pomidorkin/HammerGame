using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Plugins.Audio.Core;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] AudioMixer mixer;
    //[SerializeField] AudioSource audioSourceMuted;
    //[SerializeField] AudioSource audioSource;
    [SerializeField] SourceAudio sourceAudio; // Test
    [SerializeField] string audioKey;
    [SerializeField] float delayLength = 1.0f;
    private AudioDataSelector audioDataSelector;
    [SerializeField] EventSubcriber eventSubcriber;
    [SerializeField] VolumeManager volumeManager;



    private void Awake()
    {
        audioDataSelector = FindObjectOfType<AudioDataSelector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //mixer.SetFloat("MyExposedParam", -80.0f);
        //audioSource.PlayDelayed(delayLength);
        ConfigureAudioData();
        AudioPauseHandler.Instance.PauseAudio();
        AudioPauseHandler.Instance.UnpauseAudio();
    }

    public void SetVolume(float val)
    {
        //audioSource.volume = val;
        sourceAudio.Volume = val;
    }

    public void PauseAudio()
    {
        //audioSource.Pause();
        AudioPauseHandler.Instance.PauseAudio();
        //audioSourceMuted.Pause();
    }

    public void ResumeAudio()
    {
        //audioSource.UnPause();
        AudioPauseHandler.Instance.UnpauseAudio();
        //audioSourceMuted.Play();
    }

    /*public AudioSource GetAudioSource()
    {
        return audioSourceMuted;
    }*/

    private void ConfigureAudioData()
    {
        //audioSource.clip = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].loudTrack;
        audioKey = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].clip.Key;

        //audioSourceMuted.clip = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].silentBeatTrack;
        //eventSubcriber.trackLength = audioSource.clip.length;
        eventSubcriber.trackLength = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].trackLength;


        eventSubcriber.beats = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].beats;
        eventSubcriber.visualizerManager.animTriggerValue = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].triggerValue;
        eventSubcriber.visualizerManager.band = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].bufferBand;
        eventSubcriber.visualizerManager.timeLimit = audioDataSelector.audioDataObjects[audioDataSelector.selectedAudioData].timeLimit;

        //audioSourceMuted.Play();
        //audioSource.PlayDelayed(delayLength);
        StartCoroutine(PlayDelayedSound(delayLength)); // test

    }

    private IEnumerator PlayDelayedSound(float val)
    {
        yield return new WaitForSeconds(val);
        sourceAudio.Play(audioKey);
        SetVolume(volumeManager.GetVolume());
    }
}
