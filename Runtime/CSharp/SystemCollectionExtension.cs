using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.Util.FluentExt.CSharp
{
    
    public static class SystemCollectionExtension
    {
        /// <summary>
        ///  merge dictionary
        /// </summary>
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            params Dictionary<TKey, TValue>[] dictionaries)
        {
            return dictionaries.Aggregate(dictionary,
                (current, dict) => current.Union(dict).ToDictionary(kv => kv.Key, kv => kv.Value));
        }
        
        /// <summary>
        ///   adds a new dictionary to dic
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="addInDict"></param>
        /// <param name="isOverride"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public static void AddRange<K, V>(this Dictionary<K, V> dict, Dictionary<K, V> addInDict,
            bool isOverride = false)
        {
            var enumerator = addInDict.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (dict.ContainsKey(current.Key))
                {
                    if (isOverride)
                        dict[current.Key] = current.Value;
                    continue;
                }

                dict.Add(current.Key, current.Value);
            }

            enumerator.Dispose();
        }
        
        
        /// <summary>
        ///  ForEach Dictionary with action
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="action"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public static void ForEach<K, V>(this Dictionary<K, V> dict, Action<K, V> action)
        {
            var dictE = dict.GetEnumerator();

            while (dictE.MoveNext())
            {
                var current = dictE.Current;
                action(current.Key, current.Value);
            }

            dictE.Dispose();
        }
        
        
        /// <summary>
        ///  foreach List (can get index)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this List<T> list, Action<int, T> action)
        {
            for (var i = 0; i < list.Count; i++)
            {
                action(i, list[i]);
            }
        }
        
        /// <summary>
        /// foreach list reverse 
        /// </summary>
        /// <param name="selfList"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ForEachReverse<T>(this List<T> selfList, Action<T> action)
        {
            for (var i = selfList.Count - 1; i >= 0; --i)
                action(selfList[i]);

            return selfList;
        }
        
        
     
    }
}