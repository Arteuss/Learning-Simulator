using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Configs
{
    [CustomEditor(typeof(SimulatorScenarioConfig))]
    public class SimulatorScenarioConfigInspector : Editor
    {
         /// <summary>
        ///  Список элементов в сценарии
        /// </summary>
        private ReorderableList _elementsList;

        /// <summary>
        /// Высота линии
        /// </summary>
        private float _lineHeight;

        private void OnEnable()
        {
            if(target == null)
                return;
            
            _lineHeight = EditorGUIUtility.singleLineHeight;
            
            _elementsList = new ReorderableList(serializedObject, serializedObject.FindProperty("_elementConfigs"),true,false,true,true);

            _elementsList.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = _elementsList.serializedProperty.GetArrayElementAtIndex(index);
                var offset = 30;
                if (element != null)
                {
                    EditorGUI.LabelField(new Rect(rect.x, rect.y, offset, rect.height), $"#{index}");
                    EditorGUI.PropertyField(new Rect(rect.x + offset, rect.y, rect.width - offset, rect.height), element, GUIContent.none);
                }
            };

            _elementsList.elementHeightCallback = index => _lineHeight;
            
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.PropertyField(new Rect(15, 10, 400, _lineHeight), serializedObject.FindProperty("_devicePrefab"), GUIContent.none);
            EditorGUILayout.Space(30);
            GUILayout.Label("Elements:");
            _elementsList.DoLayoutList();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}