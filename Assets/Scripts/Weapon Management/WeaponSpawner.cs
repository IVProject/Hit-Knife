﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Proekt.WeaponManagement
{
    /// <summary>
    /// Responsible for creating weapons.
    /// </summary>
    [AddComponentMenu("Proekt/Weapon Management/Spawner")]
    public class WeaponSpawner : MonoBehaviour
    {
        #region Classes
        [Serializable] public class SpawnedEvent : UnityEvent<Weapon> { }
        #endregion

        #region Fields
        [SerializeField] private GameObject m_Prefab;
        [SerializeField] private uint m_Count = 5;
        [SerializeField] private SpawnedEvent m_OnSpawned;
        #endregion

        private void Start()
        {
            TrySpawnWeapon();
        }

        #region Propertys
        public GameObject prefab { get => m_Prefab; set => m_Prefab = value; }

        /// <summary>
        /// The count of weapons to spawn.
        /// </summary>
        public uint count { get => m_Count; }

        public SpawnedEvent onSpawned { get => m_OnSpawned; set => m_OnSpawned = value; }
        #endregion

        #region Methods
        /// <summary>
        /// Try to create a weapon in spawner coordinates.
        /// </summary>
        public void TrySpawnWeapon()
        {
            if (HaveWeapon())
            {
                Weapon weapon = Instantiate(m_Prefab, transform.position, transform.rotation, null).GetComponent<Weapon>();
                m_OnSpawned.Invoke(weapon);
                m_Count--;
            }
        }

        private bool HaveWeapon()
        {
            return m_Count > 0 ? true : false;
        }
        #endregion
    }
}
