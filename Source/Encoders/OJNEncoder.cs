using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O2MusicList
{
    public static class OJNEncoder
    {
        public static byte[] Encode(OJN header, bool headerOnly = false)
        {
            byte[] data = new byte[300];
            if (File.Exists(header.Source) && !headerOnly)
            {
                data = File.ReadAllBytes(header.Source);
            }

            using (var mstream = new MemoryStream(data))
            using (var writer = new BinaryWriter(mstream))
            {
                writer.Write(header.Id);
                writer.Write(header.Signature);
                writer.Write(header.EncodingVersion);
                writer.Write((int)header.Genre);
                writer.Write(header.BPM);
                writer.Write(header.LevelEx);
                writer.Write(header.LevelNx); ;
                writer.Write(header.LevelHx);
                writer.Write(header.Padding);
                writer.Write(header.EventCountEx);
                writer.Write(header.EventCountNx);
                writer.Write(header.EventCountHx);
                writer.Write(header.NoteCountEx);
                writer.Write(header.NoteCountNx);
                writer.Write(header.NoteCountHx);
                writer.Write(header.MeasureCountEx);
                writer.Write(header.MeasureCountNx);
                writer.Write(header.MeasureCountHx);
                writer.Write(header.BlockCountEx);
                writer.Write(header.BlockCountNx);
                writer.Write(header.BlockCountHx);
                writer.Write(header.OldEncodingVersion);
                writer.Write(header.OldSongId);
                writer.Write(header.OldGenre);
                writer.Write(header.ThumbnailSize);
                writer.Write(header.FileVersion);
                writer.Write(header.Title);
                writer.Write(header.Artist);
                writer.Write(header.Pattern);
                writer.Write(header.OJM);
                writer.Write(header.CoverSize);
                writer.Write(header.DurationEx);
                writer.Write(header.DurationNx);
                writer.Write(header.DurationHx);
                writer.Write(header.BlockOffsetEx);
                writer.Write(header.BlockOffsetNx);
                writer.Write(header.BlockOffsetHx);
                writer.Write(header.CoverOffset);

                // Don't encrypt the header on header only mode
                if (!headerOnly && header.Encrypted)
                {
                    return Encrypt(mstream);
                }

                return mstream.ToArray();
            }
        }

        public static byte[] Encrypt(Stream ojnStream)
        {
            using (var stream = new MemoryStream())
            using (var reader = new BinaryReader(ojnStream, Encoding.Unicode, true))
            using (var writer = new BinaryWriter(stream))
            {
                ojnStream.Seek(0, SeekOrigin.Begin);
                byte[] input = reader.ReadBytes((int)ojnStream.Length);

                stream.Seek(0, SeekOrigin.Begin);
                writer.Write(Encoding.UTF8.GetBytes("new"));

                var randomizer  = new Random();
                byte blockSize  = (byte)randomizer.Next(5, 11);
                byte mainKey    = (byte)randomizer.Next(1, byte.MaxValue);
                byte midKey     = (byte)randomizer.Next(1, byte.MaxValue);
                byte initialKey = (byte)randomizer.Next(1, byte.MaxValue);

                writer.Write(blockSize);
                writer.Write(mainKey);
                writer.Write(midKey);
                writer.Write(initialKey);

                var encryptKeys = Enumerable.Repeat(mainKey, blockSize).ToArray();
                encryptKeys[0] = initialKey;
                encryptKeys[(int)Math.Floor(blockSize / 2f)] = midKey;

                byte[] output = new byte[input.Length];
                for (int i = 0; i < output.Length; i += blockSize)
                {
                    for (int j = 0; j < blockSize; j++)
                    {
                        int offset = i + j;
                        if (offset >= output.Length)
                        {
                            break;
                        }

                        output[output.Length - (offset + 1)] = (byte)(input[offset] ^ encryptKeys[j]);
                    }
                }

                writer.Write(output);
                return stream.ToArray();
            }
        }
    }
}
