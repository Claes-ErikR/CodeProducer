﻿using System.Collections.Generic;
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
            StringBuilder sb = new StringBuilder("Initializes ");
            if (isFormComponent)
                sb.Append("form ");

            if (parameters.Count > 0 || initialization.Count > 0)
            {
                if (parameters.Count > 0)
                    sb.Append("private members with parameters and ");
                if (initialization.Count > 0)
                    sb.Append("private instances of objects");
                else
                    sb.Remove(sb.Length - 5, 5);
            }
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

            if (isFormComponent)
            {
                codeWriter.WriteLine("InitializeComponent();", true);
                if (isFormComponentAndIncludeIvalidInterface)
                    codeWriter.WriteLine("_includexmlsave = true;", true);
            }

            codeWriter.SubtractIndentation();
            codeWriter.WriteLine("}", true);
        }

        /// <summary>
        /// Produces static class constructor text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="className"></param>
        /// <param name="initialization"></param>
        public static void ProduceStaticClassConstructor(this CodeWriter codeWriter, string className, List<Member> initialization)
        {
            ProduceStaticConstructor(codeWriter, className, "Static constructor initializing private instances of objects", initialization, false);
        }

        /// <summary>
        /// Produces static struct constructor text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="className"></param>
        public static void ProduceStaticStructConstructor(this CodeWriter codeWriter, string className)
        {
            ProduceStaticConstructor(codeWriter, className, "Sets empty instance", null, true);
        }

        /// <summary>
        /// Produces static constructor text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="name"></param>
        /// <param name="initialization"></param>
        private static void ProduceStaticConstructor(CodeWriter codeWriter, string name, string description, List<Member> initialization, bool includeEmptyInitialization)
        {
            codeWriter.ProduceDescription(description);
            codeWriter.Write("static ", true);
            codeWriter.Write(name);
            codeWriter.WriteLine("()");
            codeWriter.WriteLine("{", true);
            codeWriter.AddIndentation();
            if (initialization != null)
            {
                foreach (Member member in initialization)
                {
                    if (member.ValueType)
                    {
                        if (member.PrivateProtected)
                        {
                            codeWriter.Write("_", true);
                            codeWriter.Write(member.Name.ToLower());
                        }
                        else
                            codeWriter.Write(member.Name, true);
                        codeWriter.Write(" = ");
                        codeWriter.Write(GetDefault(member.Type));
                        codeWriter.WriteLine(";");
                    }
                    else
                    {
                        codeWriter.Write("_", true);
                        codeWriter.Write(member.Name.ToLower());
                        codeWriter.Write(" = new ");
                        codeWriter.Write(member.Type);
                        codeWriter.WriteLine("();");
                    }
                }
            }
            if(includeEmptyInitialization)
            {
                codeWriter.WriteLine("Empty = new " + name + "();", true);
            }
            codeWriter.SubtractIndentation();
            codeWriter.WriteLine("}", true);
        }

        /// <summary>
        /// Produces struct constructor text
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="structName"></param>
        /// <param name="members"></param>
        public static void ProduceStructConstructor(this CodeWriter codeWriter, string structName, List<StructMember> members)
        {
            codeWriter.ProduceDescription("Initializes members", members);
            codeWriter.Write("public ", true);
            codeWriter.Write(structName);
            codeWriter.Write("(");
            StringBuilder sb = new StringBuilder();
            foreach (StructMember member in members)
            {
                sb.Append(member.Type);
                if (member.IsNullable)
                    sb.Append("?");
                sb.Append(" ");
                sb.Append(member.Name.ToLower());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            codeWriter.Write(sb.ToString());
            codeWriter.WriteLine(")");
            codeWriter.WriteLine("{", true);
            codeWriter.AddIndentation();
            foreach (StructMember member in members)
            {
                codeWriter.Write(member.Name, true);
                codeWriter.Write(" = ");
                codeWriter.Write(member.Name.ToLower());
                codeWriter.WriteLine(";");
            }
            codeWriter.SubtractIndentation();
            codeWriter.WriteLine("}", true);
        }

        private static string GetDefault(string type)
        {
            if (type == "string")
                return "string.Empty";
            else if (type == "double")
                return "double.NaN";
            else if (type == "int")
                return "0";
            else if (type == "bool")
                return "false";
            else
                return "";
        }
    }
}