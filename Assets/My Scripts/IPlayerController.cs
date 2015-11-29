using UnityEngine;
using System;

namespace UnityTest
{
	public interface IPlayerController
	{
		void decrementPlayerHealth();
    void respawn();
    float getHP();
	}
}
