using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace JonasWischeropp.Unity.EditorTools.ShaderGraph {
    [Serializable]
    public class AddStencilModifier : Modifier {
        [SerializeField, Multiline(7)]
        string _stencilBlock = "Ref 1\nComp Equal\nPass Keep\n";

        static Regex regex = new Regex(@"Pass\s*{\s*Name """);

        public override string Apply(string code) {
            Match match = regex.Match(code);

            string i3 = new string('\t', 3);
            string i4 = new string('\t', 4);

            // Insert stencil block with correct indentation
            string stencilBlock = $"Stencil\n"
                + $"{i3}{{\n"
                + i4 + _stencilBlock.Trim().Replace("\n", "\n" + i4) + "\n"
                + $"{i3}}}\n{i3}";
            return code.Insert(match.Index, stencilBlock);
        }
    }
}
