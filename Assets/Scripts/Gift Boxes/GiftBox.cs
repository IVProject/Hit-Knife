using UnityEngine;
using UnityEngine.Events;
using Proekt.WeaponManagement;

namespace Proekt.GiftBoxes
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class GiftBox : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_OnOpening;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Weapon>() != null)
            {
                Open();
                Destroy(gameObject);
            }
        }

        public UnityEvent onOpening { get => m_OnOpening; }

        protected abstract void Give();

        private void Open()
        {
            Give();
            onOpening.Invoke();
        }
    }
}
