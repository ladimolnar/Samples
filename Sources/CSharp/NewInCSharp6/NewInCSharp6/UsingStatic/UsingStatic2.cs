using System.IO;

// Simplify referencing enum members.
// In this case simplify referencing members of FileOptions enum.
using static System.IO.FileOptions;

namespace NewInCSharp6.UsingStatic
{
    public class UsingStatic2
    {
        public void DoSomeIo(FileOptions fileOptions)
        {
            switch (fileOptions)
            {
                case SequentialScan:
                    // ...
                    break;
                case Asynchronous:
                    // ...
                    break;
                case DeleteOnClose:
                    // ...
                    break;
            }
        }
    }
}
