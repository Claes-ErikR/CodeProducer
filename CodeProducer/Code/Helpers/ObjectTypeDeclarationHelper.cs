using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.SupportClasses;
using static Utte.Text.Latex.LatexPresentation.LatexSection;

namespace Utte.Code.Code.Helpers
{
    /// <summary>
    /// Class to produce text for object type declarations
    /// </summary>
    public static class ObjectTypeDeclarationHelper
    {

        /// <summary>
        /// Produces class declaration text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="className"></param>
        /// <param name="parentClassName"></param>
        /// <param name="implementedInterfaces"></param>
        /// <param name="visibility"></param>
        /// <param name="isStatic"></param>
        /// <param name="isSealed"></param>
        /// <param name="isPartial"></param>
        public static void ProduceClassDeclaration(this CodeWriter codeWriter, string className, string parentClassName, List<string> implementedInterfaces, Visibility visibility, bool isStatic, bool isSealed, bool isPartial)
        {
            if (visibility == Visibility.ProtectedInternal)
                codeWriter.Write("protected internal", true);
            else
                codeWriter.Write(visibility.ToString().ToLower(), true);
            if (isStatic)
                codeWriter.Write(" static");
            if (isSealed)
                codeWriter.Write(" sealed");
            if (isPartial)
                codeWriter.Write(" partial");
            codeWriter.Write(" class ");
            if (parentClassName == "" && implementedInterfaces.Count == 0)
                codeWriter.WriteLine(className);
            else
            {
                codeWriter.Write(className);
                codeWriter.Write(" : ");
                StringBuilder sb = new StringBuilder();
                if (parentClassName != "")
                {
                    sb.Append(parentClassName);
                    sb.Append(", ");
                }
                foreach (string interfacename in implementedInterfaces)
                {
                    sb.Append(interfacename);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                codeWriter.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Produces struct declaration text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="structName"></param>
        /// <param name="visibility"></param>
        /// <param name="iequatableImplementation"></param>
        public static void ProduceStructDeclaration(this CodeWriter codeWriter, string structName, string visibility, bool iequatableImplementation)
        {
            if (visibility == "ProtectedInternal")
                codeWriter.Write("protected internal", true);
            else
                codeWriter.Write(visibility.ToString().ToLower(), true);
            codeWriter.Write(" struct ");
            if (iequatableImplementation)
            {
                codeWriter.Write(structName);
                codeWriter.Write(" : IEquatable<");
                codeWriter.Write(structName);
                codeWriter.WriteLine(">");
            }
            else
                codeWriter.WriteLine(structName);
        }
    }
}
