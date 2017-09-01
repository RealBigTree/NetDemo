using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unity.Base {
    public static class ExDic {

        #region 增

        /// <summary>
        /// 向字典中批量添加键值对
        /// </summary>
        /// <param name="replaceExisted">如果已存在，是否替换</param>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted) {
            foreach (var item in values) {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }

        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static Dictionary<TKey, TValue> AddTry<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value) {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value) {
            dict[key] = value;
            return dict;
        }

        #endregion

        #region 删
        
        #endregion

        #region 改
        
        #endregion

        #region 查

        /// <summary>
        /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue)) {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }
        
        #endregion

        #region 转
        
        #endregion

        #region 其它

        /// <summary>
        /// dic转String
        /// </summary>
        /// <param name="skipKeyLst">跳过某些Key</param>
        /// <returns>Key+fillstr+Value+splitStr...</returns>
        public static string ToStringFormat<T, Y>(this Dictionary<T, Y> dic, string fillStr, string splitStr, string skipKeyLst = "") {
            if (dic == null || dic.Count < 1) {
                return string.Empty;
            }
            var skipLst = skipKeyLst.Split(",");
            StringBuilder sb = new StringBuilder();
            foreach (var item in dic) {
                if (skipLst.Contains(item.Key.ToString())) {
                    continue;
                }
                sb.Append(item.Key.ToString());
                sb.Append(fillStr);
                sb.Append(item.Value.ToString());
                sb.Append(splitStr);
            }
            return sb.ToString().Trim(splitStr.ToCharArray());
        }
        
        #endregion

    }
}
