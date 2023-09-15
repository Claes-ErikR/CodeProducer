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
        public CodeGeneratorBase(string name)
        {
            _name = name;
            _operatorImplementationWriter = new OperatorImplementationWriter(_name);
            _methodsImplementationWriter = new MethodsImplementationWriter();
            _memberWriter = new MemberWriter();
        }

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        public CodeGeneratorBase()
            : this("")
        {
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

        #endregion

        #region Public methods

        /// <summary>
        /// Returns string representation of the Member
        /// </summary>
        /// <returns></returns>
        public override string ToString()
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
