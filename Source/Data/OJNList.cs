using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2MusicList
{
    /// <summary>
    /// Represents a list of <see cref="OJN"/> headers.
    /// </summary>
    public class OJNList
    {
        private Dictionary<int, OJN> headers;

        /// <summary>
        /// Gets or sets client version of OJNList.
        /// </summary>
        public FileFormat Version { get; set; }

        /// <summary>
        /// Gets the value indicating whether the collections has been modified prior <see cref="GetHeaders"/> calls.
        /// </summary>
        public bool Modified { get; private set; } = false;

        /// <summary>
        /// Gets the number of <see cref="OJN"/> headers.
        /// </summary>
        public int Count => headers.Count;

        /// <summary>
        /// Gets the <see cref="OJN"/> header that match with specified ID.
        /// </summary>
        /// <param name="id"><see cref="OJN"/> ID to retrieve.</param>
        /// <returns><see cref="OJN"/> header that match with specified ID.</returns>
        public OJN this[int id] => headers[id];
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OJNList"/> class.
        /// </summary>
        public OJNList()
        {
            headers = new Dictionary<int, OJN>();
        }

        /// <summary>
        /// Add <see cref="OJN"/> header to the list.
        /// </summary>
        /// <param name="header"><see cref="OJN"/> header to add into the list.</param>
        /// <returns><c>true</c> if the header successfully added; otherwise <c>false</c>.</returns>
        public bool Add(OJN header)
        {
            if (!headers.ContainsKey(header.Id))
            {
                headers.Add(header.Id, header);
                return Modified = true;
            }

            return false;
        }

        /// <summary>
        /// Remove <see cref="OJN"/> header from the list.
        /// </summary>
        /// <param name="header"><see cref="OJN"/> header to remove from the list.</param>
        /// <returns><c>true</c> if the header successfully removed; otherwise <c>false</c>.</returns>
        public bool Remove(OJN header)
        {
            return Modified = headers.Remove(header.Id);
        }

        /// <summary>
        /// Remove <see cref="OJN"/> header that match with specified id from the list.
        /// </summary>
        /// <param name="id">ID of <see cref="OJN"/> header to remove from the list.</param>
        /// <returns><c>true</c> if the header successfully removed; otherwise <c>false</c>.</returns>
        public bool Remove(int id)
        {
            return Modified = headers.Remove(id);
        }

        /// <summary>
        /// Update <see cref="OJN"/> header that match with specified id from the list with specified header value.
        /// </summary>
        /// <param name="id">ID of <see cref="OJN"/> header to update.</param>
        /// <param name="header"><see cref="OJN"/> header that hold new value.</param>
        /// <returns><c>true</c> if the header successfully updated; otherwise <c>false</c>.</returns>
        public bool Update(int id, OJN header)
        {
            if (headers.ContainsKey(header.Id))
            {
                headers[id] = header;
                return Modified = true;
            }

            return false;
        }

        /// <summary>
        /// Get a value indicating whether the OJNList has <see cref="OJN"/> header with specified id.
        /// </summary>
        /// <param name="id">Id to check.</param>
        /// <returns><c>true</c> if OJNList contains the header; otherwise <c>false</c>.</returns>
        public bool Contains(int id)
        {
            return headers.ContainsKey(id);
        }

        /// <summary>
        /// Get an array of <see cref="OJN"/> header of current instance of the <see cref="OJNList"/> object.
        /// </summary>
        /// <returns>An array of <see cref="OJN"/> header.</returns>
        public OJN[] GetHeaders()
        {
            Modified = false;
            return headers.Values.ToArray();
        }

        /// <summary>
        /// Get an array of <see cref="OJN"/> header of current instance of the <see cref="OJNList"/> object with predicate filter.
        /// </summary>
        /// <param name="predicate">A predicate filter to find specific header.</param>
        /// <returns>An array of <see cref="OJN"/> header.</returns>
        public OJN[] GetHeaders(Func<OJN, bool> predicate)
        {
            Modified = false;
            return headers.Values.Where(predicate).ToArray();
        }

        public int Optimize()
        {
            int count = headers.Count;
            var data  = headers.Values.GroupBy(h => h.TitleString).Select(h => h.First()).ToArray();

            headers.Clear();
            foreach (var header in data)
            {
                headers.Add(header.Id, header);
            }

            return count - headers.Count;
        }

        public void SetCharacterEncoding(Encoding encoding)
        {
            foreach (var header in headers.Values)
            {
                header.CharacterEncoding = encoding;
            }
        }
    }
}
