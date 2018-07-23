using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW_5_Klyushin
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows;
    using System.Xml;

    internal static class DataReaderAndWriter<T>
    {
        public static List<T> ReadDataFromXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            try
            {
                FileStream newfs = new FileStream(path, FileMode.Open, FileAccess.Read);
                var collection = (List<T>)serializer.Deserialize(newfs);
                newfs.Close();
                return collection;
            }
            catch
            {
                MessageBox.Show("Отсутствует файл с данными", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static void WriteDataToXml(List<T> dataList, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            try
            {
                StreamWriter fs = new StreamWriter(path, false);
                serializer.Serialize(fs, dataList);
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Файл занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

    }
}
