using System;

namespace DbHelper
{
    public partial class CDbHelper
    {
       /// <summary>
       /// Returns a proper NULL for a database table (instead of empty string)
       /// </summary>
       /// <param name="strData"></param>
       /// <returns></returns>
       public static object DbEnsure(string strData)
       {
          if (string.IsNullOrEmpty(strData))
          {
             return DBNull.Value;
          }

          return strData;
       }
    }
}
