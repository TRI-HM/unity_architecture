using ProjectName.Domain.Entities;
using ProjectName.Domain.Interfaces;

namespace ProjectName.Domain.Services
{
  public class BattleService
  {
    private Player player;
    private Enemy enemy;
    private IAudioService audioService;
    private IInputService inputService;

    public BattleService(Player p, Enemy e, IAudioService audio, IInputService input)
    {
      player = p;
      enemy = e;
      audioService = audio;
      inputService = input;
    }

    public void PlayerAttack()
    {
      enemy.TakeDamage(player.Attack);
    }

    public void EnemyAttack()
    {
      player.TakeDamage(10);
    }

    public void Update()
    {
      if (inputService.IsAttackPressed())
      {
        PlayerAttack();
        audioService.Play("attack_sound");
      }
    }
  }
}