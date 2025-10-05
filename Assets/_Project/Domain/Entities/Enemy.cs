namespace ProjectName.Domain.Entities
{
  public class Enemy
  {
    public int Health { get; private set; } = 50;
    public void TakeDamage(int damage)
    {
      Health -= damage;
    }
  }
}
