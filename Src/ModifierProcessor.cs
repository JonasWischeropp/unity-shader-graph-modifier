using UnityEditor;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    public class ModifierProcessor : AssetPostprocessor {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
            foreach (string importedAsset in importedAssets) {
                if (importedAsset.EndsWith(".shadergraph")
                    && ModifierStack.TryLoadStack(importedAsset, out ModifierStack modifierStack)) {
                    modifierStack.UpdateTarget();
                }
            }
        }
    }
}
