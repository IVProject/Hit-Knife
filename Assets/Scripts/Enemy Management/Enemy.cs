using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Proekt.EnemyManagement
{
    /// <summary>
    /// Enemy Base Essence.
    /// </summary>
    #region Attributes
    [RequireComponent(typeof(Movement))]
    [DisallowMultipleComponent]
    #endregion
    public abstract class Enemy : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Direction m_InitialDirection;
        [SerializeField] private float m_MaxSpeed;
        [SerializeField] private UnityEvent m_OnDestroy;
        #endregion

        #region Variables
        private Movement m_Movement;
        #endregion

        private void Start()
        {
            TryWakeUp();
        }

        #region Propertys
        public Direction initialDirection { get => m_InitialDirection; }

        public float maxSpeed { get => m_MaxSpeed; }

        public Movement movement { get => m_Movement != null ? m_Movement : m_Movement = GetComponent<Movement>(); }

        public UnityEvent onDestroy { get => m_OnDestroy; set => m_OnDestroy = value; }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        protected abstract void TryWakeUp();

        /// <summary>
        /// Destroy object.
        /// </summary>
        /// <param name="callBack"></param>
        public void Destroy(bool callBack = true)
        {
            if(callBack)
                m_OnDestroy.Invoke();
            Destroy(gameObject);
        }
        #endregion
    }
}
