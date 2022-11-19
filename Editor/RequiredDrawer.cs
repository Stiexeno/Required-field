using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Object), true)]
public class RequiredDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        EditorGUI.PropertyField(position, property, new GUIContent(label.text), true);

        var value = property.objectReferenceValue;
        var containsFieldAttribute = fieldInfo.GetCustomAttribute<Nullable>() != null;
        var containsClassAttribute = property.serializedObject.targetObject.GetType().GetCustomAttribute<Nullable>() != null;
        
        if (value == false && containsFieldAttribute == false && containsClassAttribute == false)
        {
            position = new Rect((float) (position.x + (double) EditorGUIUtility.labelWidth + 2.0), position.y,
                (float) (position.width - (double) EditorGUIUtility.labelWidth - 2.0), position.height);
            DrawBorderRect(property, label, position, Color.red, 2f);

            position.x -= 22f;
            EditorGUI.LabelField(position, new GUIContent(EditorGUIUtility.IconContent("d_console.erroricon")));
        }
        
        EditorGUI.indentLevel = indent;
    }

    private void DrawBorderRect(SerializedProperty property, GUIContent label, Rect area, Color color,
        float borderWidth)
    {
        //------------------------------------------------
        float x1 = area.x;
        float y1 = area.y;
        float x2 = area.width;
        float y2 = borderWidth;

        Rect lineRect = new Rect(x1, y1, x2, y2);

        EditorGUI.DrawRect(lineRect, color);

        //------------------------------------------------
        x1 = area.x + area.width;
        y1 = area.y;
        x2 = borderWidth;
        y2 = area.height;

        lineRect = new Rect(x1, y1, x2, y2);

        EditorGUI.DrawRect(lineRect, color);

        //------------------------------------------------
        x1 = area.x;
        y1 = area.y;
        x2 = borderWidth;
        y2 = area.height;

        lineRect = new Rect(x1, y1, x2, y2);

        EditorGUI.DrawRect(lineRect, color);

        //------------------------------------------------
        x1 = area.x;
        y1 = area.y + GetPropertyHeight(property, label);
        x2 = area.width + 2f;
        y2 = borderWidth;

        lineRect = new Rect(x1, y1, x2, y2);

        EditorGUI.DrawRect(lineRect, color);
    }
}