using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proekt.EnemyManagement.Demeanors;

namespace Proekt.EnemyManagement
{
    public class EnemyNewbie : Enemy
    {
        [SerializeField] private Demeanor m_Demeanor;

        protected override void TryWakeUp()
        {
            if(m_Demeanor!=null)
                StartCoroutine(m_Demeanor.FollowAlgorithm(this));
        }
    }
}
