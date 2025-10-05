using UnityEngine;
using ProjectName.Domain.Interfaces;

namespace ProjectName.Infrastructure.Audio
{
  public class UnityAudioService : IAudioService
  {
    public void Play(string soundName)
    {
      var clip = Resources.Load<AudioClip>($"Sounds/{soundName}");
      AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }
  }
}