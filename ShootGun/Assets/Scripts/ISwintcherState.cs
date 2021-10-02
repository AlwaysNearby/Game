using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public interface ISwitcherState
{
   public void Switch<T>() where T : PlayerBaseState;
}
