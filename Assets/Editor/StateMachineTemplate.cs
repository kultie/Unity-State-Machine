using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class StateMachineTemplateEditor : EditorWindow
{
    string nameSpace;
    string key;
    string contextName;

    [MenuItem("State Machine/Template")]
    public static void ShowWindow()
    {
        GetWindow<StateMachineTemplateEditor>(false, "Template", true);
    }

    private void OnGUI()
    {
        nameSpace = EditorGUILayout.TextField("Namespace", nameSpace);
        key = EditorGUILayout.TextField("States key", key);
        contextName = EditorGUILayout.TextField("State Context Name", contextName);
        if (GUILayout.Button("Create"))
        {
            Debug.Log("About to create: " + nameSpace + ": " + key + ": " + contextName);
            CreateFile(nameSpace, key, contextName);
        }
        if (GUILayout.Button("Clear"))
        {
            nameSpace = "";
            key = "";
            contextName = "";
        }
    }

    void CreateFile(string nameSpace, string key, string contextName)
    {
        string folderDirectory = Application.dataPath + "/StateMachine";
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }
        string nameSpaceDirectory = folderDirectory + "/" + nameSpace;
        if (!Directory.Exists(nameSpaceDirectory))
        {
            Directory.CreateDirectory(nameSpaceDirectory);
        }
        File.WriteAllText(nameSpaceDirectory + "\\" + nameSpace + "StateMachine.cs", GetFileContent(nameSpace, key, contextName));
    }

    string GetFileContent(string name, string key, string context)
    {
        string text = "using UnityEngine;\n" +
                    "using Kultie.StateMachine;\n\n" +
                    "//Using theses commented snipset to quicky paste in you controller script and start doing stuff\n" +
                    "//StateMachine<" + key + ", " + context + "> stateMachine;\n" +
                    "//System.Collections.Generic.Dictionary<" + key + ", IState<" + context + ">> CreateStates()\n" +
                    "//{\n" +
                    "//    System.Collections.Generic.Dictionary<" + key + ", IState<" + context + ">> dic = new System.Collections.Generic.Dictionary<" + key + ", IState<" + context + ">>();\n" +
                    "//    return dic;\n" +
                    "//}\n\n" +

                    "namespace StateMachine." + name + "\n{\n" +
                    "    public enum " + key + "\n    {\n\n    };\n" +
                    "    public class " + context + " : StateContextBase \n    {\n" +
                    "\n    }\n\n" +
                    "    //Every state will be created here\n" +
                    "    public class TemplateState : StateBase<" + context + ">\n" +
                    "    {\n" +
                    "        protected override void OnEnter()\n" +
                    "        {\n\n" +
                    "        }\n\n" +
                    "        protected override void OnExit()\n" +
                    "        {\n\n" +
                    "        }\n\n" +
                    "        protected override void OnUpdate(float dt)\n" +
                    "        {\n\n" +
                    "        }\n" +
                    "    }\n" +
                    "}";
        return text;
    }
}
