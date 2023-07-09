using System;
using System.Collections.Generic;
using System.Linq;

namespace DbHelper
{
   public partial class CDbHelper
   {
      public static Func<object, string, List<string>> ObjToList = (obj, strDelim) =>
         obj.ToString().Split(strDelim.ToCharArray()).ToList();

      public static Dictionary<string, string> GetObjToMap<T>(T obj, List<string> lst_strParams, string strDelim)
      {
         return ObjToList(obj, strDelim)
            .Select((s, i) => new { KEY = lst_strParams[i], VALUE = s })
            .ToDictionary(k => k.KEY, v => v.VALUE);
      }
   }
}