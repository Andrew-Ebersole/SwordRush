using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordRush
{
    public enum EnemyStateMachine
    {
        Idle,
        Move,
        Attack,
        Damaged
    }

    internal class Enemy:GameObject
    {
        private EnemyStateMachine enemyState;
        private int level;
        private int atk;
        private int health;

        public void Damage()
        {

        }
    }
}
