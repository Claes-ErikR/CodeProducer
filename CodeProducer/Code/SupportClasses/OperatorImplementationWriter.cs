using System.Collections.Generic;
using Utte.Code.Code.Helpers;

namespace Utte.Code.Code.SupportClasses
{

    /// <summary>
    /// Class for tracking and producing operator code
    /// </summary>
    public class OperatorImplementationWriter
    {
        #region Private/rotected members

        private string _classname;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        /// <param name="classname"></param>
        public OperatorImplementationWriter(string classname)
        {
            _classname = classname;
            ImplementationClasses = new List<string>();
            ImplementsEquality = false;
            ImplementsComparison = false;
            ImplementsArithmetic = false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Writes code for the operators
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="multdivoutputresultclass"></param>
        public void WriteOperators(CodeWriter writer, string multdivoutputresultclass)
        {
            if (ImplementsArithmetic)
                WriteArithmeticOperators(writer, multdivoutputresultclass);
            if (ImplementsEquality)
                ImplementsEqualityOperators(writer);
            if (ImplementsComparison)
                ImplementsComparisonOperators(writer);
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Writes code for comparison operators
        /// </summary>
        /// <param name="writer"></param>
        private void ImplementsComparisonOperators(CodeWriter writer)
        {
            writer.ProduceDescription("Check if lhs is smaller than rhs");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator <(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.WriteLine("if(lhs == null)", true);
            writer.AddIndentation();
            writer.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
            writer.SubtractIndentation();
            writer.WriteLine("return lhs.CompareTo(rhs)<0;", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");

            writer.ProduceDescription("Check if lhs is smaller than or equal to rhs");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator <=(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.WriteLine("if(lhs == null)", true);
            writer.AddIndentation();
            writer.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
            writer.SubtractIndentation();
            writer.WriteLine("return lhs.CompareTo(rhs)<=0;", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");

            writer.ProduceDescription("Check if lhs is greater than rhs");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator >(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.WriteLine("if(lhs == null)", true);
            writer.AddIndentation();
            writer.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
            writer.SubtractIndentation();
            writer.WriteLine("return lhs.CompareTo(rhs)>0;", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");

            writer.ProduceDescription("Check if lhs is greater than or equal to rhs");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator >=(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.WriteLine("if(lhs == null)", true);
            writer.AddIndentation();
            writer.WriteLine("throw new ArgumentNullException(\"null value in sort comparison\");", true);
            writer.SubtractIndentation();
            writer.WriteLine("return lhs.CompareTo(rhs)>=0;", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");
        }

        /// <summary>
        /// Writes code for equality operators
        /// </summary>
        /// <param name="writer"></param>
        private void ImplementsEqualityOperators(CodeWriter writer)
        {
            writer.ProduceDescription("Compares lhs and rhs for equality");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator ==(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.Write("return ", true);
            writer.Write(_classname);
            writer.WriteLine(".Equals(lhs,rhs);");
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");
            writer.ProduceDescription("Compares lhs and rhs for inequality");
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static bool operator !=(", true);
            writer.Write(_classname);
            writer.Write(" lhs, ");
            writer.Write(_classname);
            writer.WriteLine(" rhs)");
            writer.WriteLine("{", true);
            writer.AddIndentation();
            writer.WriteLine("return !(lhs == rhs);", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");
        }

        /// <summary>
        /// Writes code for arithmetic operators
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="multdivoutputresultclass"></param>
        private void WriteArithmeticOperators(CodeWriter writer, string multdivoutputresultclass)
        {
            foreach (string implementclass in ImplementationClasses)
            {
                WriteArithmeticOperator(writer, multdivoutputresultclass, _classname, implementclass, "*", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, multdivoutputresultclass, implementclass, _classname, "*", true);
                WriteArithmeticOperator(writer, multdivoutputresultclass, _classname, implementclass, "/", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, multdivoutputresultclass, implementclass, _classname, "/", true);
                WriteArithmeticOperator(writer, _classname, _classname, implementclass, "+", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, _classname, implementclass, _classname, "+", true);
                WriteArithmeticOperator(writer, _classname, _classname, implementclass, "-", false);
                if (_classname != implementclass)
                    WriteArithmeticOperator(writer, _classname, implementclass, _classname, "-", true);
                if (implementclass == _classname)
                    WriteArithmeticOperator(writer, _classname, _classname, null, "-", false);
            }
        }

        /// <summary>
        /// Writes code for an arithmetic operator
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="returntype"></param>
        /// <param name="lhstype"></param>
        /// <param name="rhstype"></param>
        /// <param name="op"></param>
        /// <param name="invert"></param>
        private void WriteArithmeticOperator(CodeWriter writer, string returntype, string lhstype, string rhstype, string op, bool invert)
        {
            writer.WriteLine("/// <summary>", true);
            writer.Write("/// ", true);
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
            writer.WriteLine("/// </summary>", true);
            writer.WriteLine("/// <param name=\"lhs\"></param>", true);
            if (rhstype != null)
            {
                writer.WriteLine("/// <param name=\"rhs\"></param>", true);
            }
            writer.WriteLine("/// <returns></returns>", true);
            writer.Write("public static ", true);
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
            writer.WriteLine("{", true);
            writer.AddIndentation();
            if (op == "-" && rhstype != null)
                writer.WriteLine("return lhs + (-rhs)", true);
            else if (invert && rhstype != null && op != "/")
            {
                writer.Write("return rhs ", true);
                writer.Write(op);
                writer.WriteLine(" lhs;");
            }
            else
                writer.WriteLine("throw new NotImplementedException();", true);
            writer.SubtractIndentation();
            writer.WriteLine("}", true);
            writer.WriteLine("");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns list of classes to implement operators against
        /// </summary>
        public List<string> ImplementationClasses { get; }

        /// <summary>
        /// Returns or sets if equality comparison is to be implemented
        /// </summary>
        public bool ImplementsEquality { get; set; }

        /// <summary>
        /// Returns or sets if comparison is to be implemented
        /// </summary>
        public bool ImplementsComparison { get; set; }

        /// <summary>
        /// Returns or sets if arithmetic operators is to be implemented
        /// </summary>
        public bool ImplementsArithmetic { get; set; }

        /// <summary>
        /// Returns true if any operator is to be implemented
        /// </summary>
        public bool ImplementsAny
        {
            get
            {
                return ImplementsEquality || ImplementsComparison || ImplementsArithmetic;
            }
        }

        #endregion

    }
}