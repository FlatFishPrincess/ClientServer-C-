using System;

namespace CustomInterfaces
{
    // The pointy behavior as a read-only property.
    public interface IPointy
    {
        ConsoleColor Color { get; set;  }
        // A read-write property in an interface would look like:
        // retType PropName { get; set; }
        //
        // while a write-only property in an interface would be:
        // retType PropName { set; }

        byte Points { get; }
        string Description { get; set; }
    }
}
