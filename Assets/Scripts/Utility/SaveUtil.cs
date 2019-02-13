using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Utility
{
    public static class SaveUtil
    {
        public static void SaveData<T>(string fileName, T data)
        {
            var filePath = Path.Combine(Application.persistentDataPath, $"{fileName}.sav");

            var dataBytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));            
            File.WriteAllText(filePath, Convert.ToBase64String(dataBytes));
        }

        public static T LoadData<T>(string fileName) where T : new()
        {
            var filePath = Path.Combine(Application.persistentDataPath, $"{fileName}.sav");
            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"{fileName}.sav was not found! Returning default constructed data");
                return new T();
            }

            try
            {
                var serializedData = Convert.FromBase64String(File.ReadAllText(filePath));
                return JsonUtility.FromJson<T>(Encoding.UTF8.GetString(serializedData));
            }
            catch
            {
                // TODO: Log issues as warnings?
                return new T();
            }
        }
    }
}
