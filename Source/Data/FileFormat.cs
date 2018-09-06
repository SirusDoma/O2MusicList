using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2MusicList
{
    /// <summary>
    /// Represents Client Version.
    /// </summary>
    public enum FileFormat
    {
        /// <summary>
        /// Represent v1.8 Client.
        /// </summary>
        Old = 0,

        /// <summary>
        /// Represents v3.10 or newer Client.
        /// </summary>
        New = 1
    }
}
