using UnityEngine;
using ProjectName.Domain.Interfaces;

namespace ProjectName.Infrastructure.Input
{
  public class UnityInputService : IInputService
  {
    public bool IsAttackPressed()
    {
      return Input.GetKeyDown(KeyCode.Space);
    }
  }
}
