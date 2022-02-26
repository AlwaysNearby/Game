using System.Collections;
using UnityEngine;

namespace Enemies
{
	public class MeleeGoblin : Goblin
	{
		private void FixedUpdate()
		{
			Move(transform.forward);
		}
	}
}