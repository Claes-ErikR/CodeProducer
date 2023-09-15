using System;
using System.Collections.Generic;
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

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        /// <param name="name"></param>
        public CodeGeneratorBase(string name)
        {
            _name = name;
            _operatorImplementationWriter = new OperatorImplementationWriter(_name);
            _methodsImplementationWriter = new MethodsImplementationWriter();
            _memberWriter = new MemberWriter();
        }

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        public CodeGeneratorBase()
            : this("")
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Frees resources
        /// </summary>
        public void Dispose()
        {
            _codeWriter.Dispose();
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Returns text for a not implemented exception
        /// </summary>
        protected void NotImplemented()
        {
            _codeWriter.WriteLine("throw new NotImplementedException();", true);
        }

        #endregion

    }
}
