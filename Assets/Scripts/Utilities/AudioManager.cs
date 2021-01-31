using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bass;
    public AudioSource chords;
    public AudioSource drums;
    public AudioSource fx;
    public AudioSource melody;


    private void Awake()
    {
        // let the music persist between levels
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    public void FadeIn(AudioSource which)
    {
        while (which.volume < 1)
        {
            which.volume += Time.deltaTime;
        }
    }

    public void FadeInAll()
    {
        while (bass.volume < 1)
        {
            bass.volume += Time.deltaTime;
        }
        while (chords.volume < 1)
        {
            chords.volume += Time.deltaTime;
        }
        while (drums.volume < 1)
        {
            drums.volume += Time.deltaTime;
        }
        while (fx.volume < 1)
        {
            fx.volume += Time.deltaTime;
        }
        while (melody.volume < 1)
        {
            melody.volume += Time.deltaTime;
        }
    }

    public void FadeOut(AudioSource which)
    {
        while (which.volume > 0)
        {
            which.volume -= Time.deltaTime;
        }
    }

    public void FadeOutNonAmbient()
    {
        while (drums.volume > 0)
        {
            drums.volume -= Time.deltaTime;
        }
        while (fx.volume > 0)
        {
            fx.volume -= Time.deltaTime;
        }
        while (melody.volume > 0)
        {
            melody.volume -= Time.deltaTime;
        }
    }

    public void PlayAmbient()
    {
        bass.volume = 1;
        chords.volume = 1;
    }

    public void PlayAll()
    {
        bass.volume = 1;
        chords.volume = 1;
        drums.volume = 1;
        fx.volume = 1;
        melody.volume = 1;
	}
}
