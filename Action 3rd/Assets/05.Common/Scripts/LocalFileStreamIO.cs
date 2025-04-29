using System.IO;
using UnityEngine;

namespace Action3rd
{
    public static class LocalFileStreamIO
    {
        public static void WriteStringToFile(string filePath, string data)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // 使用StreamWriter将字符串写入文件
                    using StreamWriter writer = new StreamWriter(filePath);
                    writer.Write(data);
                }
                else
                {
                    Debug.Log("文件不存在,初次创建文件: " + filePath);
                    File.WriteAllText(filePath, data);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("写入文件时出错: " + e.Message);
            }
        }

        public static string ReadStringFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) { return string.Empty; }

                // 使用StreamReader读取文件内容
                using StreamReader reader = new StreamReader(filePath);
                return reader.ReadToEnd();
            }
            catch (System.Exception e)
            {
                Debug.LogError("读取文件时出错: " + e.Message);
                return null;
            }
        }
    }
}