using UnityEngine;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Services;
using ProjectName.Infrastructure.Audio;
using ProjectName.Infrastructure.Input;
using ProjectName.Domain.Interfaces;

namespace ProjectName.Infrastructure.Managers
{
  public class GameManager : MonoBehaviour
  {
    private BattleService _battle;

    void Start()
    {
      var player = new Player();
      var enemy = new Enemy();

      IAudioService audioService = new UnityAudioService();
      IInputService inputService = new UnityInputService();

      _battle = new BattleService(player, enemy, audioService, inputService);
    }

    void Update()
    {
      _battle.Update();
    }
  }
}