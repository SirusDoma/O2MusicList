using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace O2MusicList
{
    public static class OJNListEncoder
    {
        public static byte[] Encode(OJNList data, FileFormat format, bool compactBuild = true, int uniformKeyMode = 0)
        {
            var headers = data.GetHeaders();
            using (var mstream = new MemoryStream())
            using (var writer = new BinaryWriter(mstream))
            {
                writer.Write(headers.Length);
                foreach (var header in headers)
                {
                    writer.Write(OJNEncoder.Encode(header, true));
                }

                if (format == FileFormat.New)
                {
                    bool compact = Preference.Instance.IsCompactBuild;

                    // Section #1 - Optional
                    if (compact)
                    {
                        writer.Write(0); // Song Count # 1
                    }
                    else
                    {
                        writer.Write(headers.Length);
                        foreach (var header in headers)
                        {
                            writer.Write(header.Id);
                            writer.Write(0);
                            writer.Write(2);
                            writer.Write(0);
                        }
                    }

                    // Section #2 - Mandatory
                    writer.Write(headers.Length);
                    foreach (var header in headers)
                    {
                        writer.Write(header.Id);
                        writer.Write(1);
                        writer.Write(0);
                        writer.Write(0);
                        writer.Write(0);
                    }

                    // Section #3 and #4 - Optional
                    if (compact)
                    {
                        writer.Write(0); // Song Count # 3
                        writer.Write(0); // Song Count # 4
                    }
                    else
                    {
                        // Section #3
                        writer.Write(headers.Length);
                        foreach (var header in headers)
                        {
                            writer.Write(header.Id);
                            writer.Write(1000);
                            writer.Write(0);
                            writer.Write(2010252407);
                        }

                        // Section #4
                        writer.Write(headers.Length);
                        foreach (var header in headers)
                        {
                            // Either, one of these must be 1 and 0
                            writer.Write(header.Id);
                            writer.Write(0); // 1
                            writer.Write(1); // 0
                        }
                    }

                    // Section #5 - Mandatory
                    writer.Write(headers.Length);
                    foreach (var header in headers)
                    {
                        writer.Write(header.Id);
                        writer.Write(0); // Values either 0, 3, 4, 5
                    }

                    // Section #6 - Optional
                    if (compact)
                    {
                        writer.Write(0); // Song Count #6
                    }
                    else
                    {
                        // Section #6
                        writer.Write(headers.Length);
                        foreach (var header in headers)
                        {
                            writer.Write(header.Id);
                            writer.Write(50);
                            writer.Write(0);
                        }
                    }

                    // Section #7 - Optional
                    // I don't know for sure how this part look like
                    // It's always empty in solista and official
                    writer.Write(0); // Song Count #7

                    // Section #8
                    writer.Write(headers.Length);
                    foreach (var header in headers)
                    {
                        writer.Write(header.Id);
                        writer.Write(uniformKeyMode > 0 ? (byte)uniformKeyMode : header.KeyMode); // Keymode
                        writer.Write((short)17396); // ??????
                        writer.Write((byte)0); // padding?
                    }

                    // Section #9 - Optional
                    // For unknown reason, this field does not need Song Count padding when not specified
                    if (!compact)
                    {
                        writer.Write(headers.Length);
                        foreach (var header in headers)
                        {
                            writer.Write(header.Id);
                            writer.Write(Encoding.UTF8.GetBytes(Preference.Instance.PublishDate.ToString("yyyy-MM-dd"))); // "2011-08-06"
                            writer.Write((short)30464);
                            writer.Write(1242928);
                            writer.Write(4474939);
                            writer.Write(48401);
                        }
                    }
                }

                return mstream.ToArray();
            }
        }
    }
}
