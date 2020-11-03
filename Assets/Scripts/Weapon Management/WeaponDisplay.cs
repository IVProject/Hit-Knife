using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Proekt.WeaponManagement
{
    [RequireComponent(typeof(Text))]
    public class WeaponDisplay : MonoBehaviour
    {
        [SerializeField] private WeaponSpawner m_WeaponSpawner;

        private Text m_Label;
        private UnityAction m_Show;

        private void OnEnable()
        {
            m_Label = GetComponent<Text>();


        }

        private void OnDisable()
        {
            
        }

        public WeaponSpawner weaponSpawner { get => m_WeaponSpawner; set => m_WeaponSpawner = value; }

        public void Show()
        {

        }
    }
}
