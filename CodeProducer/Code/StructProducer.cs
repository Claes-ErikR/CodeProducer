using System.Collections.Generic;
using System.Text;
using Utte.Code.Code.SupportClasses;
using Utte.Code.Code.Helpers;

namespace Utte.Code
{

    /// <summary>
    /// Class for producing structured structs
    /// </summary>
    public sealed class StructProducer : CodeGeneratorBase
    {

        #region Private members

        private string _description;
        private string _visibility;
        private List<Member> _members;
        private bool _constructor;
        private bool _produceempty;
        private bool _implementdeconstruct;

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
        public StructProducer(string name, string description, string visibility, List<Member> members, bool constructor, bool equalitycomparison, bool produceempty, string filename, List<string> operatorclasses, bool implementdeconstruct) : base(name)
        {
            _codeWriter = new CodeWriter(filename, 4);
            _description = description;
            _visibility = visibility;
            _members = members;
            _constructor = constructor;
            _operatorImplementationWriter.ImplementsEquality = equalitycomparison;
            _produceempty = produceempty;
            _operatorImplementationWriter.ImplementationClasses.AddRange(operatorclasses);
            if (_operatorImplementationWriter.ImplementationClasses.Count > 0)
                _operatorImplementationWriter.ImplementsArithmetic = true;
            _implementdeconstruct = implementdeconstruct;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces the struct
        /// </summary>
        public void Produce()
        {
            _codeWriter.Indentation = 0;
            if (_description != "")
                _codeWriter.ProduceDescription(_description);
            _codeWriter.ProduceStructDeclaration(_name, _visibility, _operatorImplementationWriter.ImplementsEquality);
            _codeWriter.WriteLine("{", true);
            _codeWriter.AddIndentation();
            ProduceMembers();
            ProduceConstructor();
            ProducePublicMethods();
            ProduceEmpty();
            ProduceOperators();
            _codeWriter.SubtractIndentation();
            _codeWriter.WriteLine("}", true);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Produces support for empty instance
        /// </summary>
        private void ProduceEmpty()
        {
            if (_produceempty)
            {
                _codeWriter.WriteLine("#region Static constructor", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceStaticStructConstructor(_name);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");

                if (_operatorImplementationWriter.ImplementsEquality)
                {
                    _codeWriter.WriteLine("#region Public static methods", true);
                    _codeWriter.WriteLine("");
                    Member structmember = new Member();
                    structmember.Name = "instance";
                    structmember.Type = _name;
                    List<Member> structmemberlist = new List<Member>() { structmember };
                    _codeWriter.ProduceDescription("Compares to empty instance", structmemberlist, true);
                    _codeWriter.WriteLine("public static bool IsEmpty(" + _name + " instance)", true);
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    _codeWriter.WriteLine("return instance == Empty;", true);
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("");
                    _codeWriter.WriteLine("#endregion", true);
                    _codeWriter.WriteLine("");
                }

                _codeWriter.WriteLine("#region Static properties", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceDescription("Returns empty instance", false);
                _codeWriter.WriteLine("public static " + _name + " Empty { get; }", true);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Produces public methods
        /// </summary>
        private void ProducePublicMethods()
        {
            _codeWriter.WriteLine("#region Public methods", true);
            _codeWriter.WriteLine("");
            _codeWriter.ProduceDescription("Returns string representation of struct", true);
            _codeWriter.WriteLine("public override string ToString()", true);
            _codeWriter.WriteLine("{", true);
            _codeWriter.AddIndentation();
            StringBuilder sb = new StringBuilder();
            sb.Append("return ");
            foreach (Member member in _members)
            {
                sb.Append(member.Name);
                if (member.Type != "string")
                    sb.Append(".ToString()");
                sb.Append(" + \" \" + ");
            }
            if (sb.Length > 9)
                sb.Remove(sb.Length - 9, 9);
            sb.Append(";");
            _codeWriter.WriteLine(sb.ToString(), true);
            _codeWriter.SubtractIndentation();
            _codeWriter.WriteLine("}", true);
            _codeWriter.WriteLine("");
            if (_operatorImplementationWriter.ImplementsEquality)
            {
                _codeWriter.ProduceDescription("Compares the instance to an object add parameter description ...", true);
                _codeWriter.WriteLine("public override bool Equals(object obj)", true);
                _codeWriter.WriteLine("{", true);
                _codeWriter.AddIndentation();
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
                _codeWriter.SubtractIndentation();
                _codeWriter.WriteLine("}", true);
                _codeWriter.WriteLine("");

                _codeWriter.ProduceDescription("Compares the instance to an object, typesafe add parameter description ...", true);
                _codeWriter.Write("public bool Equals(", true);
                _codeWriter.Write(_name);
                _codeWriter.WriteLine(" obj)");
                _codeWriter.WriteLine("{", true);
                _codeWriter.AddIndentation();
                _codeWriter.WriteLine("if (obj==null)", true);
                _codeWriter.AddIndentation();
                _codeWriter.WriteLine("return false;", true);
                _codeWriter.SubtractIndentation();
                sb = new StringBuilder();
                sb.Append("return ");
                foreach (Member member in _members)
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
                _codeWriter.WriteLine(sb.ToString(), true);
                _codeWriter.SubtractIndentation();
                _codeWriter.WriteLine("}", true);
                _codeWriter.WriteLine("");

                _codeWriter.ProduceDescription("Get hashcode calculated from string representation of the instance", true);
                _codeWriter.WriteLine("public override int GetHashCode()", true);
                _codeWriter.WriteLine("{", true);
                _codeWriter.AddIndentation();
                _codeWriter.WriteLine("return this.ToString().GetHashCode();", true);
                _codeWriter.SubtractIndentation();
                _codeWriter.WriteLine("}", true);
                _codeWriter.WriteLine("");
            }
            if(_implementdeconstruct)
            {
                if (_members.Count > 1)
                {
                    _codeWriter.ProduceDescription("Deconstructs struct into properties", true);
                    _codeWriter.Write("public void Deconstruct(", true);
                    for (int i = 0; i < _members.Count; i++)
                    {
                        _codeWriter.Write("out ");
                        _codeWriter.Write(_members[i].Type);
                        if (_members[i].ValueIsNullable)
                            _codeWriter.Write("?");
                        _codeWriter.Write(" ");
                        _codeWriter.Write(_members[i].Name.ToLower());
                        if(i < _members.Count - 1)
                            _codeWriter.Write(", ");
                    }
                    _codeWriter.Write(")");
                    _codeWriter.WriteLine("{", true);
                    _codeWriter.AddIndentation();
                    foreach (var member in _members)
                    {
                        _codeWriter.Write(member.Name.ToLower(), true);
                        _codeWriter.Write(" = ");
                        _codeWriter.Write(member.Name);
                        _codeWriter.WriteLine(";");
                    }
                    _codeWriter.SubtractIndentation();
                    _codeWriter.WriteLine("}", true);
                    _codeWriter.WriteLine("");
                }
            }
            _codeWriter.WriteLine("#endregion", true);
            _codeWriter.WriteLine("");
        }

        /// <summary>
        /// Produces operators
        /// </summary>
        private void ProduceOperators()
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
        /// Produces constructor if necessary
        /// </summary>
        private void ProduceConstructor()
        {
            List<Member> members = new List<Member>();
            foreach (Member member in _members)
                if (_constructor || member.ReadOnly)
                    members.Add(member);
            if (members.Count != 0)
            {
                _codeWriter.WriteLine("#region Constructors", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceStructConstructor(_name, members);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Produces public members
        /// </summary>
        private void ProduceMembers()
        {
            _codeWriter.WriteLine("");
            _codeWriter.WriteLine("#region Public members", true);
            _codeWriter.WriteLine("");
            foreach (Member member in _members)
            {
                _codeWriter.Write("public ", true);
                if (member.ReadOnly)
                    _codeWriter.Write("readonly ");
                _codeWriter.Write(member.Type);
                if (member.ValueIsNullable)
                    _codeWriter.Write("?");
                _codeWriter.Write(" ");
                _codeWriter.Write(member.Name);
                _codeWriter.WriteLine(";");
            }
            _codeWriter.WriteLine("");
            _codeWriter.WriteLine("#endregion", true);
            _codeWriter.WriteLine("");
        }

        #endregion

    }
}
