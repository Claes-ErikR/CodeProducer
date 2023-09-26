using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.Helpers;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code
{

    /// <summary>
    /// Class for producing basic code for a class
    /// </summary>
    public sealed class ClassProducer : CodeGeneratorBase
    {

        #region Private members

        private ClassType _type;
        private List<string> _attributes;
        private bool _formcomponent;
        private Visibility _visibility;
        private string _parentclass;
        private string _description;
        private List<string> _interfaces;
        private List<ClassProducer> _classes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a ClassProducer without a StreamWriter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="classtype"></param>
        /// <param name="formcomponent"></param>
        /// <param name="visibility"></param>
        /// <param name="parentclass"></param>
        /// <param name="description"></param>
        public ClassProducer(string name,List<string> attributes, ClassType classtype, bool formcomponent, Visibility visibility, string parentclass, string description)
            : base(name, DefinitionType.Class)
        {
            _attributes = attributes;
            _type = classtype;
            _formcomponent = formcomponent;
            if (_formcomponent)
                _type = ClassType.Normal;
            _visibility = visibility;
            _parentclass = parentclass;
            _interfaces=new List<string>();
            _classes = new List<ClassProducer>();
            _description = description;
        }

        /// <summary>
        /// Initializes a ClassProducer creating a new StreamWriter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="classtype"></param>
        /// <param name="formcomponent"></param>
        /// <param name="visibility"></param>
        /// <param name="parentclass"></param>
        /// <param name="description"></param>
        /// <param name="filename"></param>
        public ClassProducer(string name, List<string> attributes, ClassType classtype, bool formcomponent, Visibility visibility, string parentclass, string description, string filename)
            : this(name,attributes, classtype, formcomponent, visibility, parentclass, description)
        {
            _codeWriter = new CodeWriter(filename, 4);
        }

        #endregion

        #region Public methods

        #region General methods

        /// <summary>
        /// Returns string representation of the class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(_visibility.ToString());
            sb.Append(" ");
            if(IsStatic)
                sb.Append("static ");
            if (IsSealed)
                sb.Append("sealed ");
            sb.Append(_name);
            if(_parentclass!="")
            {
                sb.Append(" : ");
                sb.Append(_parentclass);
            }

            return sb.ToString();
        }

        #endregion

        #region Add methods

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
        /// Adds an interface to the class
        /// </summary>
        /// <param name="inputinterface"></param>
        public void AddInterface(string inputinterface)
        {
            _interfaces.Add(inputinterface);
        }

        /// <summary>
        /// Adds a list of interfaces to the class
        /// </summary>
        /// <param name="interfaces"></param>
        public void AddInterfaces(List<string> interfaces)
        {
            foreach (string Interface in interfaces)
                AddInterface(Interface);
        }

        /// <summary>
        /// Implements a list of implemented interfaces to the class
        /// </summary>
        /// <param name="interfaces"></param>
        public void AddImplementedInterfaces(List<string> interfaces)
        {
            if(interfaces.Contains("IFormattable"))
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
                ImplementIXmlSave();
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
        /// Adds a member to the class
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(Member member)
        {
            if (IsStatic)
                member.Static = true;
            _memberWriter.Add(member);
        }

        /// <summary>
        /// Adds a class as a member to the class
        /// </summary>
        /// <param name="classproducer"></param>
        public void AddClass(ClassProducer classproducer)
        {
            classproducer._codeWriter = _codeWriter;
            _classes.Add(classproducer);
        }

        #endregion

        #region Implement methods

        #region Coordinate interfaces

        /// <summary>
        /// Implements ICircularCoordinates interface
        /// </summary>
        public void ImplementICircularCoordinates()
        {
            if (!IsStatic)
            {
                _interfaces.Add("ICircularCoordinates");

                _memberWriter.AddICircularCoordinatesMembers();
            }
        }

        /// <summary>
        /// Implements IEuclidean2D interface
        /// </summary>
        public void ImplementIEuclidean2D()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IEuclidean2D");

                _memberWriter.AddIEuclidean2DMembers();
            }
        }

        /// <summary>
        /// Implements ISphericaloordinates interface
        /// </summary>
        public void ImplementISphericaloordinates()
        {
            if (!IsStatic)
            {
                _interfaces.Add("ISphericaloordinates");

                _memberWriter.AddISphericaloordinatesMembers();
            }
        }

        /// <summary>
        /// Implements ICylindricalCoordinates interface
        /// </summary>
        public void ImplementICylindricalCoordinates()
        {
            if (!IsStatic)
            {
                _interfaces.Add("ICylindricalCoordinates");

                _memberWriter.AddICylindricalCoordinatesMembers();
            }
        }

        /// <summary>
        /// Implements IEuclidean3D interface
        /// </summary>
        public void ImplementIEuclidean3D()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IEuclidean3D");

                _memberWriter.AddIEuclidean3DMembers();
            }
        }

        #endregion

        #region Form/control interfaces

        /// <summary>
        /// Implements IValid interface
        /// </summary>
        public void ImplementIValid()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IValid");

                _memberWriter.AddIValidMember();
            }
        }

        /// <summary>
        /// Implements IXmlSave interface
        /// </summary>
        public void ImplementIXmlSave()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IXmlSave");

                _methodsImplementationWriter.AddIXmlSaveMethods(_codeWriter);

                _memberWriter.AddIXmlSaveMember();
            }
        }

        #endregion

        #region Math interfaces

        /// <summary>
        /// Implements IIntegrableOfDouble interface
        /// </summary>
        public void ImplementIIntegrableOfDouble()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IIntegrable<double>");

                _methodsImplementationWriter.AddIIntegrableMethod("double");
            }
        }

        /// <summary>
        /// Implements IDerivableOfDouble interface
        /// </summary>
        public void ImplementIDerivableOfDouble()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IDerivable<double>");

                _methodsImplementationWriter.AddIDerivableMethod("double");
            }
        }

        /// <summary>
        /// Implements IFunctionOfDouble interface
        /// </summary>
        public void ImplementIFunctionOfDouble()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IFunction<double>");

                _methodsImplementationWriter.AddIFunctionMethod("double");
            }
        }

        #endregion

        #region .net base classes interfaces

        /// <summary>
        /// Implements ICloneable interface
        /// </summary>
        public void ImplementICloneable()
        {
            if (!IsStatic)
            {
                _interfaces.Add("ICloneable");

                _methodsImplementationWriter.AddICloneableMethod(_codeWriter, _name, _memberWriter.List);
            }
        }

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        public void ImplementIDisposable()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IDisposable");

                _methodsImplementationWriter.AddIDisposableMethod();
            }
        }

        /// <summary>
        /// Implements IFormattable interface
        /// </summary>
        public void ImplementIFormattable()
        {
            if (!IsStatic)
            {
                _interfaces.Add("IFormattable");

                _methodsImplementationWriter.AddIFormattableMethods(_codeWriter, _memberWriter.List);
            }
        }

        #endregion

        #region Wrappers

        /// <summary>
        /// Implements the class as a wrapper for a typed list with some basic functions
        /// </summary>
        /// <param name="type"></param>
        public void ImplementListWrapper(string type)
        {
            if (!IsStatic)
            {
                _interfaces.Add("IEnumerable");

                _memberWriter.AddListWrapperMembers(type);

                _methodsImplementationWriter.AddListWrapperMethods(_codeWriter, type);
            }
        }

        #endregion

        #region .net base class functionality

        /// <summary>
        /// Implements sort comparison for the instances of the class
        /// </summary>
        public void ImplementSortComparison()
        {
            if (!IsStatic)
            {
                _operatorImplementationWriter.ImplementsComparison = true;
                _interfaces.Add("IComparable");
                _interfaces.Add("IComparable<" + _name + ">");

                _methodsImplementationWriter.AddSortComparisonMethods(_codeWriter, _name);
            }
        }

        /// <summary>
        /// Implements equality comparison for the instances of the class
        /// </summary>
        public void ImplementEqualityComparison()
        {
            if (!IsStatic)
            {
                _operatorImplementationWriter.ImplementsEquality = true;
                _interfaces.Add("IEquatable<" + _name + ">");

                _methodsImplementationWriter.AddEqualityComparisonMethods(_codeWriter, _name, _memberWriter.List);
            }
        }

        #endregion

        #region ToString implementation

        /// <summary>
        /// Ensures there is an implementation of ToString
        /// </summary>
        public void EnsureToStringImplemented()
        {
            if (!IsStatic)
                _methodsImplementationWriter.EnsureToStringImplemented(_codeWriter, _memberWriter.List);
        }

        #endregion

        #region Deconstruct

        public void ImplementDeconstruct()
        {
            if (!IsStatic)
                _methodsImplementationWriter.AddDeconstructMethod(_codeWriter, _memberWriter.List);
        }

        #endregion

        #region Utte code functionality

        /// <summary>
        /// Implements Xml Read and Save interface
        /// </summary>
        public void ImplementXmlReadSave()
        {
            if (!IsStatic)
                _methodsImplementationWriter.AddXmlReadSaveMethods(_codeWriter, _memberWriter.List);
        }

        #endregion

        #endregion

        #region Produce methods, ie text write methods

        /// <summary>
        /// Writes with zero indentation
        /// </summary>
        public void Produce()
        {
            Produce(0);
        }

        /// <summary>
        /// Writes with indentation
        /// </summary>
        /// <param name="indentation"></param>
        private void Produce(int indentation)
        {
            _codeWriter.Indentation = indentation;
            _codeWriter.ProduceDescription(_description);
            _codeWriter.ProduceAttributes(_attributes);
            _codeWriter.ProduceClassDeclaration(_name, _parentclass, _interfaces, _visibility, IsStatic, IsSealed, _formcomponent);
            _codeWriter.WriteLine("{",true);
            _codeWriter.AddIndentation();
            _codeWriter.WriteLine("");
            ProduceTypeContent();
            _codeWriter.SubtractIndentation();
            _codeWriter.WriteLine("}",true);
        }

        #endregion

        #endregion

        #region Private methods

        #region Write to file methods

        /// <summary>
        /// Writes a constructor to textfile
        /// </summary>
        protected override void WriteConstructor()
        {
            List<Method.Parameter> parameters = new List<Method.Parameter>();
            List<Member> initialization=new List<Member>();
            foreach (Member member in _memberWriter.List)
                if (!member.Static)
                {
                    if (member.PrivateProtected && member.ConstructorSet)
                    {
                        Method.Parameter parameter = new Method.Parameter();
                        parameter.Type = member.Type;
                        parameter.Name = member.Name.ToLower();
                        parameter.PropertyName = member.Name;
                        parameter.HasProtectedMember = true;
                        parameter.IsNullable = member.ValueIsNullable;
                        parameters.Add(parameter);
                    }
                    else if (member.PrivateProtected && !member.ValueType)
                        initialization.Add(member);
                    else if (member.ConstructorSet && !member.PrivateProtected && (member.SetProperty || member.ProtectedSetProperty || member.GetProperty))
                    {
                        Method.Parameter parameter = new Method.Parameter();
                        parameter.Type = member.Type;
                        parameter.Name = member.Name.ToLower();
                        parameter.PropertyName = member.Name;
                        parameter.HasProtectedMember = false;
                        parameter.IsNullable = member.ValueIsNullable;
                        parameters.Add(parameter);
                    }
                }
            if (parameters.Count>0 || initialization.Count>0 || _formcomponent)
            {
                _codeWriter.WriteLine("#region Constructors", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceClassConstructor(_name, initialization, parameters, _formcomponent, _formcomponent && _interfaces.Contains("IValid"));
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes classes to textfile
        /// </summary>
        /// <param name="Public"></param>
        protected override void WriteClasses(bool Public)
        {
            List<ClassProducer> classes = new List<ClassProducer>();
            foreach (ClassProducer cp in _classes)
                if ((Public && cp._visibility == Visibility.Public) || (!Public && cp._visibility != Visibility.Public))
                    classes.Add(cp);
            if (classes.Count > 0)
            {
                if (Public)
                    _codeWriter.WriteLine("#region Public classes/structs", true);
                else
                    _codeWriter.WriteLine("#region Private/protected classes/structs", true);
                _codeWriter.WriteLine("");
                foreach (ClassProducer cp in classes)
                {
                    cp.Produce(_codeWriter.Indentation);
                    _codeWriter.WriteLine("");
                }
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        #endregion

        #endregion

        #region Private static members

        private static List<string> _implementedinterfaces;

        #endregion

        #region Properties

        /// <summary>
        /// Returns if class is static
        /// </summary>
        public bool IsStatic
        {
            get
            {
                return _type == ClassType.Static;
            }
        }

        /// <summary>
        /// Returns if class is sealed
        /// </summary>
        public bool IsSealed
        {
            get
            {
                return _type == ClassType.Sealed;
            }
        }

        #endregion

        #region Public enums

        public enum ClassType
        {
            Normal = 0,
            Sealed = 1,
            Static = 2
        }

        #endregion

        #region Static constructor

        /// <summary>
        /// Initializes static variables
        /// </summary>
        static ClassProducer()
        {
            _implementedinterfaces = new List<string>();
            _implementedinterfaces.Add("IFormattable");
            _implementedinterfaces.Add("IDisposable");
            _implementedinterfaces.Add("ICloneable");
            _implementedinterfaces.Add("IFunction<double>");
            _implementedinterfaces.Add("IDerivable<double>");
            _implementedinterfaces.Add("IIntegrable<double>");
            _implementedinterfaces.Add("IXmlSave");
            _implementedinterfaces.Add("IValid");
            _implementedinterfaces.Add("IEuclidean3D");
            _implementedinterfaces.Add("ICylindricalCoordinates");
            _implementedinterfaces.Add("ISphericaloordinates");
            _implementedinterfaces.Add("IEuclidean2D");
            _implementedinterfaces.Add("ICircularCoordinates");
        }

        #endregion

        #region Static properties

        /// <summary>
        /// Returns a list with implemented interfaces
        /// </summary>
        public static List<string> ImplementedInterfaces
        {
            get
            {
                return _implementedinterfaces;
            }
        }

        #endregion

    }
}
