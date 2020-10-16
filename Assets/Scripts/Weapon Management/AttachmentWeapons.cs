using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Proekt.WeaponManagement
{
    /// <summary>
    /// Responsible for attaching the weapon to the target.
    /// </summary>
    #region Attributes
    [AddComponentMenu("Proekt/Weapon Management/Attachment Weapons")]
    [RequireComponent(typeof(Collider2D))]
    [DisallowMultipleComponent]
    #endregion
    public class AttachmentWeapons : MonoBehaviour
    {
        #region Classes
        [Serializable] public class AttachEvent : UnityEvent<Weapon> { }
        #endregion

        #region Fields
        [SerializeField] private Transform m_Content;
        [SerializeField] private AttachEvent m_OnAttach;
        [SerializeField] private List<Weapon> m_Weapons;
        #endregion

        private void Start()
        {
            if (m_Content == null)
            {
                m_Content = EmptyObject.Create("Content", transform).transform;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision != null)
            {
                TryAttach(collision.gameObject.GetComponent<Weapon>());
            }
        }

        #region Propertys
        public Transform content { get => m_Content; }

        public AttachEvent onAttach { get => m_OnAttach; set => m_OnAttach = value; }

        public int numberWeapons { get => m_Weapons.Count; }
        #endregion

        #region Methods
        /// <summary>
        /// Attach a weapon to a target
        /// </summary>
        /// <param name="weapon"></param>
        private void TryAttach(Weapon weapon)
        {
            if (weapon != null)
            {
                weapon.rigidbody.bodyType = RigidbodyType2D.Static;
                weapon.rigidbody.transform.SetParent(m_Content);
                m_Weapons.Add(weapon);
                m_OnAttach.Invoke(weapon);
            }
        }

        /// <summary>
        /// Detach the weapon from the target
        /// </summary>
        /// <param name="weapon"></param>
        public void TryDetach(Weapon weapon)
        {
            if (m_Weapons.Contains(weapon))
            {
                m_Weapons.Remove(weapon);
                weapon.rigidbody.transform.parent = null;
                weapon.rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        #endregion
    }
}
