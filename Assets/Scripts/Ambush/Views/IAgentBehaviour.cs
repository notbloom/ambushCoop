﻿using UnityEngine;

namespace Ambush
{
    public interface IAgentBehaviour
    {
        Transform Transform();
        void PlayTurn();
        void ShowIntent();
        void HideIntent();
        void ShowHP(float hp);
        float CurrentHp();
    }
}