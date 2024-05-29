using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GamePlayLogic
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private T m_prefab;
        private Transform m_container;
        private List<T> m_pool;
        
        public bool AutoExpand { get; set; }

        public ObjectPool(T prefab, int count, Transform container)
        {
            m_prefab = prefab;
            m_container = container;
            
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            m_pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(m_prefab, m_container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            m_pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var poolElement in m_pool)
            {
                if (!poolElement.gameObject.activeInHierarchy)
                {
                    element = poolElement;
                    poolElement.gameObject.SetActive(true);
                    return true;
                }
            }
            
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out T element))
                return element;

            if (AutoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free elements in pool of type{typeof(T)}");
        }
    }
}