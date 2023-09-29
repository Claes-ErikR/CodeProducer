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
        /// <param name="filename"></param>
        public StructProducer(string name, string description, string visibility, List<Member> members, bool constructor, string filename)
            : base(name, DefinitionType.Struct)
        {
            _codeWriter = new CodeWriter(filename, 4);
            _description = description;
            _visibility = visibility;
            _memberWriter.AddRange(members);
            _constructor = constructor;
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
            _codeWriter.ProduceStructDeclaration(_name, _visibility, _interfaces);
            _codeWriter.WriteLine("{", true);
            _codeWriter.AddIndentation();
            _codeWriter.WriteLine("");
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
                _codeWriter.ProduceRegionStart("Constructors");
                _codeWriter.ProduceStructConstructor(_name, members);
                _codeWriter.ProduceRegionEnd();
            }
        }

        #endregion

    }
}
