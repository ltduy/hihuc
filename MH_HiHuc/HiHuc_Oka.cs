﻿using MH_HiHuc.Strategies;
using MH_HiHuc.Base;
using Robocode;

namespace MH_HiHuc
{
    public class HiHuc_Oka : HiHucCore
    {
        public override void Run()
        {
            if (Others >= 5)
            {
                Stragegy = new Meele(this);
            }
            else
            {
                Stragegy = new Solo(this);
            }
            Stragegy.Init();

            while (true)
            {
                Stragegy.Run();
            }
        }

        public override void OnRobotDeath(RobotDeathEvent evnt)
        {
            base.OnRobotDeath(evnt);
            var _enemyCount = EnemyCount();
            var _teamCount = TeamCount();
            var _turn = 3;
            if (((_enemyCount <= _turn && _teamCount <= _enemyCount) || (_teamCount <= _enemyCount && _teamCount <= _turn)) && !(Stragegy is Solo))
            {
                // Oka go
                Stragegy = new Solo(this);
                Stragegy.Init();
            }
        }
    }
}
