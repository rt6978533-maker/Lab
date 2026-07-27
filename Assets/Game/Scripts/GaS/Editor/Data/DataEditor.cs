using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace GaS.Editor.Data
{
    

    public class PlayerPrefsObject : EditorWindow
    {
        public string Name;
        public string ValueString;
        public int ValueInt;
        public float ValueFloat;

        private int _index;
        private PlayerPrefsWorld _world;

        public enum Type
        {
            Int, Float, String
        };

        public void Init(int index, string name, PlayerPrefsWorld world)
        {
            _index = index;
            _world = world;
            Name = name;
            ValueInt = PlayerPrefs.GetInt(name, -9999999);
            ValueFloat = PlayerPrefs.GetFloat(name, -9999999f);
            ValueString = PlayerPrefs.GetString(name, "%%%NULL_VALUE_IS_STRING%%%");
        }

        private void Delete() {
            PlayerPrefs.DeleteKey(Name);
            RemoveInList();
        }
        private void RemoveInList() { _world.Remove(_index); _world.Repaint(); Close(); }

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(Name, GUILayout.MinWidth(20));
            if (ValueInt != -9999999) GUILayout.Label(ValueInt.ToString());
            if (ValueFloat != -9999999f) GUILayout.Label(ValueFloat.ToString());
            if (ValueString != "%%%NULL_VALUE_IS_STRING%%%") GUILayout.Label(ValueString);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Remove in list")) RemoveInList();
            if (GUILayout.Button("Delete")) Delete();
        }
    }

    public class PlayerPrefsCreate : EditorWindow
    {
        private string namePrefs = "";
        private int typeSelect = 0;

        //Data
        private string valueDataString;
        private float valueDataFloat;
        private int valueDataInt;

        public void OnGUI()
        {
            string[] options = { "String", "Int", "Float" };

            GUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            namePrefs = GUILayout.TextField(namePrefs);
            GUILayout.EndHorizontal();

            if (PlayerPrefs.HasKey(namePrefs)) return;

            typeSelect = GUILayout.SelectionGrid(typeSelect, options, options.Length);

            if (typeSelect == 0) valueDataString = GUILayout.TextField(valueDataString);
            else if (typeSelect == 1) valueDataInt = EditorGUILayout.IntField(valueDataInt);
            else if (typeSelect == 2) valueDataFloat = EditorGUILayout.FloatField(valueDataFloat);

            if (GUILayout.Button("Create")) {
                if (typeSelect == 0) PlayerPrefs.SetString(namePrefs, valueDataString); 
                else if (typeSelect == 1) PlayerPrefs.SetInt(namePrefs, valueDataInt); 
                else if (typeSelect == 2) PlayerPrefs.SetFloat(namePrefs, valueDataFloat); 
            }
        }
    }

    public class PlayerPrefsWorld : EditorWindow
    {
        public List<string> Buffer = new();
        public List<int> EmptySlot = new();
        private string nameString;

        [MenuItem("GaS/Data/DeletePlayerPrefs")]
        public static void DeletePlayerPrefs() => PlayerPrefs.DeleteAll();

        [MenuItem("GaS/Data/PlayerPrefsWorld")]
        public static void WindowShow()
        {
            GetWindow<PlayerPrefsWorld>().Show();
        }

        [MenuItem("GaS/Data/PlayerPrefsCreate")]
        public static void WindowShowCreate()
        {
            GetWindow<PlayerPrefsCreate>().Show();
        }

        private void Add(string nameKey)
        {
            if (EmptySlot.Count == 0) Buffer.Add(nameString);
            else { Buffer[EmptySlot[0]] = nameKey; EmptySlot.RemoveAt(0); }
        }

        public void Remove(int index)
        {
            Buffer[index] = null;
            EmptySlot.Add(index);
        }

        public void OnGUI()
        {
            nameString = GUILayout.TextField(nameString);
            if (GUILayout.Button("Add")) Add(nameString);

            EditorGUILayout.Separator();

            for (int index = 0; index < Buffer.Count; index++)
            {
                string value = Buffer[index];

                if (string.IsNullOrEmpty(value)) continue;
                if (!PlayerPrefs.HasKey(value))
                {
                    if (GUILayout.Button(value + " Delete?"))
                    {
                        Remove(index);
                    }
                }
                else
                {
                    if (GUILayout.Button(value))
                    {
                        PlayerPrefsObject w = GetWindow<PlayerPrefsObject>();
                        w.Init(index, value, this);
                    }
                }
            }
        }
    }
}