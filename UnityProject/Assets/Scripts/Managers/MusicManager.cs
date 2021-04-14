using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;

    public AudioSource lobby_music;
    public AudioSource crisis_music;

    bool play_lobby_music;
    bool play_crisis_music;

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
        play_crisis_music = true;
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

    private void ReadjustLobbyMusicVolume()
    {
        ActOnLobbyMusicByMonthAndWeek(TimeManager.instance.month, TimeManager.instance.week);
    }

    private void ActOnLobbyMusicByMonthAndWeek(int month, int week)
    {
        switch (month)
        {
            case 4:
                if (week == 2) MusicManager.instance.lobby_music.volume = 1.0f;
                if (week == 3) MusicManager.instance.lobby_music.volume = 0.9f;
                if (week == 4) MusicManager.instance.lobby_music.volume = 0.8f;
                break;
            case 5:
                if (week == 1) MusicManager.instance.lobby_music.volume = 0.7f;
                if (week == 2) MusicManager.instance.lobby_music.volume = 0.6f;
                if (week == 3) MusicManager.instance.lobby_music.volume = 0.5f;
                if (week == 4) MusicManager.instance.lobby_music.volume = 0.4f;
                break;
            case 6:
                if (week == 1) MusicManager.instance.lobby_music.volume = 0.3f;
                if (week == 2) MusicManager.instance.lobby_music.volume = 0.2f;
                if (week == 3) MusicManager.instance.lobby_music.volume = 0.1f;
                if (week == 4) MusicManager.instance.lobby_music.volume = 0.0f;
                break;
            default:
                break;
        }

        if (month > 6) Stop(lobby_music);
    }

    private void ReadjustCrisisMusicVolume() {
        ActOnCrisisMusicByMonthAndWeek(TimeManager.instance.month, TimeManager.instance.week);
    }
    
    private void ActOnCrisisMusicByMonthAndWeek(int month, int week)
    {
        switch (month)
        {
            case 7:
                if (week == 1) MusicManager.instance.crisis_music.volume = 0.0f;
                if (week == 2) MusicManager.instance.crisis_music.volume = 0.1f;
                if (week == 3) MusicManager.instance.crisis_music.volume = 0.2f;
                if (week == 4) MusicManager.instance.crisis_music.volume = 0.3f;
                break;
            case 8:
                if (week == 1) MusicManager.instance.crisis_music.volume = 0.4f;
                if (week == 2) MusicManager.instance.crisis_music.volume = 0.5f;
                if (week == 3) MusicManager.instance.crisis_music.volume = 0.6f;
                if (week == 4) MusicManager.instance.crisis_music.volume = 0.7f;
                break;
            case 9:
                if (week == 1) MusicManager.instance.crisis_music.volume = 0.8f;
                if (week == 2) MusicManager.instance.crisis_music.volume = 0.9f;
                if (week == 3) MusicManager.instance.crisis_music.volume = 1.0f;
                break;
            default:
                break;
        }


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

        if (lobby_music.isPlaying)
        {
            ReadjustLobbyMusicVolume();
        }

        if ((!crisis_music.isPlaying) && (TimeManager.instance.month > 6))
        {
            Play(crisis_music);
        }

        if (crisis_music.isPlaying)
        {
            ReadjustCrisisMusicVolume();
        }

	}
}
