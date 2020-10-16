using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Proekt.EnemyManagement.Demeanors
{
    [CreateAssetMenu(fileName = "New Plain", menuName = "Demeanors/Plain")]
    public sealed class DemeanorPlain : Demeanor
    {
        public override IEnumerator FollowAlgorithm(Enemy enemy)
        {
            Movement movement = enemy.movement;
            while(true)
            {
                movement.Rotate(enemy.initialDirection, enemy.maxSpeed);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
