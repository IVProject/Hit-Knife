using UnityEngine;
using UnityEngine.Events;

namespace Proekt.WeaponManagement
{
    /// <summary>
    /// Responsible for throwing weapons.
    /// </summary>
    [AddComponentMenu("Proekt/Weapon Management/Throwing Control")]
    public class WeaponThrowingControl : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float m_Force = 10;
        [SerializeField] private UnityEvent m_OnThrowWeapon;
        [SerializeField] private Weapon m_Weapon;
        #endregion

        #region Propertys
        public float force { get => m_Force; set => m_Force = value; }

        public UnityEvent onThrowWeapon { get => m_OnThrowWeapon; set => m_OnThrowWeapon = value; }

        public Weapon weapon { get => m_Weapon; }
        #endregion

        #region Methods
        public void TryThrowWeapon()
        {
            if (m_Weapon != null)
            {
                m_Weapon.rigidbody.AddForce(Vector2.up * m_Force, ForceMode2D.Impulse);
                m_Weapon = null;
                m_OnThrowWeapon.Invoke();
            }
        }

        public void SetWeapon(Weapon weapon)
        {
            m_Weapon = weapon;
        }
        #endregion
    }
}