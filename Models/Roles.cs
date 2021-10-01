using System;

namespace Models
{
    [Flags]
    public enum Roles
    {
        Read = 1 << 0,
        Write = 1 << 1,
        Delete = 1 << 2
    }
}