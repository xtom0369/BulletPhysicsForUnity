using BulletUnity;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BMultiSphereShape))]
public class BMultiSphereShapeEditor : Editor
{

    BMultiSphereShape script;
    SerializedProperty spheres;
    SerializedProperty localScale;

    void OnEnable()
    {
        script = (BMultiSphereShape)target;
        GetSerializedProperties();
    }

    void GetSerializedProperties()
    {
        spheres = serializedObject.FindProperty("spheres");
    }

    public override void OnInspectorGUI()
    {
        if (script.transform.localScale != Vector3.one)
        {
            EditorGUILayout.HelpBox("This shape doesn't support scale of the object.\nThe scale must be one", MessageType.Warning);
        }
        script.drawGizmo = EditorGUILayout.Toggle("Draw Shape", script.drawGizmo);
        EditorGUIUtility.wideMode = false;
        EditorGUILayout.PropertyField(spheres, true);
        EditorGUIUtility.wideMode = true;
        script.LocalScaling = EditorGUILayout.Vector3Field("Local Scaling", script.LocalScaling);
        script.Margin = EditorGUILayout.FloatField("Margin", script.Margin);
        serializedObject.ApplyModifiedProperties();
    }
}
