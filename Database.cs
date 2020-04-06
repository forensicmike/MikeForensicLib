using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib.SQLite
{
    static public class Database
    {
        // Just an idea
        static public SQLiteConnection CachedConnection { get; set; }
    }

    static public class SQLiteExtensions
    {
        static public string ToSQLTable(this object target)
        {
            var t = target.GetType();

            var properties = t.GetProperties();
            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("Hashcode: " + target.GetHashCode());

            return "";
        }

        static public bool bEnableDebugging = false;
        static public readonly string DebuggingContext = "MikeForensicLib";
        static public void Debug(string message)
        {
            if (bEnableDebugging)
                Console.WriteLine($"[{DebuggingContext} @ {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}");
        }

        static public List<dynamic> Query(this SQLiteConnection con, string sql, dynamic parameters)
        {
            var ret = new List<dynamic>();

            var cmd = new SQLiteCommand(sql, con);

            if (parameters != null)
            {
                Type t = parameters.GetType();
                var properties = t.GetProperties();
                foreach (var prop in properties)
                    cmd.Parameters.AddWithValue(prop.Name, prop.GetValue(parameters));
            }

            Debug($"Query constructed as: {cmd.CommandText}");
            Debug($"With parameter count {cmd.Parameters.Count} and names=({string.Join(", ", cmd.Parameters.Cast<SQLiteParameter>().Select(x => x.ParameterName))}) and values=({string.Join(", ", cmd.Parameters.Cast<SQLiteParameter>().Select(x => x.Value))})");

            var reader = cmd.ExecuteReader();

            var columnNames = new Dictionary<int, string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                columnNames.Add(i, reader.GetName(i));
            }

            while (reader.Read())
            {
                var nResult = new ExpandoObject();
                var nResultDict = (IDictionary<string, object>)nResult;
                foreach (var item in columnNames)
                {
                    nResultDict.Add(item.Value, reader[item.Key]);
                }
                ret.Add(nResult);
            }
            reader.Close();
            return ret;
        }

        static public List<dynamic> Query(this SQLiteConnection con, string sql)
        {
            return con.Query(sql, null);
        }
    }


}
