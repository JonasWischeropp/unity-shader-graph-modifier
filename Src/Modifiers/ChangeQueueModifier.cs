using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    [Serializable]
    public class ChangeQueueModifier : Modifier {
        [SerializeField]
        string _queue = "Geometry";

        public override string Apply(string code) {
            return Regex.Replace(code, @"""Queue""="".*""", $"\"Queue\"=\"{_queue}\"");
        }
    }
}
