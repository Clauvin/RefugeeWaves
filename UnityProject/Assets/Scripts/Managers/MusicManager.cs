using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource lobby_music;
    public AudioSource wave_jingle;

    bool play_lobby_music;
    bool play_wave_jingle;

    void PlayLobbyMusic()
    {
        Play(lobby_music);
        Stop(wave_jingle);
        play_lobby_music = true;
    }

    void UnPauseLobbyMusic()
    {
        UnPause(lobby_music);
        play_lobby_music = true;
    }

    void PlayWaveJingle()
    {
        Play(wave_jingle);
        Pause(lobby_music);
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((!wave_jingle.isPlaying) && (play_wave_jingle == true))
        {

        }
	}
}
