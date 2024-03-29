﻿using System;
using UnityEngine;

namespace Ambush
{
    public class SimpleAttackController : IActionController
    {
        //Clickeao en la barra
        private bool active;


        public ThrowableAnimationFactory animationFactory;

        public BoardAgent Attacker;

        [SerializeField] public int cost = 1;

        public int damage = 5;
        public BoardAgent Defender;
        public int range = 1;

        public BoardFaction targetFaction = BoardFaction.Enemy;

        public Sprite uiSprite;

        public int Cost()
        {
            return cost;
        }

        public Sprite UISprite()
        {
            return uiSprite;
        }

        public void OnSkillHover(PlayerBehaviour playerBehaviour)
        {
            // SHOW RANGE
            Debug.Log(playerBehaviour.position.ToString());
            AreaView.ShowRange(Range.Circle(playerBehaviour.position, range));
        }

        public void OnSkillExitHover(PlayerBehaviour playerBehaviour)
        {
            // HIDE RANGE
            if (!active)
            {
                AreaView.HideArea(); //TODO reset range?
                AreaView.HideRange();
                AreaView.ResetView();
            }
            //playerBehaviour.ResetRange();
        }

        public void OnSkillActivate(PlayerBehaviour playerBehaviour)
        {
            active = true;
        }

        public void OnSkillCancel(PlayerBehaviour playerBehaviour)
        {
            //playerBehaviour.RegisterAction(this);
            playerBehaviour.ResetRange();
            active = false;
        }

        public void OnNodeEnter(PlayerBehaviour playerBehaviour, Node node)
        {
            //AreaView.ShowArea(Range.Ring(node, range));
            AreaView.ShowArea(Map.Circle(node, range));
            //AreaView.ShowArea( PathFinder.MoveArea(node, range, targetFaction));
            if (!GetValidTargets(playerBehaviour, node)) return;
            if (!CanExecuteAction()) return;
            ExecuteAction(true);
        }

        public void OnNodeExit(PlayerBehaviour playerBehaviour, Node node)
        {
            if (!GetValidTargets(playerBehaviour, node)) return;
            Defender.previewHealth = Defender.currentHealth;
        }

        public void OnNodePress(PlayerBehaviour playerBehaviour, Node node)
        {
            // ThrowableAnimationCommand anim = animationFactory.Generate(playerBehaviour.position, node);
            // AnimationInvoker.Enqueue(anim);
            AreaView.HideArea();
            AreaView.HideRange();
            AreaView.ResetView();
            var action =
                new SimpleAttackAction(damage, playerBehaviour.position, node, animationFactory);
            ActionSystem.Add(action);

            if (node.occupant == null)
                if (!GetValidTargets(playerBehaviour, node))
                {
                    playerBehaviour.ExpendAction(this);
                    return;
                }

            if (!CanExecuteAction()) return;
            ExecuteAction(false);
        }

        public void ApplyAction()
        {
            //calcute damg
        }

        public void ExecuteAction(bool preview)
        {
            var armor = Defender.GetStatModifier(StatType.Armor);
            var damage = Attacker.GetStatModifier(StatType.PhysicalDamage) + this.damage;
            if (preview)
                Defender.previewHealth = Defender.currentHealth - Math.Max(0, damage - armor);
            else
                Defender.currentHealth = Defender.currentHealth - Math.Max(0, damage - armor);

            Attacker = null;
            Defender = null;
        }

        //Can be moved to the interface
        //Can be used to check externally (blocks, traps, counters)
        public bool CanExecuteAction()
        {
            return Attacker.currentHealth > 0 && Defender.currentHealth > 0;
        }

        private bool GetValidTargets(PlayerBehaviour playerBehaviour, Node node)
        {
            if (playerBehaviour?.boardAgent == null) return false;

            var enemy = node?.occupant as BoardAgent;

            if (enemy == null)
                return false;

            //if (enemy.faction == playerBehaviour.boardAgent.faction)
            //    return false;

            Attacker = playerBehaviour.boardAgent;
            Defender = enemy;
            return true;
        }
    }
}