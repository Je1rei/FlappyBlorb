using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public GameObject ObjectMusic;

    private float _musicVolume = 0.02f;
    private float _defaultMusicVolume = 0.02f;

    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        _musicVolume = PlayerPrefs.GetFloat("Volume");

        audioSource.volume = _musicVolume;
        volumeSlider.value = _musicVolume;
    }

    private void Update()
    {
        audioSource.volume = _musicVolume;
        PlayerPrefs.SetFloat("Volume", _musicVolume);
    }

    public void UpdateVolume(float volume)
    {
        _musicVolume = volume;
    }

    public void MusicReset()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.DeleteKey("Volume");
            Debug.Log("Удален ключ Volume");
        }

        audioSource.volume = _defaultMusicVolume;
        volumeSlider.value = _defaultMusicVolume;
    }
}
