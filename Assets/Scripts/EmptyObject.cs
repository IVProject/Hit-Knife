using System;
using UnityEngine;

namespace Proekt
{
    /// <summary>
    /// Class for creating empty GameObjects
    /// </summary>
    public sealed class EmptyObject
    {
        public static GameObject Create(string name, Transform parent, params Type[] components)
        {
            var gameObject = new GameObject(name, components);
            SetParent(gameObject, parent);
            
            return gameObject;
        }

        public static GameObject Create(string name, Transform parent)
        {
            var gameObject = new GameObject(name);
            SetParent(gameObject, parent);

            return gameObject;
        }

        public static GameObject Create(string name)
        {
            return new GameObject(name);
        }

        public static GameObject Create<T>(string name)
        {
            return Create(name, null, typeof(T));
        }

        public static GameObject Create<T>(string name, Transform parent)
        {
            return Create(name, parent, typeof(T));
        }

        private static void SetParent(GameObject gameObject, Transform parent)
        {
            var transform = gameObject.transform;
            transform.position = Vector3.zero;
            transform.parent = parent;
            transform.localScale = Vector3.one;
        }
    }
}

