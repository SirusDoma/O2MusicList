using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace O2MusicList
{
    /// <summary>
    /// Represents header of OJN music file.
    /// </summary>
    public class OJN
    {
        /// <summary>
        /// Gets or sets the ID of Song.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Signature of OJN file.
        /// </summary>
        public byte[] Signature { get; set; }

        /// <summary>
        /// Gets or sets the Encoding Version of OJN file.
        /// </summary>
        public float EncodingVersion { get; set; }

        /// <summary>
        /// Gets or sets the Genre of the song.
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Gets or sets the tempo of the song.
        /// </summary>
        public float BPM { get; set; }

        /// <summary>
        /// Gets or sets level of easy difficulty of the song
        /// </summary>
        public short LevelEx { get; set; }

        /// <summary>
        /// Gets or sets level of normal difficulty of the song
        /// </summary>
        public short LevelNx { get; set; }

        /// <summary>
        /// Gets or sets level of hard difficulty of the song
        /// </summary>
        public short LevelHx { get; set; }

        /// <summary>
        /// Unused data.
        /// </summary>
        public short Padding { get; set; }

        /// <summary>
        /// Gets or sets the number of events for easy difficulty.
        /// </summary>
        public int EventCountEx { get; set; }

        /// <summary>
        /// Gets or sets the number of events for normal difficulty.
        /// </summary>
        public int EventCountNx { get; set; }

        /// <summary>
        /// Gets or sets the number of events for hard difficulty.
        /// </summary>
        public int EventCountHx { get; set; }

        /// <summary>
        /// Gets or sets the number of notes for easy difficulty.
        /// </summary>
        public int NoteCountEx { get; set; }

        /// <summary>
        /// Gets or sets the number of notes for normal difficulty.
        /// </summary>
        public int NoteCountNx { get; set; }

        /// <summary>
        /// Gets or sets the number of notes for hard difficulty.
        /// </summary>
        public int NoteCountHx { get; set; }

        /// <summary>
        /// Gets or sets the number of measures for easy difficulty.
        /// </summary>
        public int MeasureCountEx { get; set; }

        /// <summary>
        /// Gets or sets the number of measures for normal difficulty.
        /// </summary>
        public int MeasureCountNx { get; set; }

        /// <summary>
        /// Gets or sets the number of measures for hard difficulty.
        /// </summary>
        public int MeasureCountHx { get; set; }

        /// <summary>
        /// Gets or sets the number of event blocks for easy difficulty.
        /// </summary>
        public int BlockCountEx { get; set; }

        /// <summary>
        /// Gets or sets the number of event blocks for normal difficulty.
        /// </summary>
        public int BlockCountNx { get; set; }

        /// <summary>
        /// Gets or sets the number of event blocks for hard difficulty.
        /// </summary>
        public int BlockCountHx { get; set; }

        /// <summary>
        /// Gets or sets Encoding Version, for previous version of OJN format.
        /// </summary>
        public short OldEncodingVersion { get; set; }

        /// <summary>
        /// Gets or sets ID of the song, for previous version of OJN format.
        /// </summary>
        public short OldSongId { get; set; }

        /// <summary>
        /// Gets or sets Genre of the song, for previous version of genre.
        /// </summary>
        public byte[] OldGenre { get; set; }

        /// <summary>
        /// Gets or sets thumbnail size.
        /// </summary>
        public int ThumbnailSize { get; set; }

        /// <summary>
        /// Gets or sets OJN File Version.
        /// </summary>
        public int FileVersion { get; set; }

        /// <summary>
        /// Gets or sets title of the song.
        /// </summary>
        public byte[] Title { get; set; }

        /// <summary>
        /// Gets the title as string that encoded with specified <see cref="CharacterEncoding"/> encoding.
        /// </summary>
        public string TitleString => CharacterEncoding.GetString(Title.TakeWhile(c => c != 0).ToArray()).Trim('\0');

        /// <summary>
        /// Gets or sets artist of the song.
        /// </summary>
        public byte[] Artist { get; set; }

        /// <summary>
        /// Gets the artist as string that encoded with specified <see cref="CharacterEncoding"/> encoding.
        /// </summary>
        public string ArtistString => CharacterEncoding.GetString(Artist.TakeWhile(c => c != 0).ToArray()).Trim('\0');

        /// <summary>
        /// Gets or sets note arranger of the song.
        /// </summary>
        public byte[] Pattern { get; set; }

        /// <summary>
        /// Gets the note arranger as string that encoded with specified <see cref="CharacterEncoding"/> encoding.
        /// </summary>
        public string PatternString => CharacterEncoding.GetString(Pattern.TakeWhile(c => c != 0).ToArray()).Trim('\0');

        /// <summary>
        /// Gets or sets OJM filename of the song.
        /// </summary>
        public byte[] OJM { get; set; }

        /// <summary>
        /// Gets the OJM as string that encoded with specified <see cref="CharacterEncoding"/> encoding.
        /// </summary>
        public string OJMString => CharacterEncoding.GetString(OJM.TakeWhile(c => c != 0).ToArray()).Trim('\0');

        /// <summary>
        /// Gets or sets the size of cover image, in bytes.
        /// </summary>
        public int CoverSize { get; set; }

        /// <summary>
        /// Gets or sets the duration of the song for easy difficulty, in seconds.
        /// </summary>
        public int DurationEx { get; set; }

        /// <summary>
        /// Gets or sets the duration of the song for normal difficulty, in seconds.
        /// </summary>
        public int DurationNx { get; set; }

        /// <summary>
        /// Gets or sets the duration of the song for hard difficulty, in seconds.
        /// </summary>
        public int DurationHx { get; set; }

        /// <summary>
        /// Gets or sets the offset of event blocks for easy difficulty.
        /// </summary>
        public int BlockOffsetEx { get; set; }

        /// <summary>
        /// Gets or sets the offset of event blocks for normal difficulty.
        /// </summary>
        public int BlockOffsetNx { get; set; }

        /// <summary>
        /// Gets or sets the offset of event blocks for hard difficulty.
        /// </summary>
        public int BlockOffsetHx { get; set; }

        /// <summary>
        /// Gets or sets the offset of cover image.
        /// </summary>
        public int CoverOffset { get; set; }

        /// <summary>
        /// Gets or sets the key mode of the chart (either 3K, 5K or 7K).
        /// </summary>
        public byte KeyMode { get; set; } = 7;

        /// <summary>
        /// Gets or sets character encoding of the OJNHeader
        /// </summary>
        public Encoding CharacterEncoding { get; set; } = Encoding.GetEncoding(Preference.Instance.EncodingName);

        /// <summary>
        /// Gets or sets Thumbnail Data.
        /// </summary>
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the filaname of OJN header.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the header is encrypted.
        /// </summary>
        public bool Encrypted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OJN"/> class.
        /// </summary>
        public OJN()
        {
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>Id of the song.</returns>
        public override int GetHashCode()
        {
            return Id;
        }
    }

}
