using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Codes.Util.FluentExt.CSharp
{
    public static class ListExtensions
    {
        #region null checker

        /// <summary>
        ///  check a list null or empty
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        #endregion

        #region random and shuffle

        /// <summary>
        ///  shuffle a list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) return;
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int index = Random.Range(0, n + 1);
                (list[index], list[n]) = (list[n], list[index]);
            }
        }
        
        /// <summary>
        /// Return a random item from the list.
        /// Sampling with replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Removes a random item from the list, returning that item.
        /// Sampling without replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        #endregion

        #region pop elements

        /// <summary>
        /// Pops element by <paramref name="index"/>.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="list">List with elements.</param>
        /// <param name="index">Index of element to pop.</param>
        /// <returns>The popped element.</returns>
        public static T Pop<T>(this IList<T> list, int index)
        {
            var element = list[index];
            list.RemoveAt(index);

            return element;
        }

        /// <summary>
        /// Pops random element from <paramref name="list"/>.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="list">List with elements.</param>
        /// <returns>The popped element.</returns>
        public static T PopRandom<T>(this IList<T> list) => Pop(list, Random.Range(0, list.Count));

        #endregion

        #region add element
        public static bool AddUnique<T>(this List<T> self, T item)
        {
            if (self.Contains(item))
            {
                return false;
            }
            self.Add(item);
            return true;
        }
        #endregion
    }
}