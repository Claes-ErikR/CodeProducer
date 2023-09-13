using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Utte.Text;

namespace Utte.Code
{

    /// <summary>
    /// Class for producing structured structs
    /// </summary>
    public class StructProducer : CodeGeneratorBase
    {

        #region Private/protected members

        protected string _description;
        protected string _visibility;
        protected List<StructMember> _members;
        protected bool _constructor;
        protected bool _equalitycomparison;
        protected bool _produceempty;
        protected bool _implementdeconstruct;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes class with members
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="visibility"></param>
        /// <param name="members"></param>
        /// <param name="constructor"></param>
        /// <param name="equalitycomparison"></param>
        /// <param name="produceempty"></param>
        /// <param name="filename"></param>
        /// <param name="operatorclasses"></param>
        /// <param name="implementdeconstruct"></param>
        public StructProducer(string name, string description, string visibility, List<StructMember> members, bool constructor, bool equalitycomparison, bool produceempty, string filename, List<string> operatorclasses, bool implementdeconstruct) : base(name)
        {
            _streamwriter = new StreamWriter(filename);
            _description = description;
            _visibility = visibility;
            _members = members;
            _constructor = constructor;
            _equalitycomparison = equalitycomparison;
            _produceempty = produceempty;
            _operatorimplementations.ImplementationClasses.AddRange(operatorclasses);
            if (_operatorimplementations.ImplementationClasses.Count > 0)
                _operatorimplementations.ImplementsArithmetic = true;
            _implementdeconstruct = implementdeconstruct;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces the struct
        /// </summary>
        public void Produce()
        {
            _indentspaces = 0;
            if (_description != "")
                ProduceDescription(_description);
            if (_visibility == "ProtectedInternal")
                Write("protected internal", true);
            else
                Write(_visibility.ToString().ToLower(), true);
            Write(" struct ");
            if (_equalitycomparison)
            {
                Write(_name);
                Write(" : IEquatable<");
                Write(_name);
                WriteLine(">");
            }
            else
                WriteLine(_name);
            WriteLine("{", true);
            _indentspaces += 4;
            ProduceMembers();
            ProduceConstructor();
            ProducePublicMethods();
            ProduceEmpty();
            ProduceOperators();
            _indentspaces -= 4;
            WriteLine("}", true);
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Produces support for empty instance
        /// </summary>
        protected void ProduceEmpty()
        {
            if (_produceempty)
            {
                WriteLine("#region Static constructor", true);
                WriteLine("");
                ProduceDescription("Sets empty instance", false);
                WriteLine("static " + _name + "()", true);
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("Empty = new " + _name + "();", true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("");
                WriteLine("#endregion", true);
                WriteLine("");

                if (_equalitycomparison)
                {
                    WriteLine("#region Public static methods", true);
                    WriteLine("");
                    StructMember structmember = new StructMember();
                    structmember.Name = "instance";
                    structmember.Type = _name;
                    List<StructMember> structmemberlist = new List<StructMember>() { structmember };
                    ProduceDescription("Compares to empty instance", structmemberlist, true);
                    WriteLine("public static bool IsEmpty(" + _name + " instance)", true);
                    WriteLine("{", true);
                    _indentspaces += 4;
                    WriteLine("return instance == Empty;", true);
                    _indentspaces -= 4;
                    WriteLine("}", true);
                    WriteLine("");
                    WriteLine("#endregion", true);
                    WriteLine("");
                }

                WriteLine("#region Static properties", true);
                WriteLine("");
                ProduceDescription("Returns empty instance", false);
                WriteLine("public static " + _name + " Empty { get; }", true);
                WriteLine("");
                WriteLine("#endregion", true);
                WriteLine("");
            }
        }

        /// <summary>
        /// Produces public methods
        /// </summary>
        protected void ProducePublicMethods()
        {
            WriteLine("#region Public methods", true);
            WriteLine("");
            ProduceDescription("Returns string representation of struct", true);
            WriteLine("public override string ToString()", true);
            WriteLine("{", true);
            _indentspaces += 4;
            StringBuilder sb = new StringBuilder();
            sb.Append("return ");
            foreach (StructMember member in _members)
            {
                sb.Append(member.Name);
                if (member.Type != "string")
                    sb.Append(".ToString()");
                sb.Append(" + \" \" + ");
            }
            if (sb.Length > 9)
                sb.Remove(sb.Length - 9, 9);
            sb.Append(";");
            WriteLine(sb.ToString(), true);
            _indentspaces -= 4;
            WriteLine("}", true);
            WriteLine("");
            if (_equalitycomparison)
            {
                ProduceDescription("Compares the instance to an object add parameter description ...", true);
                WriteLine("public override bool Equals(object obj)", true);
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("if (obj==null)", true);
                _indentspaces += 4;
                WriteLine("return false;", true);
                _indentspaces -= 4;
                Write("if (obj is ", true);
                Write(_name);
                WriteLine(")");
                _indentspaces += 4;
                Write("return this.Equals((", true);
                Write(_name);
                WriteLine(")obj);");
                _indentspaces -= 4;
                WriteLine("return false;", true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("");

                ProduceDescription("Compares the instance to an object, typesafe add parameter description ...", true);
                Write("public bool Equals(", true);
                Write(_name);
                WriteLine(" obj)");
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("if (obj==null)", true);
                _indentspaces += 4;
                WriteLine("return false;", true);
                _indentspaces -= 4;
                sb = new StringBuilder();
                sb.Append("return ");
                foreach (StructMember member in _members)
                {
                    sb.Append("(this.");
                    sb.Append(member.Name);
                    sb.Append("==");
                    sb.Append("obj.");
                    sb.Append(member.Name);
                    sb.Append(") && ");
                }
                sb.Remove(sb.Length - 4, 4);
                sb.Append(";");
                WriteLine(sb.ToString(), true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("");

                ProduceDescription("Get hashcode calculated from string representation of the instance", true);
                WriteLine("public override int GetHashCode()", true);
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("return this.ToString().GetHashCode();", true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("");
            }
            if(_implementdeconstruct)
            {
                if (_members.Count > 1)
                {
                    ProduceDescription("Deconstructs struct into properties", true);
                    Write("public void Deconstruct(", true);
                    for (int i = 0; i < _members.Count; i++)
                    {
                        Write("out ");
                        Write(_members[i].Type);
                        if (_members[i].IsNullable)
                            Write("?");
                        Write(" ");
                        Write(_members[i].Name.ToLower());
                        if(i < _members.Count - 1)
                            Write(", ");
                    }
                    Write(")");
                    WriteLine("{", true);
                    _indentspaces += 4;
                    foreach (var member in _members)
                    {
                        Write(member.Name.ToLower(), true);
                        Write(" = ");
                        Write(member.Name);
                        WriteLine(";");
                    }
                    _indentspaces -= 4;
                    WriteLine("}", true);
                    WriteLine("");
                }
            }
            WriteLine("#endregion", true);
            WriteLine("");
        }

        /// <summary>
        /// Produces operators
        /// </summary>
        protected void ProduceOperators()
        {
            if (_equalitycomparison || _operatorimplementations.ImplementsArithmetic)
            {
                WriteLine("#region Operators", true);
                WriteLine("");
                if (_equalitycomparison)
                {
                    ProduceDescription("Compares lhs and rhs for equality");
                    WriteLine("/// <param name=\"lhs\"></param>", true);
                    WriteLine("/// <param name=\"rhs\"></param>", true);
                    WriteLine("/// <returns></returns>", true);
                    Write("public static bool operator ==(", true);
                    Write(_name);
                    Write(" lhs, ");
                    Write(_name);
                    WriteLine(" rhs)");
                    WriteLine("{", true);
                    _indentspaces += 4;
                    Write("return ", true);
                    Write(_name);
                    WriteLine(".Equals(lhs,rhs);");
                    _indentspaces -= 4;
                    WriteLine("}", true);
                    WriteLine("");
                    ProduceDescription("Compares lhs and rhs for inequality");
                    WriteLine("/// <param name=\"lhs\"></param>", true);
                    WriteLine("/// <param name=\"rhs\"></param>", true);
                    WriteLine("/// <returns></returns>", true);
                    Write("public static bool operator !=(", true);
                    Write(_name);
                    Write(" lhs, ");
                    Write(_name);
                    WriteLine(" rhs)");
                    WriteLine("{", true);
                    _indentspaces += 4;
                    WriteLine("return !(lhs == rhs);", true);
                    _indentspaces -= 4;
                    WriteLine("}", true);
                    WriteLine("");
                }
                if (_operatorimplementations.ImplementsArithmetic)
                {
                    _operatorimplementations.WriteOperators(_streamwriter, "    ", _name);
                }
                WriteLine("#endregion", true);
                WriteLine("");
            }
        }

        /// <summary>
        /// Produces constructor if necessary
        /// </summary>
        protected void ProduceConstructor()
        {
            List<StructMember> members = new List<StructMember>();
            foreach (StructMember member in _members)
                if (_constructor || member.ReadOnly)
                    members.Add(member);
            if (members.Count != 0)
            {
                WriteLine("#region Constructors", true);
                WriteLine("");
                ProduceDescription("Initializes members", members);
                Write("public ", true);
                Write(_name);
                Write("(");
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
                Write(sb.ToString());
                WriteLine(")");
                WriteLine("{", true);
                _indentspaces += 4;
                foreach (StructMember member in members)
                {
                    Write(member.Name, true);
                    Write(" = ");
                    Write(member.Name.ToLower());
                    WriteLine(";");
                }
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("");
                WriteLine("#endregion", true);
                WriteLine("");
            }
        }

        /// <summary>
        /// Produces public members
        /// </summary>
        protected void ProduceMembers()
        {
            WriteLine("");
            WriteLine("#region Public members", true);
            WriteLine("");
            foreach (StructMember member in _members)
            {
                Write("public ", true);
                if (member.ReadOnly)
                    Write("readonly ");
                Write(member.Type);
                if (member.IsNullable)
                    Write("?");
                Write(" ");
                Write(member.Name);
                WriteLine(";");
            }
            WriteLine("");
            WriteLine("#endregion", true);
            WriteLine("");
        }

        #endregion

    }

    /// <summary>
    /// Struct for managing a menber of a struct
    /// </summary>
    public struct StructMember
    {

        #region Public members

        public string Name;
        public string Type;
        public bool ReadOnly;
        public bool IsNullable;

        #endregion

        #region Public methods

        /// <summary>
        /// Returns string representation of the struct
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string isNullableText = IsNullable ? "?" : "";
            if (ReadOnly)
                return Name + " " + Type + isNullableText + " readonly";
            return Name + " " + Type + isNullableText;
        }

        #endregion

    }
}
