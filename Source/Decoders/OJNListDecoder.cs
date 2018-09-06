using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O2MusicList
{
    public static class OJNListDecoder
    {
        private const string KoreanEncoding  = "ks_c_5601-1987";
        private const string ChineseEncoding = "big5";

        public static OJNList Decode(String filename)
        {
            return Decode(File.Open(filename, FileMode.Open), false);
        }

        public static OJNList Decode(Stream stream, bool keepOpen = false)
        {
            var headers  = new OJNList();
            byte[] inputData = new byte[0];

            using (var reader = new BinaryReader(stream, Encoding.Unicode, keepOpen))
            {
                // Retrieve the number of songs in OJNList
                stream.Seek(0, SeekOrigin.Begin);
                int songCount = reader.ReadInt32();

                // Detect version of OJNList
                headers.Version = stream.Length > 4 + (songCount * 300) ? FileFormat.New : FileFormat.Old;
                var charset = headers.Version == FileFormat.New ? KoreanEncoding : ChineseEncoding;

                // Retrieve all OJN Headers
                for (int i = 0; i < songCount; i++)
                {
                    headers.Add(OJNDecoder.Decode(reader.ReadBytes(300), Encoding.GetEncoding(charset)));
                }

                // Parse the extra payload of new OJNList
                if (headers.Version == FileFormat.New)
                {
                    // Section #1 - Optional
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int val1 = reader.ReadInt32();
                        int val2 = reader.ReadInt32();
                        int val3 = reader.ReadInt32();
                    }

                    // Section #2 - Mandatory
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int state = reader.ReadInt32(); // 01
                        int val1 = reader.ReadInt32();
                        int val2 = reader.ReadInt32();
                        int val3 = reader.ReadInt32();
                    }

                    // Section #3 - Optional
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int val1 = reader.ReadInt32();  // 1000
                        int val2 = reader.ReadInt32();  // 0
                        int val3 = reader.ReadInt32();  // 2010252407
                    }

                    // Section #4 - Optional
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int val1 = reader.ReadInt32();  // 0 if val2 1, otherwise 1
                        int val2 = reader.ReadInt32();  // 1 if val1 0, otherwise 0
                    }

                    // Section #5 - Mandatory
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int val1 = reader.ReadInt32();  // Values either 0, 3, 4, 5
                    }

                    // Section #6 - Optional
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        int val1 = reader.ReadInt32();  // 50
                        int val2 = reader.ReadInt32();  // 0
                    }

                    // Section #7 - Optional (???? - not clue yet)
                    songCount = reader.ReadInt32();

                    // Section #8 - Mandatory (KeyMode
                    songCount = reader.ReadInt32();
                    for (int i = 0; i < songCount; i++)
                    {
                        int id = reader.ReadInt32();
                        if (id > 0 && headers.Contains(id))
                        {
                            var header = headers[id];
                            header.KeyMode = reader.ReadByte(); // either 3K, 5K or 7K
                            reader.ReadInt16(); // 17396
                            reader.ReadByte(); // padding?

                        }
                        else
                        {
                            reader.ReadInt32(); // skip
                        }
                    }
                }

                return headers;
            }
        }
    }
}
