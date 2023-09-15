using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.Helpers;
using Utte.Code.Code.SupportClasses;

namespace Utte.Code
{

    /// <summary>
    /// Class for producing basic code for a class
    /// </summary>
    public class ClassProducer : CodeGeneratorBase
    {

        #region Private/protected members

        protected ClassType _type;
        protected List<string> _attributes;
        protected bool _formcomponent;
        protected Visibility _visibility;
        protected string _parentclass;
        protected string _description;
        protected List<string> _interfaces;
        protected List<Member> _members;
        protected List<Method> _methods;
        protected List<ClassProducer> _classes;
        protected bool _hastostring;

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
        public ClassProducer(string name,List<string> attributes, ClassType classtype,bool formcomponent, Visibility visibility,string parentclass,string description) : base(name)
        {
            _attributes = attributes;
            _type = classtype;
            _formcomponent = formcomponent;
            if (_formcomponent)
                _type = ClassType.Normal;
            _visibility = visibility;
            _parentclass = parentclass;
            _interfaces=new List<string>();
            _members=new List<Member>();
            _methods=new List<Method>();
            _classes = new List<ClassProducer>();
            _hastostring=false;
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
            : this(name,attributes, classtype, formcomponent, visibility, parentclass,description)
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
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="privateprotected"></param>
        /// <param name="inputstatic"></param>
        /// <param name="description"></param>
        /// <param name="getproperty"></param>
        /// <param name="setproperty"></param>
        /// <param name="constructorset"></param>
        /// <param name="valuetype"></param>
        public void AddMember(string name, string type, bool privateprotected, bool inputstatic, string description,bool getproperty, bool setproperty, bool constructorset, bool valuetype)
        {
            Member newmember = new Member();
            newmember.Name = name;
            newmember.Type = type;
            newmember.PrivateProtected=privateprotected;
            if (IsStatic)
                newmember.Static = true;
            else
                newmember.Static=inputstatic;
            newmember.Description = description;
            newmember.GetProperty=getproperty;
            newmember.SetProperty=setproperty;
            newmember.ConstructorSet=constructorset;
            newmember.ValueType = valuetype;
            _members.Add(newmember);
        }

        /// <summary>
        /// Adds a member to the class
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(Member member)
        {
            if (IsStatic)
                member.Static = true;
            _members.Add(member);
        }

        /// <summary>
        /// Adds a member without exposing a property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="inputstatic"></param>
        /// <param name="constructorset"></param>
        /// <param name="valuetype"></param>
        public void AddHidddenMember(string name, string type,bool inputstatic, bool constructorset, bool valuetype)
        {
            Member newmember = new Member();
            newmember.Name = name;
            newmember.Type = type;
            newmember.PrivateProtected = true;
            if (IsStatic)
                newmember.Static = true;
            else
                newmember.Static = inputstatic;
            newmember.Description = "";
            newmember.GetProperty = false;
            newmember.SetProperty = false;
            newmember.ConstructorSet = constructorset;
            newmember.ValueType = valuetype;
            _members.Add(newmember);
        }

        /// <summary>
        /// Adds a property without an underlying parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="inputstatic"></param>
        /// <param name="description"></param>
        /// <param name="getproperty"></param>
        /// <param name="setproperty"></param>
        public void AddProperty(string name, string type, bool inputstatic, string description, bool getproperty, bool setproperty)
        {
            Member newmember = new Member();
            newmember.Name = name;
            newmember.Type = type;
            newmember.PrivateProtected = false;
            if (IsStatic)
                newmember.Static = true;
            else
                newmember.Static = inputstatic;
            newmember.Description = description;
            newmember.GetProperty = getproperty;
            newmember.SetProperty = setproperty;
            newmember.ConstructorSet = false;
            newmember.ValueType = false;
            _members.Add(newmember);
        }

        /// <summary>
        /// Adds a method to the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="visibility"></param>
        /// <param name="inputstatic"></param>
        /// <param name="inputoverride"></param>
        /// <param name="parameters"></param>
        public void AddMethod(string name, string type, Visibility visibility, bool inputstatic, bool inputoverride, List<Method.Parameter> parameters)
        {
            Method newmethod = new Method();
            newmethod.Name=name;
            newmethod.Type=type;
            newmethod.Visibility=visibility;
            if (IsStatic)
                newmethod.Static = true;
            else
                newmethod.Static = inputstatic;
            newmethod.Override = inputoverride;
            newmethod.Parameters = parameters;
            _methods.Add(newmethod);
        }

        /// <summary>
        /// Adds a method to the class
        /// </summary>
        /// <param name="method"></param>
        public void AddMethod(Method method)
        {
            _methods.Add(method);
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

                _members.Add(GetCoordinateMember("R"));
                _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
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

                _members.Add(GetCoordinateMember("x"));
                _members.Add(GetCoordinateMember("y"));
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

                _members.Add(GetCoordinateMember("R"));
                _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
                _members.Add(GetCoordinateMember("Theta", "AngleMeasurement", false));
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

                _members.Add(GetCoordinateMember("R"));
                _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
                _members.Add(GetCoordinateMember("z"));
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

                _members.Add(GetCoordinateMember("x"));
                _members.Add(GetCoordinateMember("y"));
                _members.Add(GetCoordinateMember("z"));
            }
        }

        #region Coordinate interface support methods

        /// <summary>
        /// Builds member for coordinate interface
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected Member GetCoordinateMember(string name)
        {
            return GetCoordinateMember(name, "double", true);
        }

        /// <summary>
        /// Builds member for coordinate interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="valuetype"></param>
        /// <returns></returns>
        protected Member GetCoordinateMember(string name, string type, bool valuetype)
        {
            Member member = new Member();
            member.ConstructorSet = false;
            member.Description = "Returns coordinate " + name;
            member.GetProperty = true;
            member.SetProperty = false;
            member.Name = name;
            member.PrivateProtected = true;
            member.Static = false;
            member.Type = type;
            member.ValueType = valuetype;
            return member;
        }

        #endregion

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

                Member member = new Member();
                member.Attributes = new List<string>();
                member.Attributes.Add("Browsable(false)");
                member.ConstructorSet = false;
                member.Description = "Returns if input data is valid";
                member.GetProperty = true;
                member.GetText = "return true;";
                member.SetProperty = false;
                member.Name = "Valid";
                member.PrivateProtected = false;
                member.Static = false;
                member.Type = "bool";
                member.ValueType = true;
                _members.Add(member);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Reads data from an XmlDocument";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Read";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "XmlNode";
                p.Name = "node";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("if (currnode.Name == this.Name)", true);
                    NotImplemented();
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Saves data to an XmlDocument";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Save";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = "XmlDocument";
                p.Name = "document";
                parameters.Add(p);
                p = new Method.Parameter();
                p.Type = "XmlNode";
                p.Name = "node";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("if (Valid)", true);
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("XmlElement xmlelem;", true);
                    _codeWriter.WriteLine("XmlText xmltext;", true);
                    _codeWriter.WriteLine("xmlelem = document.CreateElement(\"\", this.Name, \"\");", true);
                    NotImplemented();
                    _codeWriter.WriteLine("node.AppendChild(xmlelem);", true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Compares XmlDocument to current values to check if it is saved";
                method.Type = "bool";
                method.Override = false;
                method.Static = false;
                method.Name = "CheckSaved";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = "XmlNode";
                p.Name = "node";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("if (currnode.Name == this.Name)", true);
                    NotImplemented();
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("return false;", true);
                };
                _methods.Add(method);

                Member member = new Member();
                member.Attributes = new List<string>();
                member.Attributes.Add("Category(\"Behavior\")");
                member.Attributes.Add("Description(\"Returns or sets inclusion in XmlSave\")");
                member.ConstructorSet = false;
                member.Description="Decides wether the object should be saved in XmlSave";
                member.GetProperty=true;
                member.SetProperty=true;
                member.Name="IncludeXmlSave";
                member.PrivateProtected=true;
                member.Static=false;
                member.Type="bool";
                member.ValueType=true;
                _members.Add(member);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Calculates the integral function of the object";
                method.Type = "IFunction<double>";
                method.Override = false;
                method.Static = false;
                method.Name = "CalculateIntegrand";
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Calculates the derivative function of the object";
                method.Type = "IFunction<double>";
                method.Override = false;
                method.Static = false;
                method.Name = "CalculateDerivative";
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Calculates the function for a certain double";
                method.Type = "double";
                method.Override = false;
                method.Static = false;
                method.Name = "Calculate";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "double";
                p.Name = "x";
                parameters.Add(p);
                method.Parameters = parameters;
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Returns a clone (shallow copy) of the instance";
                method.Type = "object";
                method.Override = false;
                method.Static = false;
                method.Name = "Clone";
                method.Text = delegate()
                {
                    _codeWriter.Write(_name, true);
                    _codeWriter.Write(" clone = new ");
                    _codeWriter.Write(_name);
                    StringBuilder sb=new StringBuilder("(");
                    foreach (Member member in _members)
                    {
                        if (member.ConstructorSet)
                        {
                            sb.Append("_");
                            sb.Append(member.Name.ToLower());
                            sb.Append(", ");
                        }
                    }
                    if (sb.Length > 1)
                        sb.Remove(sb.Length - 2, 2);
                    sb.Append(");");
                    _codeWriter.WriteLine(sb.ToString());
                    foreach (Member member in _members)
                    {
                        if (!member.ConstructorSet && member.PrivateProtected)
                        {
                            _codeWriter.Write("clone._", true);
                            _codeWriter.Write(member.Name.ToLower());
                            _codeWriter.Write(" = ");
                            _codeWriter.Write("this._");
                            _codeWriter.Write(member.Name.ToLower());
                            _codeWriter.WriteLine(";");
                        }
                        else if (!member.ConstructorSet && member.SetProperty)
                        {
                            _codeWriter.Write("clone.", true);
                            _codeWriter.Write(member.Name);
                            _codeWriter.Write(" = ");
                            _codeWriter.Write("this.");
                            _codeWriter.Write(member.Name);
                            _codeWriter.WriteLine(";");
                        }
                    }
                    _codeWriter.WriteLine("return clone;",true);
                };
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Frees resources when not needed anymore";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Dispose";
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Returns a formatted string representation of the instance";
                method.Type = "string";
                method.Override = false;
                method.Static = false;
                method.Name = "ToString";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "string";
                p.Name = "format";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("if (format == null)", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("return ToString();", true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("string formatupper = format.ToUpper();", true);
                    _codeWriter.WriteLine("//Add code here", true);
                };
                _methods.Add(method);

                EnsureToStringImplemented();

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Provides IFormattable support";
                method.Type = "string";
                method.Override = false;
                method.Static = false;
                method.Name = "ToString";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = "string";
                p.Name = "format";
                parameters.Add(p);
                p = new Method.Parameter();
                p.Type = "IFormatProvider";
                p.Name = "formatProvider";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("return ToString(format);", true);
                };
                _methods.Add(method);
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
                
                Member member = new Member();
                member.ConstructorSet = false;
                member.Description = "";
                member.GetProperty = false;
                member.SetProperty = false;
                member.Name = "list";
                member.PrivateProtected = true;
                member.Static = false;
                member.Type = "List<" + type + ">";
                member.ValueType = false;
                _members.Add(member);

                member = new Member();
                member.ConstructorSet = false;
                member.Description = "Returns number of elements in the list";
                member.GetProperty = true;
                member.GetText = "return _list.Count;";
                member.SetProperty = false;
                member.Name = "Count";
                member.PrivateProtected = false;
                member.Static = false;
                member.Type = "int";
                member.ValueType = true;
                _members.Add(member);

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Adds a " + type + " to the end of the list";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Add";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = type;
                p.Name = "item";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("_list.Add(item);", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Clears the list";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Clear";
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("_list.Clear();", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Implements IEnumerable to use foreach";
                method.Type = "IEnumerator";
                method.Override = false;
                method.Static = false;
                method.Name = "GetEnumerator";
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("return _list.GetEnumerator();", true);
                };
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Compares the instance to an object for sort order";
                method.Type = "int";
                method.Override = false;
                method.Static = false;
                method.Name = "CompareTo";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "object";
                p.Name = "obj";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.Write("if (obj is ", true);
                    _codeWriter.Write(_name);
                    _codeWriter.WriteLine(")");
                    _codeWriter.AddIndentation();
                    _codeWriter.Write("return this.CompareTo((", true);
                    _codeWriter.Write(_name);
                    _codeWriter.WriteLine(")obj);");
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("throw new ArgumentException(\"Wrong type in sort comparison\");", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Compares the instance to an " + _name + " for sort order";
                method.Type = "int";
                method.Override = false;
                method.Static = false;
                method.Name = "CompareTo";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = _name;
                p.Name = _name.ToLower();
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.Write("if (", true);
                    _codeWriter.Write(_name.ToLower());
                    _codeWriter.WriteLine(" == null)");
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
                    _codeWriter.SubtractIndentation();
                    NotImplemented();
                };
                _methods.Add(method);
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

                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Compares the instance to an object";
                method.Type = "bool";
                method.Override = true;
                method.Static = false;
                method.Name = "Equals";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "object";
                p.Name = "obj";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("if (obj==null)", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("return false;", true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.Write("if (obj is ", true);
                    _codeWriter.Write(_name);
                    _codeWriter.WriteLine(")");
                    _codeWriter.AddIndentation();
                    _codeWriter.Write("return this.Equals((", true);
                    _codeWriter.Write(_name);
                    _codeWriter.WriteLine(")obj);");
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("return false;", true);
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Compares the instance to an object, typesafe";
                method.Type = "bool";
                method.Override = false;
                method.Static = false;
                method.Name = "Equals";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = _name;
                p.Name = _name.ToLower();
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.Write("if (", true);
                    _codeWriter.Write(_name.ToLower());
                    _codeWriter.WriteLine("==null)");
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("return false;", true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.Write("if (", true);
                    _codeWriter.Write(_name);
                    _codeWriter.Write(".ReferenceEquals(this, ");
                    _codeWriter.Write(_name.ToLower());
                    _codeWriter.WriteLine("))");
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("return true;", true);
                    _codeWriter.SubtractIndentation();
                    StringBuilder sb = new StringBuilder("return ");
                    foreach (Member member in _members)
                        if(!member.Static)
                        {
                            sb.Append("(this.");
                            sb.Append(member.Name);
                            sb.Append(" == ");
                            sb.Append(_name.ToLower());
                            sb.Append(".");
                            sb.Append(member.Name);
                            sb.Append(") && ");
                        }
                    if (sb.ToString() == "return ")
                        _codeWriter.WriteLine("return true;", true);
                    else
                    {
                        sb.Remove(sb.Length - 4, 4);
                        _codeWriter.Write(sb.ToString(), true);
                        _codeWriter.WriteLine(";");
                    }
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Get hashcode calculated from string representation of the instance";
                method.Type = "int";
                method.Override = true;
                method.Static = false;
                method.Name = "GetHashCode";
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("return this.ToString().GetHashCode();", true);
                };
                _methods.Add(method);

                EnsureToStringImplemented();
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
            {
                if (!_hastostring)
                {
                    var method = new Method();
                    method.Visibility = Visibility.Public;
                    method.Description = "Returns a string representation of the instance";
                    method.Type = "string";
                    method.Override = true;
                    method.Static = false;
                    method.Name = "ToString";
                    method.Text = delegate ()
                    {
                        _codeWriter.WriteLine("StringBuilder sb = new StringBuilder();", true);
                        for (int i = 0; i < _members.Count; i++)
                        {
                            Member member = _members[i];
                            if (!member.Static)
                            {
                                _codeWriter.WriteLine("sb.Append(\"" + member.Name.ToString() + ": \");", true);
                                if(member.Type == "string")
                                    _codeWriter.WriteLine("sb.Append(" + member.Name.ToString() + ");", true);
                                else
                                    _codeWriter.WriteLine("sb.Append(" + member.Name.ToString() + ".ToString());", true);
                                if(i < _members.Count - 1)
                                    _codeWriter.WriteLine("sb.Append(\", \");", true);
                            }
                        }
                        _codeWriter.WriteLine("");
                        _codeWriter.WriteLine("return sb.ToString();", true);
                    };
                    _methods.Add(method);
                    _hastostring = true;
                }
            }
        }

        #endregion

        #region Deconstruct

        public void ImplementDeconstruct()
        {
            if (!IsStatic && _members.Count > 1)
            {
                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Deconstructs object into properties";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Deconstruct";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                foreach (var member in _members)
                {
                    Method.Parameter p = new Method.Parameter();
                    p.Type = member.Type;
                    p.Name = member.Name.ToLower();
                    p.IsOutParameter = true;
                    p.IsNullable = member.ValueIsNullable;
                    parameters.Add(p);
                }
                method.Parameters = parameters;
                method.Text = delegate ()
                {
                    foreach (var member in _members)
                    {
                        _codeWriter.Write(member.Name.ToLower(), true);
                        _codeWriter.Write(" = ");
                        _codeWriter.Write(member.Name);
                        _codeWriter.WriteLine(";");
                    }
                };
                _methods.Add(method);
            }
        }

        #endregion

        #region Utte code functionality

        /// <summary>
        /// Implements Xml Read and Save interface
        /// </summary>
        public void ImplementXmlReadSave()
        {
            if (!IsStatic)
            {
                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Reads data from an XmlDocument";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Read";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                Method.Parameter p = new Method.Parameter();
                p.Type = "XmlNode";
                p.Name = "node";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                    _codeWriter.AddIndentation();
                    bool firstif=true;
                    foreach(Member member in _members)
                        if (member.PrivateProtected)
                        {
                            if (firstif)
                            {
                                _codeWriter.Write("if (currnode.Name == \"", true);
                                firstif = false;
                            }
                            else
                                _codeWriter.Write("else if (currnode.Name == \"", true);
                            _codeWriter.Write(member.Name);
                            _codeWriter.WriteLine("\")");
                            _codeWriter.AddIndentation();
                            if (member.ValueType)
                            {
                                _codeWriter.Write("_", true);
                                _codeWriter.Write(member.Name.ToLower());
                                _codeWriter.Write(" = ");
                                if (member.Type == "string")
                                    _codeWriter.WriteLine("currnode.InnerText;");
                                else
                                {
                                    _codeWriter.Write(member.Type);
                                    _codeWriter.WriteLine(".Parse(currnode.InnerText);");
                                }
                            }
                            else
                            {
                                _codeWriter.Write("_", true);
                                _codeWriter.Write(member.Name.ToLower());
                                _codeWriter.WriteLine(".Read(currnode);");
                            }
                            _codeWriter.SubtractIndentation();
                        }
                    _codeWriter.SubtractIndentation();
                };
                _methods.Add(method);

                method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = "Saves data to an XmlDocument";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Save";
                parameters = new List<Method.Parameter>();
                p = new Method.Parameter();
                p.Type = "XmlDocument";
                p.Name = "document";
                parameters.Add(p);
                p = new Method.Parameter();
                p.Type = "XmlNode";
                p.Name = "node";
                parameters.Add(p);
                method.Parameters = parameters;
                method.Text = delegate()
                {
                    _codeWriter.WriteLine("XmlElement xmlelem;", true);
                    _codeWriter.WriteLine("XmlText xmltext;", true);
                    foreach(Member member in _members)
                        if(member.PrivateProtected)
                        {
                            _codeWriter.WriteLine("");
                            _codeWriter.Write("xmlelem = document.CreateElement(\"\", \"", true);
                            _codeWriter.Write(member.Name);
                            _codeWriter.WriteLine("\", \"\");");
                            if(member.ValueType)
                            {
                                _codeWriter.Write("xmltext = document.CreateTextNode(_", true);
                                _codeWriter.Write(member.Name.ToString().ToLower());
                                if(member.Type=="string")
                                    _codeWriter.WriteLine(");");
                                else
                                    _codeWriter.WriteLine(".ToString());");
                                _codeWriter.WriteLine("xmlelem.AppendChild(xmltext);", true);
                            }
                            else
                            {
                                _codeWriter.Write("_", true);
                                _codeWriter.Write(member.Name.ToString().ToLower());
                                _codeWriter.WriteLine(".Save(document, xmlelem);");
                            }
                            _codeWriter.WriteLine("node.AppendChild(xmlelem);", true);
                        }
                };
                _methods.Add(method);
            }
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
        public void Produce(int indentation)
        {
            _codeWriter.Indentation = indentation;
            _codeWriter.ProduceDescription(_description);
            _codeWriter.ProduceAttributes(_attributes);
            if(_visibility == Visibility.ProtectedInternal)
                _codeWriter.Write("protected internal", true);
            else
                _codeWriter.Write(_visibility.ToString().ToLower(),true);
            if (IsStatic)
                _codeWriter.Write(" static");
            if (IsSealed)
                _codeWriter.Write(" sealed");
            if (_formcomponent)
                _codeWriter.Write(" partial");
            _codeWriter.Write(" class ");
            if (_parentclass == "" && _interfaces.Count == 0)
                _codeWriter.WriteLine(_name);
            else
            {
                _codeWriter.Write(_name);
                _codeWriter.Write(" : ");
                StringBuilder sb = new StringBuilder();
                if (_parentclass != "")
                {
                    sb.Append(_parentclass);
                    sb.Append(", ");
                }
                foreach (string interfacename in _interfaces)
                {
                    sb.Append(interfacename);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                _codeWriter.WriteLine(sb.ToString());
            }
            _codeWriter.WriteLine("{",true);
            _codeWriter.AddIndentation();
            _codeWriter.WriteLine("");
            WritePrivateProtectedMembers(false);
            WritePrivateProtectedMembers(true);
            WriteConstructor();
            WriteStaticConstructor();
            WriteMethods(true,false);
            WriteMethods(false,false);
            WriteMethods(true,true);
            WriteMethods(false,true);
            WriteProperties(false);
            WriteProperties(true);
            WriteClasses(true);
            WriteClasses(false);
            WriteOperators();
            _codeWriter.SubtractIndentation();
            _codeWriter.WriteLine("}",true);
        }

        #endregion

        #endregion

        #region Private/protected methods

        #region Write to file methods

        /// <summary>
        /// Writes Private/protected members to textfile
        /// </summary>
        protected void WritePrivateProtectedMembers(bool staticmembers)
        {
            bool contains = false;
            foreach (Member member in _members)
                if (member.PrivateProtected && (member.Static==staticmembers))
                    contains = true;
            if (contains)
            {
                if(staticmembers)
                    _codeWriter.WriteLine("#region Private static members", true);
                else
                    _codeWriter.WriteLine("#region Private/protected members",true);
                _codeWriter.WriteLine("");
                foreach (Member member in _members)
                    if (member.PrivateProtected && (member.Static == staticmembers))
                    {
                        if(member.Static)
                            _codeWriter.Write("private static ", true);
                        else
                            _codeWriter.Write("private ", true);
                        _codeWriter.Write(member.Type);
                        if (member.ValueIsNullable)
                            _codeWriter.Write("?");
                        _codeWriter.Write(" _");
                        _codeWriter.Write(member.Name.ToLower());
                        _codeWriter.WriteLine(";");
                    }
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes a constructor to textfile
        /// </summary>
        protected void WriteConstructor()
        {
            List<Method.Parameter> parameters = new List<Method.Parameter>();
            List<Member> initialization=new List<Member>();
            foreach (Member member in _members)
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
                if(_formcomponent)
                {
                    _codeWriter.ProduceDescription("Initializes form", parameters);
                    _codeWriter.Write("public ",true);
                    _codeWriter.Write(_name);
                    _codeWriter.WriteLine("()");
                    _codeWriter.WriteLine("{",true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("InitializeComponent();",true);
                    if(_interfaces.Contains("IValid"))
                        _codeWriter.WriteLine("_includexmlsave = true;",true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("");
                }
                if (parameters.Count>0 || initialization.Count>0)
                {
                    StringBuilder sb = new StringBuilder("Initializes ");
                    if(parameters.Count>0)
                        sb.Append("private members with parameters and ");
                    if(initialization.Count>0)
                        sb.Append("private instances of objects");
                    else
                        sb.Remove(sb.Length-5,5);
                    _codeWriter.ProduceDescription(sb.ToString(), parameters);
                    _codeWriter.Write("public ",true);
                    _codeWriter.Write(_name);
                    if (parameters.Count > 0)
                    {
                        sb = new StringBuilder("(");
                        foreach (Method.Parameter parameter in parameters)
                        {
                            sb.Append(parameter.Type);
                            if(parameter.IsNullable)
                                sb.Append("?");
                            sb.Append(" ");
                            sb.Append(parameter.Name);
                            sb.Append(", ");
                        }
                        sb.Remove(sb.Length - 2, 2);
                        sb.Append(")");
                        _codeWriter.WriteLine(sb.ToString());
                    }
                    else
                        _codeWriter.WriteLine("()");
                    _codeWriter.WriteLine("{",true);
                    _codeWriter.AddIndentation();
                    foreach (Method.Parameter parameter in parameters)
                    {
                        if (parameter.HasProtectedMember)
                        {
                            _codeWriter.Write("_", true);
                            _codeWriter.Write(parameter.Name);
                        }
                        else
                            _codeWriter.Write(parameter.PropertyName, true);
                        _codeWriter.Write(" = ");
                        _codeWriter.Write(parameter.Name);
                        _codeWriter.WriteLine(";");
                    }
                    foreach (Member member in initialization)
                    {
                        _codeWriter.Write("_", true);
                        _codeWriter.Write(member.Name.ToLower());
                        _codeWriter.Write(" = new ");
                        _codeWriter.Write(member.Type);
                        _codeWriter.WriteLine("();");
                    }
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("");
                }
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        private string GetDefault(string type)
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

        /// <summary>
        /// Writes a static constructor to textfile
        /// </summary>
        protected void WriteStaticConstructor()
        {
            List<Member> initialization = new List<Member>();
            foreach (Member member in _members)
                if (member.Static)
                {
                    if (member.PrivateProtected && !member.ValueType)
                        initialization.Add(member);
                    else if (member.ValueType)
                        initialization.Add(member);
                }
            if (initialization.Count > 0)
            {
                _codeWriter.WriteLine("#region Static constructor", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceDescription("Static constructor initializing private instances of objects");
                _codeWriter.Write("static ", true);
                _codeWriter.Write(_name);
                _codeWriter.WriteLine("()");
                _codeWriter.WriteLine("{", true);
                _codeWriter.AddIndentation();
                foreach (Member member in initialization)
                {
                    if (member.ValueType)
                    {
                        if(member.PrivateProtected)
                        {
                            _codeWriter.Write("_", true);
                            _codeWriter.Write(member.Name.ToLower());
                        }
                        else
                            _codeWriter.Write(member.Name, true);
                        _codeWriter.Write(" = ");
                        _codeWriter.Write(GetDefault(member.Type));
                        _codeWriter.WriteLine(";");
                    }
                    else
                    {
                        _codeWriter.Write("_", true);
                        _codeWriter.Write(member.Name.ToLower());
                        _codeWriter.Write(" = new ");
                        _codeWriter.Write(member.Type);
                        _codeWriter.WriteLine("();");
                    }
                }
                _codeWriter.SubtractIndentation();
                _codeWriter.WriteLine("}", true);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes methods to textfile
        /// </summary>
        /// <param name="Public"></param>
        protected void WriteMethods(bool Public,bool staticmethods)
        {
            List<Method> methods = new List<Method>();
            foreach (Method method in _methods)
                if (((method.Visibility == Visibility.Public && Public) || (method.Visibility != Visibility.Public && !Public)) && (method.Static == staticmethods))
                    methods.Add(method);
            if (methods.Count>0)
            {
                if(staticmethods)
                    if(Public)
                        _codeWriter.WriteLine("#region Public static methods", true);
                    else
                        _codeWriter.WriteLine("#region Private static methods", true);
                else
                    if (Public)
                        _codeWriter.WriteLine("#region Public methods", true);
                    else
                        _codeWriter.WriteLine("#region Private/protected methods", true);
                _codeWriter.WriteLine("");
                foreach (Method method in methods)
                {
                    _codeWriter.ProduceDescription(method.Description, method.Parameters, method.Type != "void");
                    if (method.Attributes != null && method.Attributes.Count > 0)
                    {
                        _codeWriter.Write("[", true);
                        for (int i = 0; i < method.Attributes.Count; i++)
                        {
                            if (i == 0)
                                _codeWriter.Write(method.Attributes[i]);
                            else
                                _codeWriter.Write(method.Attributes[i], true);
                            if (i == method.Attributes.Count - 1)
                                _codeWriter.WriteLine("]");
                            else
                                _codeWriter.WriteLine(",");
                        }
                    }
                    if (Public)
                    {
                        _codeWriter.Write("public ", true);
                        if (staticmethods)
                            _codeWriter.Write("static ");
                    }
                    else
                    {
                        if (staticmethods)
                            _codeWriter.Write("private static ",true);
                        else
                        {
                            _codeWriter.Write(method.Visibility.ToString().ToLower(), true);
                            _codeWriter.Write(" ");
                        }
                    }
                    if(method.Override && !staticmethods)
                        _codeWriter.Write("override ");
                    _codeWriter.Write(method.Type);
                    _codeWriter.Write(" ");
                    _codeWriter.Write(method.Name);
                    if (method.Parameters==null || method.Parameters.Count == 0)
                        _codeWriter.WriteLine("()");
                    else
                    {
                        StringBuilder sb = new StringBuilder("(");
                        foreach (Method.Parameter parameter in method.Parameters)
                        {
                            if(parameter.IsOutParameter)
                                sb.Append("out ");
                            sb.Append(parameter.Type);
                            if(parameter.IsNullable)
                                sb.Append("?");
                            sb.Append(" ");
                            sb.Append(parameter.Name);
                            sb.Append(", ");
                        }
                        sb.Remove(sb.Length - 2, 2);
                        sb.Append(")");
                        _codeWriter.WriteLine(sb.ToString());
                    }
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    if (method.Text == null)
                        NotImplemented();
                    else
                        method.Text();
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("");
                }
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes properties to textfile
        /// </summary>
        protected void WriteProperties(bool staticproperties)
        {
            List<Member> members = new List<Member>();
            foreach (Member member in _members)
                if (member.GetProperty && (member.Static==staticproperties))
                    members.Add(member);
            if (members.Count>0)
            {
                if(staticproperties)
                    _codeWriter.WriteLine("#region Static properties", true);
                else
                    _codeWriter.WriteLine("#region Properties", true);
                _codeWriter.WriteLine("");
                foreach (Member member in members)
                {
                    string description;
                    if (member.Description == "")
                        if (member.SetProperty)
                            description = "Returns or sets " + member.Name.ToLower();
                        else if (member.ProtectedSetProperty)
                            description = "Returns or protected sets " + member.Name.ToLower();
                        else
                            description = "Returns " + member.Name.ToLower();
                    else
                        description = member.Description;
                    _codeWriter.ProduceDescription(description);
                    _codeWriter.ProduceAttributes(member.Attributes);
                    _codeWriter.Write("public ", true);
                    if (staticproperties)
                        _codeWriter.Write("static ");
                    _codeWriter.Write(member.Type);
                    if (member.ValueIsNullable)
                        _codeWriter.Write("?");
                    _codeWriter.Write(" ");
                    if (!member.PrivateProtected && (member.SetProperty || member.ProtectedSetProperty || member.GetProperty))
                    {
                        _codeWriter.Write(member.Name);
                        if(member.ProtectedSetProperty)
                            _codeWriter.WriteLine(" { get; protected set; }");
                        else if(member.SetProperty)
                            _codeWriter.WriteLine(" { get; set; }");
                        else
                            _codeWriter.WriteLine(" { get; }");
                    }
                    else
                    {
                        _codeWriter.WriteLine(member.Name);
                        _codeWriter.WriteLine("{", true);
                        _codeWriter.AddIndentation();
                        _codeWriter.WriteLine("get", true);
                        _codeWriter.WriteLine("{", true);
                        _codeWriter.AddIndentation();
                        if (!string.IsNullOrEmpty(member.GetText))
                            _codeWriter.WriteLine(member.GetText, true);
                        else if (member.PrivateProtected)
                        {
                            _codeWriter.Write("return _", true);
                            _codeWriter.Write(member.Name.ToLower());
                            _codeWriter.WriteLine(";");
                        }
                        else
                            NotImplemented();
                        _codeWriter.SubtractIndentation();
                        _codeWriter.WriteLine("}", true);
                        if (member.ProtectedSetProperty)
                            _codeWriter.WriteLine("protected", true);
                        if (member.SetProperty || member.ProtectedSetProperty)
                        {
                            _codeWriter.WriteLine("set", true);
                            _codeWriter.WriteLine("{", true);
                            _codeWriter.AddIndentation();
                            if (!string.IsNullOrEmpty(member.SetText))
                                _codeWriter.WriteLine(member.SetText, true);
                            else if (member.PrivateProtected)
                            {
                                _codeWriter.Write("_", true);
                                _codeWriter.Write(member.Name.ToLower());
                                _codeWriter.WriteLine(" = value;");
                            }
                            else
                                NotImplemented();
                            _codeWriter.SubtractIndentation();
                            _codeWriter.WriteLine("}", true);
                        }
                        _codeWriter.SubtractIndentation();
                        _codeWriter.WriteLine("}", true);
                    }
                    _codeWriter.WriteLine("");
                }
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes operators to textfile
        /// </summary>
        protected void WriteOperators()
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

        /// <summary>
        /// Writes classes to textfile
        /// </summary>
        /// <param name="Public"></param>
        protected void WriteClasses(bool Public)
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

        #region Private/protected static members

        protected static List<string> _implementedinterfaces;

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
