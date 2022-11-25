using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;

    public AudioClip click;
    public AudioClip pass;
    public AudioClip Win;
    public AudioClip BGM;
    public AudioClip reset;

    [Header("Settings")]
    public Slider musicVolumeSlider;
    public Toggle musicMutedToggle;

    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicMutedToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolumeSlider.value;
        audioSource.mute = !musicMutedToggle.isOn;
    }
}
