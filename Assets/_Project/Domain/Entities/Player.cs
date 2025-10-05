namespace ProjectName.Domain.Entities
{
  public class Player
  {
    public int Health { get; private set; } = 100;
    public int Attack { get; private set; } = 20;

    public void TakeDamage(int damage)
    {
      Health -= damage;
      if (Health < 0) Health = 0;
    }
  }
}
