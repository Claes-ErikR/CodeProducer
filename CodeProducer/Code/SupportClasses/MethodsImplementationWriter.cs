using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.Helpers;

namespace Utte.Code.Code.SupportClasses
{

    /// <summary>
    /// Class for tracking and producing methods code
    /// </summary>
    public class MethodsImplementationWriter
    {
        private List<Method> _methods;
        private bool _hastostring;
        private DefinitionType _definitiontype;

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        public MethodsImplementationWriter(DefinitionType definitionType)
        {
            _methods = new List<Method>();
            _hastostring = false;
            _definitiontype = definitionType;
        }

        /// <summary>
        /// Checks if object contains methods with given parameters
        /// </summary>
        /// <param name="publicMethods"></param>
        /// <param name="staticMethods"></param>
        /// <returns></returns>
        public bool HasMethods(bool publicMethods, bool staticMethods)
        {
            for (int i = 0; i < _methods.Count; i++)
                if (((_methods[i].Visibility == Visibility.Public && publicMethods) || (_methods[i].Visibility != Visibility.Public && !publicMethods)) && (_methods[i].Static == staticMethods))
                    return true;

            return false;
        }

        /// <summary>
        /// Writes methods with given parameters
        /// </summary>
        /// <param name="codeWriter"></param>
        /// <param name="publicMethods"></param>
        /// <param name="staticMethods"></param>
        public void WriteMethods(CodeWriter codeWriter, bool publicMethods, bool staticMethods)
        {
            List<Method> methods = new List<Method>();
            foreach (Method method in _methods)
                if (((method.Visibility == Visibility.Public && publicMethods) || (method.Visibility != Visibility.Public && !publicMethods)) && (method.Static == staticMethods))
                    methods.Add(method);

            foreach (Method method in methods)
            {
                codeWriter.ProduceDescription(method.Description, method.Parameters, method.Type != "void");
                if (method.Attributes != null && method.Attributes.Count > 0)
                {
                    codeWriter.Write("[", true);
                    for (int i = 0; i < method.Attributes.Count; i++)
                    {
                        if (i == 0)
                            codeWriter.Write(method.Attributes[i]);
                        else
                            codeWriter.Write(method.Attributes[i], true);
                        if (i == method.Attributes.Count - 1)
                            codeWriter.WriteLine("]");
                        else
                            codeWriter.WriteLine(",");
                    }
                }
                if (publicMethods)
                {
                    codeWriter.Write("public ", true);
                    if (staticMethods)
                        codeWriter.Write("static ");
                }
                else
                {
                    if (staticMethods)
                        codeWriter.Write("private static ", true);
                    else
                    {
                        codeWriter.Write(method.Visibility.ToString().ToLower(), true);
                        codeWriter.Write(" ");
                    }
                }
                if (method.Override && !staticMethods)
                    codeWriter.Write("override ");
                codeWriter.Write(method.Type);
                codeWriter.Write(" ");
                codeWriter.Write(method.Name);
                if (method.Parameters == null || method.Parameters.Count == 0)
                    codeWriter.WriteLine("()");
                else
                {
                    StringBuilder sb = new StringBuilder("(");
                    foreach (Method.Parameter parameter in method.Parameters)
                    {
                        if (parameter.IsOutParameter)
                            sb.Append("out ");
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
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                if (method.Text == null)
                    NotImplemented(codeWriter);
                else
                    method.Text();
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
                codeWriter.WriteLine("");
            }
        }

        public void AddDeconstructMethod(CodeWriter codeWriter, List<Member> members)
        {
            if (members.Count > 1)
            {
                Method method = new Method();
                method.Visibility = Visibility.Public;
                method.Description = _definitiontype == DefinitionType.Struct ? "Deconstructs struct into members" : "Deconstructs object into properties";
                method.Type = "void";
                method.Override = false;
                method.Static = false;
                method.Name = "Deconstruct";
                List<Method.Parameter> parameters = new List<Method.Parameter>();
                foreach (var member in members)
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
                    foreach (var member in members)
                    {
                        codeWriter.Write(member.Name.ToLower(), true);
                        codeWriter.Write(" = ");
                        codeWriter.Write(member.Name);
                        codeWriter.WriteLine(";");
                    }
                };
                _methods.Add(method);
            }
        }

        public void AddIsEmptyMethod(CodeWriter codeWriter, string className, bool equalityImplemented)
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Compares to empty instance";
            method.Type = "bool";
            method.Override = false;
            method.Static = true;
            method.Name = "IsEmpty";
            List<Method.Parameter> parameters = new List<Method.Parameter>();
            Method.Parameter p = new Method.Parameter();
            p.Type = className;
            p.Name = "instance";
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                if(equalityImplemented)
                    codeWriter.WriteLine("return instance == Empty;", true);
                else
                    codeWriter.WriteLine("throw new NotImplementedException();", true);
            };

            _methods.Add(method);
        }

        public void EnsureToStringImplemented(CodeWriter codeWriter, List<Member> members)
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
                    codeWriter.WriteLine("StringBuilder sb = new StringBuilder();", true);
                    for (int i = 0; i < members.Count; i++)
                    {
                        Member member = members[i];
                        if (!member.Static)
                        {
                            codeWriter.WriteLine("sb.Append(\"" + member.Name.ToString() + ": \");", true);
                            if (member.Type == "string")
                                codeWriter.WriteLine("sb.Append(" + member.Name.ToString() + ");", true);
                            else
                                codeWriter.WriteLine("sb.Append(" + member.Name.ToString() + ".ToString());", true);
                            if (i < members.Count - 1)
                                codeWriter.WriteLine("sb.Append(\", \");", true);
                        }
                    }
                    codeWriter.WriteLine("");
                    codeWriter.WriteLine("return sb.ToString();", true);
                };
                _methods.Add(method);
                _hastostring = true;
            }
        }

        public void AddEqualityComparisonMethods(CodeWriter codeWriter, string typeName, List<Member> members)
        {
            EnsureToStringImplemented(codeWriter, members);

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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("if (obj==null)", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("return false;", true);
                codeWriter.SubtractIndentation();
                codeWriter.Write("if (obj is ", true);
                codeWriter.Write(typeName);
                codeWriter.WriteLine(")");
                codeWriter.AddIndentation();
                codeWriter.Write("return this.Equals((", true);
                codeWriter.Write(typeName);
                codeWriter.WriteLine(")obj);");
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("return false;", true);
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
            p.Type = typeName;
            p.Name = typeName.ToLower();
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                codeWriter.Write("if (", true);
                codeWriter.Write(typeName.ToLower());
                codeWriter.WriteLine("==null)");
                codeWriter.AddIndentation();
                codeWriter.WriteLine("return false;", true);
                codeWriter.SubtractIndentation();
                if (_definitiontype != DefinitionType.Struct)
                {
                    codeWriter.Write("if (", true);
                    codeWriter.Write(typeName);
                    codeWriter.Write(".ReferenceEquals(this, ");
                    codeWriter.Write(typeName.ToLower());
                    codeWriter.WriteLine("))");
                    codeWriter.AddIndentation();
                    codeWriter.WriteLine("return true;", true);
                    codeWriter.SubtractIndentation();
                }
                StringBuilder sb = new StringBuilder("return ");
                foreach (Member member in members)
                    if (!member.Static)
                    {
                        sb.Append("(this.");
                        sb.Append(member.Name);
                        sb.Append(" == ");
                        sb.Append(typeName.ToLower());
                        sb.Append(".");
                        sb.Append(member.Name);
                        sb.Append(") && ");
                    }
                if (sb.ToString() == "return ")
                    codeWriter.WriteLine("return true;", true);
                else
                {
                    sb.Remove(sb.Length - 4, 4);
                    codeWriter.Write(sb.ToString(), true);
                    codeWriter.WriteLine(";");
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("return this.ToString().GetHashCode();", true);
            };
            _methods.Add(method);
        }

        public void AddSortComparisonMethods(CodeWriter codeWriter, string typeName)
        {
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
            method.Text = delegate ()
            {
                codeWriter.Write("if (obj is ", true);
                codeWriter.Write(typeName);
                codeWriter.WriteLine(")");
                codeWriter.AddIndentation();
                codeWriter.Write("return this.CompareTo((", true);
                codeWriter.Write(typeName);
                codeWriter.WriteLine(")obj);");
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("throw new ArgumentException(\"Wrong type in sort comparison\");", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Compares the instance to an " + typeName + " for sort order";
            method.Type = "int";
            method.Override = false;
            method.Static = false;
            method.Name = "CompareTo";
            parameters = new List<Method.Parameter>();
            p = new Method.Parameter();
            p.Type = typeName;
            p.Name = typeName.ToLower();
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                if (_definitiontype != DefinitionType.Struct)
                {
                    codeWriter.Write("if (", true);
                    codeWriter.Write(typeName.ToLower());
                    codeWriter.WriteLine(" == null)");
                    codeWriter.AddIndentation();
                    codeWriter.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
                    codeWriter.SubtractIndentation();
                }
                NotImplemented(codeWriter);
            };
            _methods.Add(method);
        }

        public void AddListWrapperMethods(CodeWriter codeWriter, string type)
        {
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("_list.Add(item);", true);
            };
            _methods.Add(method);

            method.Visibility = Visibility.Public;
            method.Description = "Adds the elements of the collection to the end of the list";
            method.Type = "void";
            method.Override = false;
            method.Static = false;
            method.Name = "AddRange";
            parameters = new List<Method.Parameter>();
            p = new Method.Parameter();
            p.Type = "IEnumerable<" + type + ">";
            p.Name = "collection";
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                codeWriter.WriteLine("_list.AddRange(collection);", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Clears the list";
            method.Type = "void";
            method.Override = false;
            method.Static = false;
            method.Name = "Clear";
            method.Text = delegate ()
            {
                codeWriter.WriteLine("_list.Clear();", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Removes first occurrence of a " + type + " from the list";
            method.Type = "bool";
            method.Override = false;
            method.Static = false;
            method.Name = "Remove";
            parameters = new List<Method.Parameter>();
            p = new Method.Parameter();
            p.Type = type;
            p.Name = "item";
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                codeWriter.WriteLine("return _list.Remove(item);", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Removes the element at position index from the list";
            method.Type = "void";
            method.Override = false;
            method.Static = false;
            method.Name = "RemoveAt";
            parameters = new List<Method.Parameter>();
            p = new Method.Parameter();
            p.Type = "int";
            p.Name = "index";
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                codeWriter.WriteLine("_list.RemoveAt(index);", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Inserts an element into the list at index";
            method.Type = "void";
            method.Override = false;
            method.Static = false;
            method.Name = "Insert";
            parameters = new List<Method.Parameter>();
            p = new Method.Parameter();
            p.Type = "int";
            p.Name = "index";
            parameters.Add(p);
            p = new Method.Parameter();
            p.Type = type;
            p.Name = "item";
            parameters.Add(p);
            method.Parameters = parameters;
            method.Text = delegate ()
            {
                codeWriter.WriteLine("_list.Insert(index, item);", true);
            };
            _methods.Add(method);

            method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Implements IEnumerable to use foreach";
            method.Type = "IEnumerator";
            method.Override = false;
            method.Static = false;
            method.Name = "GetEnumerator";
            method.Text = delegate ()
            {
                codeWriter.WriteLine("return _list.GetEnumerator();", true);
            };
            _methods.Add(method);
        }

        public void AddIFormattableMethods(CodeWriter codeWriter, List<Member> members)
        {
            EnsureToStringImplemented(codeWriter, members);

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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("if (format == null)", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("return ToString();", true);
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("string formatupper = format.ToUpper();", true);
                codeWriter.WriteLine("//Add code here", true);
            };
            _methods.Add(method);

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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("return ToString(format);", true);
            };
            _methods.Add(method);
        }

        public void AddIDisposableMethod()
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Frees resources when not needed anymore";
            method.Type = "void";
            method.Override = false;
            method.Static = false;
            method.Name = "Dispose";
            _methods.Add(method);
        }

        public void AddICloneableMethod(CodeWriter codeWriter, string className, IEnumerable<Member> members)
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Returns a clone (shallow copy) of the instance";
            method.Type = "object";
            method.Override = false;
            method.Static = false;
            method.Name = "Clone";
            method.Text = delegate ()
            {
                codeWriter.Write(className, true);
                codeWriter.Write(" clone = new ");
                codeWriter.Write(className);
                StringBuilder sb = new StringBuilder("(");
                foreach (Member member in members)
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
                codeWriter.WriteLine(sb.ToString());
                foreach (Member member in members)
                {
                    if (!member.ConstructorSet && member.PrivateProtected)
                    {
                        codeWriter.Write("clone._", true);
                        codeWriter.Write(member.Name.ToLower());
                        codeWriter.Write(" = ");
                        codeWriter.Write("this._");
                        codeWriter.Write(member.Name.ToLower());
                        codeWriter.WriteLine(";");
                    }
                    else if (!member.ConstructorSet && member.SetProperty)
                    {
                        codeWriter.Write("clone.", true);
                        codeWriter.Write(member.Name);
                        codeWriter.Write(" = ");
                        codeWriter.Write("this.");
                        codeWriter.Write(member.Name);
                        codeWriter.WriteLine(";");
                    }
                }
                codeWriter.WriteLine("return clone;", true);
            };
            _methods.Add(method);
        }

        public void AddIIntegrableMethod(string type)
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Calculates the integral function of the object";
            method.Type = "IFunction<" + type + ">";
            method.Override = false;
            method.Static = false;
            method.Name = "CalculateIntegrand";
            _methods.Add(method);
        }

        public void AddIDerivableMethod(string type)
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Calculates the derivative function of the object";
            method.Type = "IFunction<" + type + ">";
            method.Override = false;
            method.Static = false;
            method.Name = "CalculateDerivative";
            _methods.Add(method);
        }

        public void AddIFunctionMethod(string type)
        {
            Method method = new Method();
            method.Visibility = Visibility.Public;
            method.Description = "Calculates the function for a certain " + type;
            method.Type = type;
            method.Override = false;
            method.Static = false;
            method.Name = "Calculate";
            List<Method.Parameter> parameters = new List<Method.Parameter>();
            Method.Parameter p = new Method.Parameter();
            p.Type = type;
            p.Name = "x";
            parameters.Add(p);
            method.Parameters = parameters;
            _methods.Add(method);
        }

        public void AddIXmlSaveMethods(CodeWriter codeWriter)
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("if (currnode.Name == this.Name)", true);
                NotImplemented(codeWriter);
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("if (Valid)", true);
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("XmlElement xmlelem;", true);
                codeWriter.WriteLine("XmlText xmltext;", true);
                codeWriter.WriteLine("xmlelem = document.CreateElement(\"\", this.Name, \"\");", true);
                NotImplemented(codeWriter);
                codeWriter.WriteLine("node.AppendChild(xmlelem);", true);
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                codeWriter.WriteLine("{", true);
                codeWriter.AddIndentation();
                codeWriter.WriteLine("if (currnode.Name == this.Name)", true);
                NotImplemented(codeWriter);
                codeWriter.SubtractIndentation();
                codeWriter.WriteLine("}", true);
                codeWriter.WriteLine("return false;", true);
            };
            _methods.Add(method);
        }

        public void AddXmlReadSaveMethods(CodeWriter codeWriter, IEnumerable<Member> members)
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("foreach (XmlNode currnode in node)", true);
                codeWriter.AddIndentation();
                bool firstif = true;
                foreach (Member member in members)
                    if (member.PrivateProtected)
                    {
                        if (firstif)
                        {
                            codeWriter.Write("if (currnode.Name == \"", true);
                            firstif = false;
                        }
                        else
                            codeWriter.Write("else if (currnode.Name == \"", true);
                        codeWriter.Write(member.Name);
                        codeWriter.WriteLine("\")");
                        codeWriter.AddIndentation();
                        if (member.ValueType)
                        {
                            codeWriter.Write("_", true);
                            codeWriter.Write(member.Name.ToLower());
                            codeWriter.Write(" = ");
                            if (member.Type == "string")
                                codeWriter.WriteLine("currnode.InnerText;");
                            else
                            {
                                codeWriter.Write(member.Type);
                                codeWriter.WriteLine(".Parse(currnode.InnerText);");
                            }
                        }
                        else
                        {
                            codeWriter.Write("_", true);
                            codeWriter.Write(member.Name.ToLower());
                            codeWriter.WriteLine(".Read(currnode);");
                        }
                        codeWriter.SubtractIndentation();
                    }
                codeWriter.SubtractIndentation();
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
            method.Text = delegate ()
            {
                codeWriter.WriteLine("XmlElement xmlelem;", true);
                codeWriter.WriteLine("XmlText xmltext;", true);
                foreach (Member member in members)
                    if (member.PrivateProtected)
                    {
                        codeWriter.WriteLine("");
                        codeWriter.Write("xmlelem = document.CreateElement(\"\", \"", true);
                        codeWriter.Write(member.Name);
                        codeWriter.WriteLine("\", \"\");");
                        if (member.ValueType)
                        {
                            codeWriter.Write("xmltext = document.CreateTextNode(_", true);
                            codeWriter.Write(member.Name.ToString().ToLower());
                            if (member.Type == "string")
                                codeWriter.WriteLine(");");
                            else
                                codeWriter.WriteLine(".ToString());");
                            codeWriter.WriteLine("xmlelem.AppendChild(xmltext);", true);
                        }
                        else
                        {
                            codeWriter.Write("_", true);
                            codeWriter.Write(member.Name.ToString().ToLower());
                            codeWriter.WriteLine(".Save(document, xmlelem);");
                        }
                        codeWriter.WriteLine("node.AppendChild(xmlelem);", true);
                    }
            };
            _methods.Add(method);
        }

        private void NotImplemented(CodeWriter codeWriter)
        {
            codeWriter.WriteLine("throw new NotImplementedException();", true);
        }
    }
}
