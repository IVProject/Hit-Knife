using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proekt.EnemyManagement.Demeanors
{
    /// <summary>
    /// Basic tactics of enemy.
    /// </summary
    public abstract class Demeanor : ScriptableObject
    {
        public abstract IEnumerator FollowAlgorithm(Enemy enemy);
    }
}
