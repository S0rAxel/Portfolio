using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ToggleSwitch))]
public class ToggleSwitchEditor : UnityEditor.UI.SelectableEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ToggleSwitch targetToolbarButton = (ToggleSwitch)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("isOn"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("toggleIndicator"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("background"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onColor"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("offColor"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onImage"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("offImage"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("audioSource"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("tweenTime"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("onValueChanged"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("onValueChangedNegative"));

        serializedObject.ApplyModifiedProperties();
    }
}
