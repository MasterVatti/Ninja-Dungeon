using System.Collections.Generic;
using UnityEngine;

namespace ObjectPools
{
    /// <summary>
    /// Пул для объектов определенного типа: Image, Text, Enemy и т.д.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoBehaviourPool<T> where T : Component
    {
        private readonly List<T> _notUsedItems = new List<T>();
        private readonly List<T> _usedItems = new List<T>();

        private readonly T _prefab;
        private readonly Transform _parent;

        public MonoBehaviourPool(T prefab, Transform parent, int defaultCount = 4)
        {
            _parent = parent;
            _prefab = prefab;

            for(var i = 0; i < defaultCount; i++)
            {
                AddNewItemInPool();
            }
            
            SortBySiblingIndexUnused();
        }

        public T Take()
        {
            if (_notUsedItems.Count == 0)
            {
                AddNewItemInPool();
            }

            var lastIndex = _notUsedItems.Count - 1;
            var itemFromPool = _notUsedItems[lastIndex];
            _notUsedItems.RemoveAt(lastIndex);
            _usedItems.Add(itemFromPool);
            itemFromPool.gameObject.SetActive(true);

            return itemFromPool;
        }
        
        private void SortBySiblingIndexUnused()
        {
            _notUsedItems.Sort((a, b) => b.transform.GetSiblingIndex().CompareTo(a.transform.GetSiblingIndex()));
        }

        public void ReleaseAll()
        {
            for(var i = 0; i < _usedItems.Count; i++)
            {
                _usedItems[i].gameObject.SetActive(false);
            }

            _notUsedItems.AddRange(_usedItems);
            _usedItems.Clear();
        }

        private void Release(T item)
        {
            item.gameObject.SetActive(false);

            _usedItems.Remove(item);
            _notUsedItems.Add(item);
        }

        public void Release(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Release(item);
            }
        }

        private void AddNewItemInPool()
        {
            var newItem = Object.Instantiate(_prefab, _parent, false);
            newItem.gameObject.SetActive(false);
            _notUsedItems.Add(newItem);
        }
    }
}
