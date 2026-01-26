using UnityEditor;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    public static class Util {
        public static string GetPath(UnityEngine.Object shader) {
#if UNITY_6000_3_OR_NEWER // note: I am not sure in what version the interface changed (somewhere between 2022.3.62f2 and 6000.3)
            return AssetDatabase.GetAssetPath(shader.GetEntityId());
#else
            return  AssetDatabase.GetAssetPath(shader.GetInstanceID());
#endif
        }

    }
}
