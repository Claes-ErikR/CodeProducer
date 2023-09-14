using System;
using System.IO;

namespace Utte.Code.Code.SupportClasses
{
    public class CodeWriter : IDisposable
    {

        private int _indentation;
        private StreamWriter _streamwriter;

        /// <summary>
        /// Creates streamwriter with indentspecification
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="indentSpacesPerIndentation"></param>
        public CodeWriter(string fileName, int indentSpacesPerIndentation)
        {
            _streamwriter = new StreamWriter(fileName);
            IndentSpacesPerIndentation = indentSpacesPerIndentation;
        }

        /// <summary>
        /// Writes text to file
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Write(text, false);
        }

        /// <summary>
        /// Writes text to file starting with indentation
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indent"></param>
        public void Write(string text, bool indent)
        {
            if (indent)
                for (int i = 0; i < IndentSpaces; i++)
                    _streamwriter.Write(" ");
            _streamwriter.Write(text);
        }

        /// <summary>
        /// Writes text to file and goes to next line
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            WriteLine(text, false);
        }

        /// <summary>
        /// Writes text to file starting with indentation and goes to next line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indent"></param>
        public void WriteLine(string text, bool indent)
        {
            if (indent)
                for (int i = 0; i < IndentSpaces; i++)
                    _streamwriter.Write(" ");
            _streamwriter.WriteLine(text);
        }

        /// <summary>
        /// Adds a level of indentation
        /// </summary>
        /// <returns></returns>
        public int AddIndentation()
        {
            _indentation++;
            return _indentation;
        }

        /// <summary>
        /// Subtracts a level of indentation but cannot become negative
        /// </summary>
        /// <returns></returns>
        public int SubtractIndentation()
        {
            if(_indentation > 0)
                _indentation--;
            return _indentation;
        }

        /// <summary>
        /// Dispose the streamwriter
        /// </summary>
        public void Dispose()
        {
            try
            {
                _streamwriter.Close();
            }
            catch
            {
            }
            _streamwriter.Dispose();
        }

        /// <summary>
        /// Returns the number of spaces indented
        /// </summary>
        public int IndentSpaces
        { 
            get 
            { 
                return _indentation * IndentSpacesPerIndentation; 
            } 
        }

        /// <summary>
        /// Returns the number of spaces indented per indentation level
        /// </summary>
        public int IndentSpacesPerIndentation { get; }

        /// <summary>
        /// Gets or sets the indentation level. Cannot be set to a negative number
        /// </summary>
        public int Indentation 
        {
            get 
            { 
                return _indentation; 
            }
            set 
            { 
                _indentation = Math.Max(value, 0); 
            }
        }
    }
}
