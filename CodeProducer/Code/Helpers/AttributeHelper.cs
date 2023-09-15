using System.Collections.Generic;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code.Code.Helpers
{

    /// <summary>
    /// Class to produce text for attributes
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// Produces attributes text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="attributes"></param>
        public static void ProduceAttributes(this CodeWriter codeWriter, List<string> attributes)
        {
            if (attributes != null && attributes.Count > 0)
            {
                codeWriter.Write("[", true);
                for (int i = 0; i < attributes.Count; i++)
                {
                    if (i == 0)
                        codeWriter.Write(attributes[i]);
                    else
                        codeWriter.Write(attributes[i], true);
                    if (i == attributes.Count - 1)
                        codeWriter.WriteLine("]");
                    else
                        codeWriter.WriteLine(",");
                }
            }
        }
    }
}