using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2MusicList
{
    /// <summary>
    /// Represents enumeration of O2Jam difficulties.
    /// </summary>
    public enum Difficulty
    {
        /// <summary>
        /// Easy difficulty, also known as EX.
        /// </summary>
        Easy   = 0,

        /// <summary>
        /// Normal difficulty, also known as NX
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Hard difficulty, also known as HX
        /// </summary>
        Hard   = 2,

        /// <summary>
        /// Master difficulty, also known as MX.
        /// This often used to indicate that the difficulty is random however.
        /// </summary>
        Master = 3
    }
}
