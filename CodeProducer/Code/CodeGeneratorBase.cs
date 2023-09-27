using System;
using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.Helpers;
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
        protected List<string> _interfaces;

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
            _interfaces = new List<string>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a method to deconstruct type
        /// </summary>
        public void ImplementDeconstruct()
        {
            _methodsImplementationWriter.AddDeconstructMethod(_codeWriter, _memberWriter.List);
        }

        /// <summary>
        /// Adds a class to implement operators on
        /// </summary>
        /// <param name="operatorclass"></param>
        public void AddOperatorClass(string operatorclass)
        {
            _operatorImplementationWriter.ImplementationClasses.Add(operatorclass);
            _operatorImplementationWriter.ImplementsArithmetic = true;
        }

        /// <summary>
        /// Implements equality comparison for the instances of the class
        /// </summary>
        public void ImplementEqualityComparison()
        {
            _operatorImplementationWriter.ImplementsEquality = true;
            _interfaces.Add("IEquatable<" + _name + ">");

            _methodsImplementationWriter.AddEqualityComparisonMethods(_codeWriter, _name, _memberWriter.List);
        }

        /// <summary>
        /// Implements empty instance for the type
        /// </summary>
        public void ImplementEmptyInstance(bool implementequality)
        {
            _methodsImplementationWriter.AddIsEmptyMethod(_codeWriter, _name, implementequality);
            _memberWriter.AddEmptyMember(_name);
        }

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
        /// Produces the content of types
        /// </summary>
        protected void ProduceTypeContent()
        {
            WritePublicMembers(false);
            WritePrivateProtectedMembers(false);
            WritePrivateProtectedMembers(true);
            WriteConstructor();
            WriteStaticConstructor();
            WriteMethods(true, false);
            WriteMethods(false, false);
            WriteMethods(true, true);
            WriteMethods(false, true);
            WriteProperties(false);
            WriteProperties(true);
            WriteClasses(true);
            WriteClasses(false);
            WriteOperators();
        }

        /// <summary>
        /// Writes a constructor to textfile if necessary
        /// </summary>
        protected virtual void WriteConstructor()
        {
        }

        /// <summary>
        /// Writes classes to textfile
        /// </summary>
        /// <param name="Public"></param>
        protected virtual void WriteClasses(bool Public)
        {
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Writes a static constructor to textfile
        /// </summary>
        private void WriteStaticConstructor()
        {
            List<Member> initialization = new List<Member>();
            foreach (Member member in _memberWriter.List)
                if (member.Static)
                {
                    if (member.PrivateProtected && !member.ValueType)
                        initialization.Add(member);
                    else if (member.ValueType || member.ConstructorSet)
                        initialization.Add(member);
                }
            if (initialization.Count > 0)
            {
                _codeWriter.WriteLine("#region Static constructor", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceStaticConstructor(_name, initialization);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes public members to textfile
        /// </summary>
        private void WritePublicMembers(bool staticmembers)
        {
            if (_memberWriter.HasPublicMembers(staticmembers))
            {
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#region Public members", true);
                _codeWriter.WriteLine("");
                _memberWriter.WritePublicMembers(_codeWriter, staticmembers);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes private/protected members to textfile
        /// </summary>
        private void WritePrivateProtectedMembers(bool staticmembers)
        {
            if (_memberWriter.HasPrivateProtectedMembers(staticmembers))
            {
                if (staticmembers)
                    _codeWriter.WriteLine("#region Private static members", true);
                else
                    _codeWriter.WriteLine("#region Private/protected members", true);
                _codeWriter.WriteLine("");
                _memberWriter.WritePrivateProtectedMembers(_codeWriter, staticmembers);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes methods to textfile
        /// </summary>
        /// <param name="Public"></param>
        private void WriteMethods(bool Public, bool staticmethods)
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
        private void WriteProperties(bool staticproperties)
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
        /// Writes operators to textfile
        /// </summary>
        private void WriteOperators()
        {
            if (_operatorImplementationWriter.ImplementsAny)
            {
                _codeWriter.WriteLine("#region Operators", true);
                _codeWriter.WriteLine("");
                _operatorImplementationWriter.WriteOperators(_codeWriter, _name);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
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
