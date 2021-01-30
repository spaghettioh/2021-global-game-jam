using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SpaghettiOh.RandomAudioPlayer
{
  [System.Serializable]
  [RequireComponent(typeof(AudioSource))]
  public class RandomAudioPlayer : MonoBehaviour
  {
    AudioSource audioSource;
    float sourcePitch;

    [Tooltip("Add audio files to be randomly played back.")]
    public List<AudioClip> audioClips;
    [Tooltip("Useful for more (and subtler) sound variation, e.g. footsteps.")]
    public bool randomizePitch = true;
    [Tooltip("Max pitch adjustment up & down relative to source component.")]
    [Range(0f, 1.0f)]
    public float pitchRadius = 0.3f;

    private void Start()
    {
      audioSource = GetComponent<AudioSource>();
      // Grab original component value in case prefab instance has changes.
      sourcePitch = audioSource.pitch;
    }

    public void PlayRandomAudio()
    {
      // Grab a random audio clip.
      AudioClip clipChoice = audioClips[Random.Range(0, audioClips.Count)];

      // Adjust the pitch each time, if configured.
      if (randomizePitch)
      {
        audioSource.pitch = Random.Range(sourcePitch - pitchRadius,
            sourcePitch + pitchRadius);
      }

      // Play the selected clip.
      audioSource.PlayOneShot(clipChoice);
    }

    public void Stop()
    {
      audioSource.Stop();
    }
  }
}
