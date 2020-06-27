using System;
using System.Windows;

namespace Optimator
{
    public class VersionException : Exception
    {
        public VersionException()
        {
            MessageBox.Show("The file version is not compatible.");
        }

        public VersionException(string message)
            : base(message)
        {
            MessageBox.Show("The file version is not compatible.");
        }

        public VersionException(string message, Exception inner)
            : base(message, inner)
        {
            MessageBox.Show("The file version is not compatible.");
        }
    }
}
