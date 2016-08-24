using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceStack.Text;
using System.IO;

namespace ZuoRiWeiLai.Framework
{
    /// <summary>
    /// Newtonsoft.Json 比较热门的序列化组件
    /// ServiceStack.Text 号称最快的序列化组件 对复杂对象的序列化不够友好
    /// </summary>
    public class JSON
    {
        #region 1.0 Newtonsoft.Json
        /// <summary>
        /// 将对象序列化为JSON格式字符串
        /// Newtonsoft.Json
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON字符串</returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将JSON字符串反序列为指定的实体对象
        /// Newtonsoft.Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将JSON字符串反序列化为指定对象的集合
        /// Newtonsoft.Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> DeserializeToList<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// 反序列JSON字符串到给定的匿名对象
        /// Newtonsoft.Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T DeserialzeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
        }
        #endregion

        #region 2.0 ServiceStack.Text
        /// <summary>
        /// 将对象序列化为JSON格式字符串
        /// ServiceStack.Text
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeV2(object obj)
        {
            return ServiceStack.Text.JsonSerializer.SerializeToString(obj);
        }

        /// <summary>
        /// 把对象序列化到流序列中
        /// ServiceStack.Text
        /// </summary>
        /// <param name="json"></param>
        /// <param name="stream"></param>
        public static void SerializeToStream(object json, Stream stream)
        {
            SerializeToStream<object>(json, stream);
        }

        /// <summary>
        /// 把泛型对象序列化到流序列中
        /// ServiceStack.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="stream"></param>
        public static void SerializeToStream<T>(T json, Stream stream)
        {
            ServiceStack.Text.JsonSerializer.SerializeToStream<T>(json, stream);
        }
        /// <summary>
        /// 将JSON字符串反序列为指定的实体对象
        /// ServiceStack.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeV2<T>(string json) where T : class
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(json);
        }

        /// <summary>
        /// 将JSON字符串反序列化为指定对象的集合
        /// ServiceStack.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> DeserializeToListV2<T>(string json) where T : class
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<List<T>>(json);
        }

        /// <summary>
        /// 从流中反序列化为对象
        /// ServiceStack.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeserializeFromStream<T>(System.IO.Stream stream)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStream<T>(stream);
        }

        /// <summary>
        /// 从流中反序列化为对象的集合
        /// ServiceStack.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static List<T> DeserializeToListFromStream<T>(System.IO.Stream stream)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStream<List<T>>(stream);
        }
        #endregion
        
    }
}
