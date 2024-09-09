using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class EnemyBehaviour : MonoBehaviour
{
    public float cubeSize;
    
    public float sphereRadius;
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyBehaviour)), CanEditMultipleObjects]
public class EnemyBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
    //variables and serializations
    serializedObject.Update();
    
    var cubeSize = serializedObject.FindProperty("cubeSize");
    var sphereRadius = serializedObject.FindProperty("sphereRadius");
    
    DrawPropertiesExcluding(serializedObject, "m_Script");
    //EditorGUILayout.PropertyField(health);
    //EditorGUILayout.PropertyField(attackPt);
    
    serializedObject.ApplyModifiedPropertiesWithoutUndo();
    

    //base
    //base.OnInspectorGUI();
    
    
        //Horizontal Buttons
        using (new EditorGUILayout.HorizontalScope())
        {
        if (GUILayout.Button("Select all cubes/spheres"))
    {
        var allEnemyBehaviour = GameObject.FindObjectsOfType
        <EnemyBehaviour>();
        var allEnemyGameObjects = allEnemyBehaviour
            .Select(enemy => enemy.gameObject)
            .ToArray();
        Selection.objects = allEnemyGameObjects;
}
        if (GUILayout.Button("Clear selection"))
        {
        Selection.objects = new Object[] {(target as EnemyBehaviour).gameObject};
}
    }
    //color
    var cachedColor = GUI.backgroundColor;
    GUI.backgroundColor = Color.green;
    //Vertical Buttons
    if (GUILayout.Button("Disable/Enable all cubes/spheres", GUILayout. Height(40)))
    {
        //code
        foreach (var enemy in GameObject.FindObjectsOfType<EnemyBehaviour>(true))
       {
       Undo.RecordObject(enemy.gameObject, "Disable/Enable cubes/spheres");
        enemy.gameObject.SetActive(!enemy.gameObject.activeSelf);
       }
    }
    GUI.backgroundColor = cachedColor;
    //Warnings Test
    
    if (cubeSize.floatValue > 2)
    {
    EditorGUILayout.HelpBox("The cubes' sizes cannot be bigger than 2!", MessageType.Warning);
    }
    if (sphereRadius.floatValue < 1)
    {
    EditorGUILayout.HelpBox("The spheres' radius cannot be smaller than 1!", MessageType.Warning);
    }

    }
    
}
#endif



