using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proekt.WeaponManagement
{
    /// <summary>
    /// 
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [DisallowMultipleComponent]
    #endregion
    public abstract class Weapon : MonoBehaviour
    {
        private Rigidbody2D m_Rigidbody;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionHandling(collision);
        }

        public new Rigidbody2D rigidbody { get => m_Rigidbody != null ? m_Rigidbody : m_Rigidbody = GetComponent<Rigidbody2D>(); }

        protected abstract void CollisionHandling(Collision2D collision);

        protected bool IsThereComponent<T>(GameObject obj)
        {
            return obj.GetComponent<T>() != null ? true : false;
        }
    }
}
