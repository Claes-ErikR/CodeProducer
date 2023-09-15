using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code.Code.Helpers
{

    /// <summary>
    /// Class to produce text for constructors
    /// </summary>
    public static class ConstructorHelper
    {

        /// <summary>
        /// Produces class constructor text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="className"></param>
        /// <param name="initialization"></param>
        /// <param name="parameters"></param>
        /// <param name="isFormComponent"></param>
        /// <param name="isFormComponentAndIncludeIvalidInterface"></param>
        public static void ProduceClassConstructor(this CodeWriter codeWriter, string className, List<Member> initialization, List<Method.Parameter> parameters, bool isFormComponent, bool isFormComponentAndIncludeIvalidInterface)
        {
            if (isFormComponent)
            {
                codeWriter.ProduceDescription("Initializes form", parameters);
                codeWriter.Write("public ", true);
                codeWriter.Write(className);
                codeWriter.WriteLine("()");
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("InitializeComponent();", true);
                if (isFormComponentAndIncludeIvalidInterface)
                    codeWriter.WriteLine("_includexmlsave = true;", true);
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
                codeWriter.WriteLine("");
            }
            if (parameters.Count > 0 || initialization.Count > 0)
            {
                StringBuilder sb = new StringBuilder("Initializes ");
                if (parameters.Count > 0)
                    sb.Append("private members with parameters and ");
                if (initialization.Count > 0)
                    sb.Append("private instances of objects");
                else
                    sb.Remove(sb.Length - 5, 5);
                codeWriter.ProduceDescription(sb.ToString(), parameters);
                codeWriter.Write("public ", true);
                codeWriter.Write(className);
                if (parameters.Count > 0)
                {
                    sb = new StringBuilder("(");
                    foreach (Method.Parameter parameter in parameters)
                    {
                        sb.Append(parameter.Type);
                        if (parameter.IsNullable)
                            sb.Append("?");
                        sb.Append(" ");
                        sb.Append(parameter.Name);
                        sb.Append(", ");
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(")");
                    codeWriter.WriteLine(sb.ToString());
                }
                else
                    codeWriter.WriteLine("()");
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                foreach (Method.Parameter parameter in parameters)
                {
                    if (parameter.HasProtectedMember)
                    {
                        codeWriter.Write("_", true);
                        codeWriter.Write(parameter.Name);
                    }
                    else
                        codeWriter.Write(parameter.PropertyName, true);
                    codeWriter.Write(" = ");
                    codeWriter.Write(parameter.Name);
                    codeWriter.WriteLine(";");
                }
                foreach (Member member in initialization)
                {
                    codeWriter.Write("_", true);
                    codeWriter.Write(member.Name.ToLower());
                    codeWriter.Write(" = new ");
                    codeWriter.Write(member.Type);
                    codeWriter.WriteLine("();");
                }
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
                codeWriter.WriteLine("");
            }
        }
    }
}
