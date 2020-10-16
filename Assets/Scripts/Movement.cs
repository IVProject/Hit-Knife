using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proekt
{
    /// <summary>
    /// Responsible for object movements.
    /// </summary>
    public class Movement : MonoBehaviour
    {
        private Transform m_TransformCache;

        private void Awake()
        {
            m_TransformCache = transform;
        }

        public void Rotate(Direction direction, float speed)
        {
            Rotate(Vector3.forward * (int)direction * speed);
        }

        public void Rotate(Vector3 eulers)
        {
            m_TransformCache.Rotate(eulers);
        }

        public void Rotate(Vector3 eulers, float angle)
        {
            m_TransformCache.Rotate(eulers, angle);
        }
    }
}
