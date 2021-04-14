using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;

    public AudioSource lobby_music;
    public AudioSource crisis_music;

    bool play_lobby_music;
    bool play_wave_jingle;

    public void PlayLobbyMusic()
    {
        Play(lobby_music);
        Stop(crisis_music);
        play_lobby_music = true;
    }

    public void UnPauseLobbyMusic()
    {
        UnPause(lobby_music);
        play_lobby_music = true;
    }

    public void PlayCrisisMusic()
    {
        Play(crisis_music);
        Stop(lobby_music);
        play_wave_jingle = true;
    }

    private void Play(AudioSource audio_source)
    {
        audio_source.Play();
    }

    private void Pause(AudioSource audio_source)
    {
        audio_source.Pause();
    }

    private void UnPause(AudioSource audio_source)
    {
        audio_source.UnPause();
    }

    private void Stop(AudioSource audio_source)
    {
        audio_source.Stop();
    }

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((!crisis_music.isPlaying) && (play_wave_jingle == true))
        {
            play_wave_jingle = false;
            UnPauseLobbyMusic();
        }

        if (crisis_music.isPlaying)
        {
            ReadjustVolume();
        }

	}
}
