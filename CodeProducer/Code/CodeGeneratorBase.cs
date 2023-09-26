using System;
using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code
{

    /// <summary>
    /// Base class for code generation
    /// </summary>
    public abstract class CodeGeneratorBase : IDisposable
    {

        #region Private/protected members

        protected CodeWriter _codeWriter;
        protected string _name;
        protected OperatorImplementationWriter _operatorImplementationWriter;
        protected MethodsImplementationWriter _methodsImplementationWriter;
        protected MemberWriter _memberWriter;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        /// <param name="name"></param>
        public CodeGeneratorBase(string name, DefinitionType definitionType)
        {
            _name = name;
            _operatorImplementationWriter = new OperatorImplementationWriter(_name);
            _methodsImplementationWriter = new MethodsImplementationWriter(definitionType);
            _memberWriter = new MemberWriter();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Frees resources
        /// </summary>
        public void Dispose()
        {
            _codeWriter.Dispose();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Writes methods to textfile
        /// </summary>
        /// <param name="Public"></param>
        protected void WriteMethods(bool Public, bool staticmethods)
        {
            if (_methodsImplementationWriter.HasMethods(Public, staticmethods))
            {
                if (staticmethods)
                    if (Public)
                        _codeWriter.WriteLine("#region Public static methods", true);
                    else
                        _codeWriter.WriteLine("#region Private static methods", true);
                else
                    if (Public)
                    _codeWriter.WriteLine("#region Public methods", true);
                else
                    _codeWriter.WriteLine("#region Private/protected methods", true);
                _codeWriter.WriteLine("");
                _methodsImplementationWriter.WriteMethods(_codeWriter, Public, staticmethods);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes properties to textfile
        /// </summary>
        protected void WriteProperties(bool staticproperties)
        {
            if (_memberWriter.HasProperties(staticproperties))
            {
                if (staticproperties)
                    _codeWriter.WriteLine("#region Static properties", true);
                else
                    _codeWriter.WriteLine("#region Properties", true);
                _codeWriter.WriteLine("");
                _memberWriter.WriteProperties(_codeWriter, staticproperties);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes Private/protected members to textfile
        /// </summary>
        /// <param name="staticmembers"></param>
        protected virtual void WritePrivateProtectedMembers(bool staticmembers)
        {
        }

        /// <summary>
        /// Writes Private/protected members to textfile
        /// </summary>
        /// <param name="staticmembers"></param>
        protected virtual void WritePublicMembers(bool staticmembers)
        {
        }

        #endregion

    }

    /// <summary>
    /// Struct for managing a member of the class
    /// </summary>
    public struct Member
    {
        
        #region Public members

        public string Name;
        public string Type;
        public List<string> Attributes;
        public bool PrivateProtected;
        public bool Static;
        public string Description;
        public bool GetProperty;
        public bool SetProperty;
        public bool ProtectedSetProperty;
        public bool ConstructorSet;
        public bool ValueType;
        public string GetText;
        public string SetText;
        public bool ValueIsNullable;
        public bool IsStructMember;
        public bool ReadOnly; // Only used by structs

        #endregion

        #region Public methods

        /// <summary>
        /// Returns string representation of the Member
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!IsStructMember)
            {
                StringBuilder sb = new StringBuilder(Type);
                if (ValueIsNullable)
                    sb.Append("?");
                sb.Append(" ");
                if (Static)
                    sb.Append("static ");
                sb.Append(Name);
                sb.Append(" ");
                if (PrivateProtected)
                    sb.Append("member parameter ");
                if (GetProperty)
                {
                    sb.Append("get ");
                    if (SetProperty)
                        sb.Append("set ");
                    else if (ProtectedSetProperty)
                        sb.Append("protected set ");
                }
                sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
            else
            {
                string isNullableText = ValueIsNullable ? "?" : "";
                if (ReadOnly)
                    return Name + " " + Type + isNullableText + " readonly";
                return Name + " " + Type + isNullableText;
            }
        }

        #endregion

    }

    /// <summary>
    /// Enum for different levels of visibility
    /// </summary>
    public enum Visibility
    {
        Public = 0,
        Protected = 1,
        Private = 2,
        Internal = 3,
        ProtectedInternal = 4
    }

    /// <summary>
    /// Defines what type of definition it is
    /// </summary>
    public enum DefinitionType
    {
        Class = 0,
        Struct = 1
    }

    /// <summary>
    /// Struct for managing different methods
    /// </summary>
    public struct Method
    {

        #region Public members

        public string Name;
        public string Type;
        public List<string> Attributes;
        public Visibility Visibility;
        public string Description;
        public bool Static;
        public bool Override;
        public List<Parameter> Parameters;
        public MethodText Text;

        #endregion

        #region Public structs/classes

        /// <summary>
        /// Struct for managing input parameters for the method
        /// </summary>
        public struct Parameter
        {

            #region Public members

            public string Name;
            public string Type;
            public string PropertyName;
            public bool HasProtectedMember;
            public bool IsOutParameter;
            public bool IsNullable;

            #endregion

        }

        #endregion

    }

    /// <summary>
    /// Delegate for implementing method text
    /// </summary>
    public delegate void MethodText();
}
