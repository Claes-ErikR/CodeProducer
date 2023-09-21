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
        private bool _constructor;
        private bool _produceempty;

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
        public StructProducer(string name, string description, string visibility, List<Member> members, bool constructor, bool equalitycomparison, bool produceempty, string filename, List<string> operatorclasses, bool implementdeconstruct)
            : base(name, DefinitionType.Struct)
        {
            _codeWriter = new CodeWriter(filename, 4);
            _description = description;
            _visibility = visibility;
            _memberWriter.AddRange(members);
            _constructor = constructor;
            _operatorImplementationWriter.ImplementsEquality = equalitycomparison;
            _produceempty = produceempty;
            _operatorImplementationWriter.ImplementationClasses.AddRange(operatorclasses);
            if (_operatorImplementationWriter.ImplementationClasses.Count > 0)
                _operatorImplementationWriter.ImplementsArithmetic = true;

            _methodsImplementationWriter.EnsureToStringImplemented(_codeWriter, _memberWriter.List);
            if (_operatorImplementationWriter.ImplementsEquality)
                _methodsImplementationWriter.AddEqualityComparisonMethods(_codeWriter, _name, _memberWriter.List);
            if (implementdeconstruct)
                _methodsImplementationWriter.AddDeconstructMethod(_codeWriter, _memberWriter.List);
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
            WriteMethods(true, false);
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
            foreach (Member member in _memberWriter.List)
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
            _memberWriter.WritePublicMembers(_codeWriter);
            _codeWriter.WriteLine("#endregion", true);
            _codeWriter.WriteLine("");
        }

        #endregion

    }
}
