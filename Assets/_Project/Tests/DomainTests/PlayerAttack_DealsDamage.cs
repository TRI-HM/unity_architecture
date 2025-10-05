using UnityEngine;
using NUnit.Framework;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Interfaces;
using ProjectName.Domain.Services;

namespace ProjectName.Tests.DomainTests
{
  public class FakeInput : IInputService
  {
    public bool IsAttackPressed() => true;
  }

  public class FakeAudio : IAudioService
  {
    public void Play(string s) => Debug.Log($"Sound: {s}");
  }

  public class PlayerAttackTests
  {
    [Test]
    public void PlayerAttack_DealsDamage()
    {
      var player = new Player();
      var enemy = new Enemy();
      var service = new BattleService(player, enemy, new FakeAudio(), new FakeInput());

      service.Update();

      Assert.Less(enemy.Health, 50);
    }
  }
}
