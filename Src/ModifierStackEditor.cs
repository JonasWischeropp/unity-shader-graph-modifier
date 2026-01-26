using UnityEditor;
using UnityEngine;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    [CustomEditor(typeof(ModifierStack))]
    public class ModifierStackEditor : Editor {
        public override void OnInspectorGUI() {
            using (new EditorGUI.DisabledGroupScope(true)) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("sourceShader"));
            }
            OnDrawModifiers(serializedObject, (ModifierStack)target);
        }
        
        public static void OnDrawModifiers(SerializedObject modifierStackSO, ModifierStack modifierStack) {
            using (new EditorGUI.DisabledGroupScope(true)) {
                EditorGUILayout.PropertyField(modifierStackSO.FindProperty("outputShader"));
            }
            modifierStackSO.Update();
            EditorGUILayout.PropertyField(modifierStackSO.FindProperty("shaderName"));
            GUILayout.Label("Modifiers:");
            SerializedProperty modifiersSP
                = modifierStackSO.FindProperty("_modifiers");
            for (int i = 0; i < modifiersSP.arraySize; i++) {
                SerializedProperty sp = modifiersSP.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(sp, true);
            }
            if (GUILayout.Button("Add Modifier")) {
                Rect rect = EditorGUILayout.GetControlRect();
                ShowHeaderContextMenu(modifierStack);
            }
            if (GUILayout.Button("Update Shader")) {
                modifierStack.UpdateTarget();
            }
            modifierStackSO.ApplyModifiedProperties();
        }

        static void ShowHeaderContextMenu(ModifierStack modifierStack) {
            // FilterWindow like in VolumeProfileEditor would look nicer
            var menu = new GenericMenu();        
            foreach (var type in modifierStack.GetAddableOptions()) {
                menu.AddItem(new GUIContent(ObjectNames.NicifyVariableName(type.Name).Replace(" Modifier", "")),
                    false, () => modifierStack.AddModifier(type));
            }
            menu.ShowAsContext();
        }

        public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets,int width,int height) {
            string path = AssetDatabase.GUIDToAssetPath(new GUID("3f4514221147a72db9ee4377b8d59bed"));
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);

            Texture2D copy = new Texture2D (width, height);
            EditorUtility.CopySerialized(texture, copy);
            return copy;
        }
    }
}
