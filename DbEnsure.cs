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
         => string.IsNullOrEmpty(strData) ? DBNull.Value : strData;
    }
}
