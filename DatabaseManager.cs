
using CsSqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;


public class DatabaseManager: MonoBehaviour
{
    private SqliteConnection _connection = new SqliteConnection(Application.streamingAssetsPath + "/DetectiveGame.db");
    private void Start()
    {
        /*
        List<string> res = ExecuteQuery("SELECT * FROM Robberies WHERE RobberyID < 5");
        foreach (string s in res)
        {
            Debug.Log(s);
        }
        */
    }

    public List<string> ExecuteQuery(string query)
    {
        List<string> result = new List<string>();
        _connection.Open();
        try
        {
            SqliteReader reader = _connection.ExecuteReader(query);
            string header = "";
            for (int i = 0; i < reader.ColumnCount; i++)
            {
                header += reader.GetName(i);
                if (i != reader.ColumnCount - 1) header += ";";
            }
            result.Add(header);
            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.ColumnCount; i++)
                {
                    row += reader.GetString(i);
                    if (i != reader.ColumnCount - 1) row += ";";
                }
                result.Add(row);
            }
        }
        catch (SqliteException)
        {
            result.Add("ERROR: Синтаксическая ошибка при составлении запроса");
            return result;
        }
        catch (Exception ex)
        {
            result.Add($"ERROR: {ex.Message}");
            return result;
        }
        return result;
    }
}
