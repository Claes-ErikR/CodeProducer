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
        protected OperatorImplementations _operatorimplementations;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        /// <param name="name"></param>
        public CodeGeneratorBase(string name)
        {
            _name = name;
            _operatorimplementations = new OperatorImplementations(_name);
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
        /// Produces description text
        /// </summary>
        /// <param name="description"></param>
        protected void ProduceDescription(string description)
        {
            _codeWriter.WriteLine("/// <summary>", true);
            _codeWriter.Write("/// ", true);
            _codeWriter.WriteLine(description);
            _codeWriter.WriteLine("/// </summary>", true);
        }

        /// <summary>
        /// Produces description text with parameters
        /// </summary>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        protected void ProduceDescription(string description, List<Method.Parameter> parameters)
        {
            ProduceDescription(description);
            if (parameters != null)
                foreach (Method.Parameter parameter in parameters)
                {
                    _codeWriter.Write("/// <param name=\"", true);
                    _codeWriter.Write(parameter.Name);
                    _codeWriter.WriteLine("\"></param>");
                }
        }

        /// <summary>
        /// Produces description text with parameters
        /// </summary>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        protected void ProduceDescription(string description, List<StructMember> parameters, bool returnparameter = false)
        {
            ProduceDescription(description);
            if (parameters != null)
                foreach (StructMember parameter in parameters)
                {
                    _codeWriter.Write("/// <param name=\"", true);
                    _codeWriter.Write(parameter.Name.ToLower());
                    _codeWriter.WriteLine("\"></param>");
                }
            if (returnparameter)
                _codeWriter.WriteLine("/// <returns></returns>", true);
        }

        /// <summary>
        /// Produces description text with return parameter
        /// </summary>
        /// <param name="description"></param>
        /// <param name="returnparameter"></param>
        protected void ProduceDescription(string description, bool returnparameter)
        {
            ProduceDescription(description);
            if (returnparameter)
                _codeWriter.WriteLine("/// <returns></returns>", true);
        }

        /// <summary>
        /// Produces description text with parameters and return parameter
        /// </summary>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        /// <param name="returnparameter"></param>
        protected void ProduceDescription(string description, List<Method.Parameter> parameters, bool returnparameter)
        {
            ProduceDescription(description, parameters);
            if (returnparameter)
                _codeWriter.WriteLine("/// <returns></returns>", true);
        }

        /// <summary>
        /// Returns text for a not implemented exception
        /// </summary>
        protected void NotImplemented()
        {
            _codeWriter.WriteLine("throw new NotImplementedException();", true);
        }

        #endregion

    }

    /// <summary>
    /// Class for tracking and producing operator code
    /// </summary>
    public class OperatorImplementations
    {

        #region Private/rotected members

        private string _classname;
        private List<string> _implementationclasses;
        private bool _implementsequality;
        private bool _implementscomparison;
        private bool _implementsarithmetic;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        /// <param name="classname"></param>
        public OperatorImplementations(string classname)
        {
            _classname = classname;
            _implementationclasses = new List<string>();
            _implementsequality = false;
            _implementscomparison = false;
            _implementsarithmetic = false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Writes code for the operators
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="indentspaces"></param>
        /// <param name="multdivoutputresultclass"></param>
        public void WriteOperators(CodeWriter writer, string indentspaces, string multdivoutputresultclass)
        {
            WriteArithmeticOperators(writer, indentspaces, multdivoutputresultclass);
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Writes code for arithmetic operators
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="indentspaces"></param>
        /// <param name="multdivoutputresultclass"></param>
        private void WriteArithmeticOperators(CodeWriter writer, string indentspaces, string multdivoutputresultclass)
        {
            foreach (string implementclass in _implementationclasses)
            {
                WriteArithmeticOperator(writer, indentspaces, multdivoutputresultclass, _classname, implementclass, "*", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, indentspaces, multdivoutputresultclass, implementclass, _classname, "*", true);
                WriteArithmeticOperator(writer, indentspaces, multdivoutputresultclass, _classname, implementclass, "/", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, indentspaces, multdivoutputresultclass, implementclass, _classname, "/", true);
                WriteArithmeticOperator(writer, indentspaces, _classname, _classname, implementclass, "+", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, indentspaces, _classname, implementclass, _classname, "+", true);
                WriteArithmeticOperator(writer, indentspaces, _classname, _classname, implementclass, "-", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, indentspaces, _classname, implementclass, _classname, "-", true);
                if (implementclass == _classname)
                    WriteArithmeticOperator(writer, indentspaces, _classname, _classname, null, "-", false);
            }
        }

        /// <summary>
        /// Writes code for an arithmetic operator
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="indentspaces"></param>
        /// <param name="returntype"></param>
        /// <param name="lhstype"></param>
        /// <param name="rhstype"></param>
        /// <param name="op"></param>
        /// <param name="invert"></param>
        private void WriteArithmeticOperator(CodeWriter writer, string indentspaces, string returntype, string lhstype, string rhstype, string op, bool invert)
        {
            writer.Write(indentspaces);
            writer.WriteLine("/// <summary>");
            writer.Write(indentspaces);
            writer.Write("/// ");
            if (op == "*")
                writer.Write("Multiplies a ");
            else if (op == "/")
                writer.Write("Divides a ");
            else if (op == "+")
                writer.Write("Adds a ");
            else if (op == "-" && rhstype != null)
                writer.Write("Subtracts a ");
            else if (op == "-")
                writer.WriteLine("Unary negative of ");
            if (rhstype != null)
            {
                writer.Write(lhstype);
                if (op == "*" || op == "/")
                    writer.Write(" with a ");
                else if (op == "+")
                    writer.Write(" to a ");
                else if (op == "-")
                    writer.Write(" from a ");
                writer.WriteLine(rhstype);
                if (lhstype != returntype && rhstype != returntype)
                {
                    writer.Write(" to get a ");
                    writer.WriteLine(returntype);
                }
            }
            writer.Write(indentspaces);
            writer.WriteLine("/// </summary>");
            writer.Write(indentspaces);
            writer.WriteLine("/// <param name=\"lhs\"></param>");
            if (rhstype != null)
            {
                writer.Write(indentspaces);
                writer.WriteLine("/// <param name=\"rhs\"></param>");
            }
            writer.Write(indentspaces);
            writer.WriteLine("/// <returns></returns>");
            writer.Write(indentspaces);
            writer.Write("public static ");
            writer.Write(returntype);
            writer.Write(" operator ");
            writer.Write(op);
            writer.Write("(");
            writer.Write(lhstype);
            if (rhstype == null)
                writer.WriteLine(" lhs)");
            else
            {
                writer.Write(" lhs, ");
                writer.Write(rhstype);
                writer.WriteLine(" rhs)");
            }
            writer.Write(indentspaces);
            writer.WriteLine("{");
            writer.Write(indentspaces);
            if(op=="-" && rhstype!=null)
                writer.WriteLine("    return lhs + (-rhs)");
            else if (invert && rhstype != null && op !="/")
            {
                writer.Write("    return rhs ");
                writer.Write(op);
                writer.WriteLine(" lhs;");
            }
            else
                writer.WriteLine("    throw new NotImplementedException();");
            writer.Write(indentspaces);
            writer.WriteLine("}");
            writer.WriteLine("");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns list of classes to implement operators against
        /// </summary>
        public List<string> ImplementationClasses
        {
            get
            {
                return _implementationclasses;
            }
        }

        /// <summary>
        /// Returns or sets if equality comparison is to be implemented
        /// </summary>
        public bool ImplementsEquality
        {
            get
            {
                return _implementsequality;
            }
            set
            {
                _implementsequality = value;
            }
        }

        /// <summary>
        /// Returns or sets if comparison is to be implemented
        /// </summary>
        public bool ImplementsComparison
        {
            get
            {
                return _implementscomparison;
            }
            set
            {
                _implementscomparison = value;
            }
        }

        /// <summary>
        /// Returns or sets if arithmetic operators is to be implemented
        /// </summary>
        public bool ImplementsArithmetic
        {
            get
            {
                return _implementsarithmetic;
            }
            set
            {
                _implementsarithmetic = value;
            }
        }

        #endregion

    }
}
