using System.Collections.Generic;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code.Code.Helpers
{

    /// <summary>
    /// Class to produce descriptiontexts
    /// </summary>
    public static class DescriptionHelper
    {
        /// <summary>
        /// Produces description text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="description"></param>
        public static void ProduceDescription(this CodeWriter codeWriter, string description)
        {
            codeWriter.WriteLine("/// <summary>", true);
            codeWriter.Write("/// ", true);
            codeWriter.WriteLine(description);
            codeWriter.WriteLine("/// </summary>", true);
        }

        /// <summary>
        /// Produces description text with parameters
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        public static void ProduceDescription(this CodeWriter codeWriter, string description, List<Method.Parameter> parameters)
        {
            codeWriter.ProduceDescription(description);
            if (parameters != null)
                foreach (Method.Parameter parameter in parameters)
                {
                    codeWriter.Write("/// <param name=\"", true);
                    codeWriter.Write(parameter.Name);
                    codeWriter.WriteLine("\"></param>");
                }
        }

        /// <summary>
        /// Produces description text with parameters
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        /// <param name="returnparameter"></param>
        public static void ProduceDescription(this CodeWriter codeWriter, string description, List<StructMember> parameters, bool returnparameter = false)
        {
            codeWriter.ProduceDescription(description);
            if (parameters != null)
                foreach (StructMember parameter in parameters)
                {
                    codeWriter.Write("/// <param name=\"", true);
                    codeWriter.Write(parameter.Name.ToLower());
                    codeWriter.WriteLine("\"></param>");
                }
            if (returnparameter)
                codeWriter.WriteLine("/// <returns></returns>", true);
        }

        /// <summary>
        /// Produces description text with return parameter
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="description"></param>
        /// <param name="returnparameter"></param>
        public static void ProduceDescription(this CodeWriter codeWriter, string description, bool returnparameter)
        {
            codeWriter.ProduceDescription(description);
            if (returnparameter)
                codeWriter.WriteLine("/// <returns></returns>", true);
        }

        /// <summary>
        /// Produces description text with parameters and return parameter
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        /// <param name="returnparameter"></param>
        public static void ProduceDescription(this CodeWriter codeWriter, string description, List<Method.Parameter> parameters, bool returnparameter)
        {
            codeWriter.ProduceDescription(description, parameters);
            if (returnparameter)
                codeWriter.WriteLine("/// <returns></returns>", true);
        }

        public static void ProduceDescription(this CodeWriter codeWriter, string description, bool returnparameter, params string[] parameters)
        {
            codeWriter.ProduceDescription(description);
            if (parameters != null)
                foreach (string parameter in parameters)
                {
                    codeWriter.Write("/// <param name=\"", true);
                    codeWriter.Write(parameter);
                    codeWriter.WriteLine("\"></param>");
                }
            if (returnparameter)
                codeWriter.WriteLine("/// <returns></returns>", true);
        }
    }
}
