﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KelimeOyunu.Database
{
    public class AppDataManager
    {

        public static void SaveBool(string name, bool boolean)
        {
            ApplicationData.Current.LocalSettings.Values[name] = boolean;
        }

        public static bool GetBool(string name)
        {
            return (bool)(ApplicationData.Current.LocalSettings.Values[name]);
        }

        public static bool GetBool(string name, bool defaultBool)
        {
            if ((ApplicationData.Current.LocalSettings.Values[name]) != null)
            {
                return GetBool(name);
            }
            else
            {
                SaveBool(name, defaultBool);
                return defaultBool;
            }
        }

        public static void SaveInt(string name, int value)
        {
            ApplicationData.Current.LocalSettings.Values[name] = value;
        }

        public static int GetInt(string name)
        {
            return (int)(ApplicationData.Current.LocalSettings.Values[name]);
        }

        public static int GetInt(string name, int defaultValue)
        {
            if ((ApplicationData.Current.LocalSettings.Values[name]) != null)
            {
                return (int)(ApplicationData.Current.LocalSettings.Values[name]);
            }
            else
            {
                SaveInt(name, defaultValue);
                return defaultValue;
            }
        }

        public static void SaveString(string name, string value)
        {
            ApplicationData.Current.LocalSettings.Values[name] = value;
        }

        public static string GetString(string name)
        {
            return (string)(ApplicationData.Current.LocalSettings.Values[name]);
        }

        public static string GetString(string name, string defaultValue)
        {
            if ((ApplicationData.Current.LocalSettings.Values[name]) != null)
            {
                return (string)(ApplicationData.Current.LocalSettings.Values[name]);
            }
            else
            {
                SaveString(name, defaultValue);
                return defaultValue;
            }
        }

        public static void SaveDouble(string name, double value)
        {
            ApplicationData.Current.LocalSettings.Values[name] = value;
        }

        public static double GetDouble(string name)
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[name]);
        }

        public static double GetDouble(string name, double defaultValue)
        {
            if ((ApplicationData.Current.LocalSettings.Values[name]) != null)
            {
                return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[name]);
            }
            else
            {
                SaveDouble(name, defaultValue);
                return defaultValue;
            }
        }


        public async static void ClearDatas()
        {
            await ApplicationData.Current.ClearAsync();
        }
    }
}
