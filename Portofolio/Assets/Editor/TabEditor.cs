using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Tab))]
public class TabEditor : UnityEditor.UI.ToggleEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Tab targetToolbarButton = (Tab)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("index"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tab"));

        serializedObject.ApplyModifiedProperties();
    }
}
