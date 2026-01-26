using System;
using UnityEditor;
using UnityEngine;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    [Serializable]
    public class Modifier {
        [SerializeField, HideInInspector]
        private string _displayName = "<Name>";
        public virtual string Apply(string code) {
            throw new NotImplementedException("Override this function");
        }
        public static bool IsUnique() => true;
        public void SetDisplayName() {
            _displayName = ObjectNames.NicifyVariableName(GetType().Name);
        }
    }
}
