using System.Collections.Generic;
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

            if (_produceempty)
            {
                _methodsImplementationWriter.AddIsEmptyMethod(_codeWriter, name, _operatorImplementationWriter.ImplementsEquality);
                _memberWriter.AddEmptyMember(name);
            }
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
            ProduceTypeContent();
            _codeWriter.SubtractIndentation();
            _codeWriter.WriteLine("}", true);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Produces constructor if necessary
        /// </summary>
        protected override void WriteConstructor()
        {
            List<Member> members = new List<Member>();
            foreach (Member member in _memberWriter.List)
                if ((_constructor || member.ReadOnly) && !member.Static)
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
        /// Writes a static constructor to textfile
        /// </summary>
        protected override void WriteStaticConstructor()
        {
            if (_produceempty)
            {
                _codeWriter.WriteLine("#region Static constructor", true);
                _codeWriter.WriteLine("");
                _codeWriter.ProduceStaticConstructor(_name, null, true);
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        /// <summary>
        /// Writes Private/protected members to textfile
        /// </summary>
        protected override void WritePublicMembers(bool staticmembers)
        {
            if (_memberWriter.HasPublicMembers(staticmembers))
            {
                _codeWriter.WriteLine("");
                _codeWriter.WriteLine("#region Public members", true);
                _codeWriter.WriteLine("");
                _memberWriter.WritePublicMembers(_codeWriter);
                _codeWriter.WriteLine("#endregion", true);
                _codeWriter.WriteLine("");
            }
        }

        #endregion

    }
}
