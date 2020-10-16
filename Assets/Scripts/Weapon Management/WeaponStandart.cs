using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Proekt.WeaponManagement
{
    public class WeaponStandart : Weapon
    {
        [SerializeField] private UnityEvent m_OnHitWeapon;

        protected override void CollisionHandling(Collision2D collision)
        {
            if(IsThereComponent<Weapon>(collision.gameObject))
            {
                m_OnHitWeapon.Invoke();
            }
        }
    }
}