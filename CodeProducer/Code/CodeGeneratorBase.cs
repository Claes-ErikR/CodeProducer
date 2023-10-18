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
        /// Implements a list of implemented interfaces to the class
        /// </summary>
        /// <param name="interfaces"></param>
        /// <param name="setAllMembersInConstructor"></param>
        public void AddImplementedInterfaces(List<string> interfaces, bool setAllMembersInConstructor = false)
        {
            if (interfaces.Contains("IFormattable"))
                ImplementIFormattable();
            if (interfaces.Contains("IDisposable"))
                ImplementIDisposable();
            if (interfaces.Contains("ICloneable"))
                ImplementICloneable();
            if (interfaces.Contains("IFunction<double>"))
                ImplementIFunctionOfDouble();
            if (interfaces.Contains("IDerivable<double>"))
                ImplementIDerivableOfDouble();
            if (interfaces.Contains("IIntegrable<double>"))
                ImplementIIntegrableOfDouble();
            if (interfaces.Contains("IXmlSave"))
                ImplementIXmlSave(setAllMembersInConstructor);
            if (interfaces.Contains("IValid"))
                ImplementIValid();
            if (interfaces.Contains("IEuclidean3D"))
                ImplementIEuclidean3D();
            if (interfaces.Contains("ICylindricalCoordinates"))
                ImplementICylindricalCoordinates();
            if (interfaces.Contains("ISphericaloordinates"))
                ImplementISphericaloordinates();
            if (interfaces.Contains("IEuclidean2D"))
                ImplementIEuclidean2D();
            if (interfaces.Contains("ICircularCoordinates"))
                ImplementICircularCoordinates();
        }

        /// <summary>
        /// Ensures there is an implementation of ToString
        /// </summary>
        public void EnsureToStringImplemented()
        {
            _methodsImplementationWriter.EnsureToStringImplemented(_codeWriter, _memberWriter.List);
        }

        /// <summary>
        /// Implements sort comparison for the instances of the class
        /// </summary>
        public void ImplementSortComparison()
        {
            _operatorImplementationWriter.ImplementsComparison = true;
            _interfaces.Add("IComparable");
            _interfaces.Add("IComparable<" + _name + ">");

            _methodsImplementationWriter.AddSortComparisonMethods(_codeWriter, _name);
        }

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
            int constructorParametersCount = 0;
            foreach (Member member in _memberWriter.List)
            {
                if (member.Static)
                {
                    if (member.PrivateProtected && !member.ValueType)
                        initialization.Add(member);
                    else if (member.ValueType || member.ConstructorSet)
                        initialization.Add(member);
                }
                else
                {
                    if((member.ConstructorSet || member.ReadOnly) && member.IsStructMember)
                        constructorParametersCount++;
                    if(member.ConstructorSet && !member.IsStructMember)
                        constructorParametersCount++;
                }
            }
            if (initialization.Count > 0)
            {
                _codeWriter.ProduceRegionStart("Static constructor");
                _codeWriter.ProduceStaticConstructor(_name, initialization, constructorParametersCount);
                _codeWriter.ProduceRegionEnd();
            }
        }

        /// <summary>
        /// Writes public members to textfile
        /// </summary>
        private void WritePublicMembers(bool staticmembers)
        {
            if (_memberWriter.HasPublicMembers(staticmembers))
            {
                _codeWriter.ProduceRegionStart("Public members");
                _memberWriter.WritePublicMembers(_codeWriter, staticmembers);
                _codeWriter.ProduceRegionEnd();
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
                    _codeWriter.ProduceRegionStart("Private static members");
                else
                    _codeWriter.ProduceRegionStart("Private/protected members");
                _memberWriter.WritePrivateProtectedMembers(_codeWriter, staticmembers);
                _codeWriter.ProduceRegionEnd();
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
                        _codeWriter.ProduceRegionStart("Public static methods");
                    else
                        _codeWriter.ProduceRegionStart("Private static methods");
                else
                    if (Public)
                    _codeWriter.ProduceRegionStart("Public methods");
                else
                    _codeWriter.ProduceRegionStart("Private/protected methods");
                _methodsImplementationWriter.WriteMethods(_codeWriter, Public, staticmethods);
                _codeWriter.ProduceRegionEnd();
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
                    _codeWriter.ProduceRegionStart("Static properties");
                else
                    _codeWriter.ProduceRegionStart("Properties");
                _memberWriter.WriteProperties(_codeWriter, staticproperties);
                _codeWriter.ProduceRegionEnd();
            }
        }

        /// <summary>
        /// Writes operators to textfile
        /// </summary>
        private void WriteOperators()
        {
            if (_operatorImplementationWriter.ImplementsAny)
            {
                _codeWriter.ProduceRegionStart("Operators");
                _operatorImplementationWriter.WriteOperators(_codeWriter, _name);
                _codeWriter.ProduceRegionEnd();
            }
        }

        #region Interfaces

        /// <summary>
        /// Implements ICircularCoordinates interface
        /// </summary>
        private void ImplementICircularCoordinates()
        {
            _interfaces.Add("ICircularCoordinates");

            _memberWriter.AddICircularCoordinatesMembers();
        }

        /// <summary>
        /// Implements IEuclidean2D interface
        /// </summary>
        private void ImplementIEuclidean2D()
        {
            _interfaces.Add("IEuclidean2D");

            _memberWriter.AddIEuclidean2DMembers();
        }

        /// <summary>
        /// Implements ISphericaloordinates interface
        /// </summary>
        private void ImplementISphericaloordinates()
        {
            _interfaces.Add("ISphericaloordinates");

            _memberWriter.AddISphericaloordinatesMembers();
        }

        /// <summary>
        /// Implements ICylindricalCoordinates interface
        /// </summary>
        private void ImplementICylindricalCoordinates()
        {
            _interfaces.Add("ICylindricalCoordinates");

            _memberWriter.AddICylindricalCoordinatesMembers();
        }

        /// <summary>
        /// Implements IEuclidean3D interface
        /// </summary>
        private void ImplementIEuclidean3D()
        {
            _interfaces.Add("IEuclidean3D");

            _memberWriter.AddIEuclidean3DMembers();
        }

        /// <summary>
        /// Implements IValid interface
        /// </summary>
        private void ImplementIValid()
        {
            _interfaces.Add("IValid");

            _memberWriter.AddIValidMember();
        }

        /// <summary>
        /// Implements IXmlSave interface
        /// </summary>
        private void ImplementIXmlSave(bool setMemberInConstructor)
        {
            _interfaces.Add("IXmlSave");

            _methodsImplementationWriter.AddIXmlSaveMethods(_codeWriter);

            _memberWriter.AddIXmlSaveMember(setMemberInConstructor);
        }

        /// <summary>
        /// Implements IIntegrableOfDouble interface
        /// </summary>
        private void ImplementIIntegrableOfDouble()
        {
            _interfaces.Add("IIntegrable<double>");

            _methodsImplementationWriter.AddIIntegrableMethod("double");
        }

        /// <summary>
        /// Implements IDerivableOfDouble interface
        /// </summary>
        private void ImplementIDerivableOfDouble()
        {
            _interfaces.Add("IDerivable<double>");

            _methodsImplementationWriter.AddIDerivableMethod("double");
        }

        /// <summary>
        /// Implements IFunctionOfDouble interface
        /// </summary>
        private void ImplementIFunctionOfDouble()
        {
            _interfaces.Add("IFunction<double>");

            _methodsImplementationWriter.AddIFunctionMethod("double");
        }

        /// <summary>
        /// Implements ICloneable interface
        /// </summary>
        private void ImplementICloneable()
        {
            _interfaces.Add("ICloneable");

            _methodsImplementationWriter.AddICloneableMethod(_codeWriter, _name, _memberWriter.List);
        }

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        private void ImplementIDisposable()
        {
            _interfaces.Add("IDisposable");

            _methodsImplementationWriter.AddIDisposableMethod();
        }

        /// <summary>
        /// Implements IFormattable interface
        /// </summary>
        private void ImplementIFormattable()
        {
            _interfaces.Add("IFormattable");

            _methodsImplementationWriter.AddIFormattableMethods(_codeWriter, _memberWriter.List);
        }

        #endregion

        #endregion

        #region Static constructor

        /// <summary>
        /// Initializes static variables
        /// </summary>
        static CodeGeneratorBase()
        {
            ImplementedInterfaces = new List<string>
            {
                "IFormattable",
                "IDisposable",
                "ICloneable",
                "IFunction<double>",
                "IDerivable<double>",
                "IIntegrable<double>",
                "IXmlSave",
                "IValid",
                "IEuclidean3D",
                "ICylindricalCoordinates",
                "ISphericaloordinates",
                "IEuclidean2D",
                "ICircularCoordinates"
            };
        }

        #endregion

        #region Static properties

        /// <summary>
        /// Returns a list with implemented interfaces
        /// </summary>
        public static List<string> ImplementedInterfaces { get; }

        #endregion

    }

    /// <summary>
    /// Struct for managing a member of the class
    /// </summary>
    public struct Member
    {
        
        #region Public members

        public string Name; // Name of the member
        public string Type; // Type name of member
        public List<string> Attributes; // Attributes associated with the member
        public bool Public; // Decides if the member is public
        public bool PrivateProtected; // Decides if the member is private and if so it decides what text to use in getter/setter when there is no such text
        public bool Static; // Flag for a static member
        public string Description; // Text used in comment
        public bool GetProperty; // Decides wether there should be a property for the member
        public bool SetProperty; // Decides if there should be a set property when no SetText provided
        public bool ProtectedSetProperty; // Decides if there should be a protected set property without code
        public bool ConstructorSet; // Decides if the member should be set in the constructor
        public bool ValueType; // Flag deciding if it is a value type
        public string GetText; // If there is text here there will be a getter with the text
        public string SetText; // If there is text here there will be a setter with the text
        public bool ValueIsNullable; // Indicates if member is nullable
        public bool IsStructMember; // Indicates if member is part of struct
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
