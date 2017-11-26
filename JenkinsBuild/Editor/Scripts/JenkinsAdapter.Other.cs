using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
    {
        static T _stringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        static void _executeComplete(string errorMessage,string outPath)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine("Build Complete Path:" + outPath);
                EditorApplication.Exit(0);
            }
            else
            {
                Console.WriteLine("Build Error:" + errorMessage);
                EditorApplication.Exit(1);
            }
        }

        static void _setIcons(BuildTargetGroup target,string[] paths)
        {
            PlayerSettings.SetIconsForTargetGroup(target,_loadTexture2Ds(paths));
        }


        static Texture2D[] _loadTexture2Ds(string[] paths)
        {
            List<Texture2D> texture2Ds = new List<Texture2D>();

            foreach (var path in paths)
            {
                texture2Ds.Add(AssetDatabase.LoadAssetAtPath<Texture2D>(path));
            }

            return texture2Ds.ToArray();
        }
    }
}