using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEditor;

public class BuildBundle : EditorWindow 
{
	[MenuItem("Tools/BuildBundle")]
	static void AddWindow(){
		GetWindow<BuildBundle> ("BuildBundle");
	}

	string build_name = "yjzx";
	string file_path = "/Users/leo/Documents/project/M5-C/ios-release-82976/LocalFile/AppConfig.json";

	void OnGUI(){
		EditorGUILayout.BeginVertical ();

		EditorGUILayout.BeginHorizontal ();
		file_path = EditorGUILayout.TextField ("Appconfig.json路径", file_path);
		if (GUILayout.Button ("选择文件", GUILayout.MaxWidth (100)))
		{
			file_path = EditorUtility.OpenFilePanel("选择Appconfig.json文件", file_path, "json");
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("生成加密cdn")) {
			GenerateAppConfig (build_name);
		}
		build_name = EditorGUILayout.TextField ("内部包名", build_name);
		if (GUILayout.Button ("Show in Finder")) {
			System.Diagnostics.Process.Start (Application.dataPath + "/iOS");
		}
		EditorGUILayout.EndHorizontal ();
		
		if (GUILayout.Button ("Build")) {
			BuildPipeline.BuildAssetBundles(Application.dataPath + "/iOS", BuildAssetBundleOptions.None, BuildTarget.iOS);
		}

		EditorGUILayout.EndVertical ();
	}

	void GenerateAppConfig(string build_name){
		string config = GetContent (file_path);
		if (!string.IsNullOrEmpty (config)) {
			byte[] bytes = Encoding.Default.GetBytes (config);
			byte[] new_bytes = XORDecode (bytes, build_name);
			string new_config = Encoding.Default.GetString (new_bytes);
			File.WriteAllText (Path.Combine (Application.dataPath + "/iOS", string.Format ("{0}.{1}", build_name, "m5")), new_config);
		} else {
			if (EditorUtility.DisplayDialog ("警告", string.Format ("找不到配置文件:{0}", file_path), "确认", "取消") == false) {
				throw new Exception ();
			}
		}
	}

	string GetContent(string path){
		if (!File.Exists (path))
			return null;
		using (var reader = new StreamReader (path, Encoding.UTF8)) {
			return reader.ReadToEnd ();
		}
	}

    byte[] XORDecode(byte[] input, string key)
    {
        var keyByte = Encoding.ASCII.GetBytes(key);
        var keyByteLen = keyByte.Length;
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = (byte)(input[i] ^ keyByte[i % keyByteLen]);
        }
        return input;
    }
}
