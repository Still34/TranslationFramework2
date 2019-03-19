﻿using System;
using System.Collections.Generic;

namespace TFGame.TrailsSky
{
    public class Encoding : System.Text.Encoding
    {
        private readonly System.Text.Encoding defaultEncoding = GetEncoding(932);

        private List<Tuple<string, string>> DecodingReplacements;
        private List<Tuple<string, string>> EncodingReplacements;

        public Encoding() : base()
        {
            DecodingReplacements = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("\u0001", "\\n"),
                new Tuple<string, string>("\u0002", "<0x02>"),
                new Tuple<string, string>("\u0003", "<0x03>"),
                new Tuple<string, string>("\u0004", "<0x04>"),
                new Tuple<string, string>("\u0005", "<0x05>"),
                new Tuple<string, string>("\u0006", "<0x06>"),
                new Tuple<string, string>("\u0007", "<0x07>"),
                new Tuple<string, string>("\u0008", "<0x08>"),
                new Tuple<string, string>("\u0009", "<0x09>"),
                new Tuple<string, string>("\u000A", "<0x0A>"),
                new Tuple<string, string>("\u000B", "<0x0B>"),
                new Tuple<string, string>("\u000C", "<0x0C>"),
                new Tuple<string, string>("\u000D", "<0x0D>"),
                new Tuple<string, string>("\u000E", "<0x0E>"),
                new Tuple<string, string>("\u000F", "<0x0F>"),
                new Tuple<string, string>("\u0010", "<0x10>"),
                new Tuple<string, string>("\u0011", "<0x11>"),
                new Tuple<string, string>("\u0012", "<0x12>"),
                new Tuple<string, string>("\u0013", "<0x13>"),
                new Tuple<string, string>("\u0014", "<0x14>"),
                new Tuple<string, string>("\u0015", "<0x15>"),
                new Tuple<string, string>("\u0016", "<0x16>"),
                new Tuple<string, string>("\u0017", "<0x17>"),
                new Tuple<string, string>("\u0018", "<0x18>"),
                new Tuple<string, string>("\u0019", "<0x19>"),
                new Tuple<string, string>("\u001A", "<0x1A>"),
                new Tuple<string, string>("\u001B", "<0x1B>"),
                new Tuple<string, string>("\u001C", "<0x1C>"),
                new Tuple<string, string>("\u001D", "<0x1D>"),
                new Tuple<string, string>("\u001E", "<0x1E>"),
                new Tuple<string, string>("\u001F", "<0x1F>"),
            };

            EncodingReplacements = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("\\n", "\u0001"),
                new Tuple<string, string>("<0x02>", "\u0002"),
                new Tuple<string, string>("<0x03>", "\u0003"),
                new Tuple<string, string>("<0x04>", "\u0004"),
                new Tuple<string, string>("<0x05>", "\u0005"),
                new Tuple<string, string>("<0x06>", "\u0006"),
                new Tuple<string, string>("<0x07>", "\u0007"),
                new Tuple<string, string>("<0x08>", "\u0008"),
                new Tuple<string, string>("<0x09>", "\u0009"),
                new Tuple<string, string>("<0x0A>", "\u000A"),
                new Tuple<string, string>("<0x0B>", "\u000B"),
                new Tuple<string, string>("<0x0C>", "\u000C"),
                new Tuple<string, string>("<0x0D>", "\u000D"),
                new Tuple<string, string>("<0x0E>", "\u000E"),
                new Tuple<string, string>("<0x0F>", "\u000F"),
                new Tuple<string, string>("<0x10>", "\u0010"),
                new Tuple<string, string>("<0x11>", "\u0011"),
                new Tuple<string, string>("<0x12>", "\u0012"),
                new Tuple<string, string>("<0x13>", "\u0013"),
                new Tuple<string, string>("<0x14>", "\u0014"),
                new Tuple<string, string>("<0x15>", "\u0015"),
                new Tuple<string, string>("<0x16>", "\u0016"),
                new Tuple<string, string>("<0x17>", "\u0017"),
                new Tuple<string, string>("<0x18>", "\u0018"),
                new Tuple<string, string>("<0x19>", "\u0019"),
                new Tuple<string, string>("<0x1A>", "\u001A"),
                new Tuple<string, string>("<0x1B>", "\u001B"),
                new Tuple<string, string>("<0x1C>", "\u001C"),
                new Tuple<string, string>("<0x1D>", "\u001D"),
                new Tuple<string, string>("<0x1E>", "\u001E"),
                new Tuple<string, string>("<0x1F>", "\u001F"),
            };
        }

        public override int GetByteCount(string str)
        {
            var bytes = GetBytes(str);
            return bytes.Length;
        }

        public override int GetByteCount(char[] chars, int index, int count)
        {
            return defaultEncoding.GetEncoder().GetByteCount(chars, index, count, true);
        }

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return defaultEncoding.GetEncoder().GetBytes(chars, charIndex, charCount, bytes, byteIndex, true); 
        }

        public override byte[] GetBytes(string s)
        {
            var str = s;

            foreach (var (item1, item2) in EncodingReplacements)
            {
                str = str.Replace(item1, item2);
            }

            return GetBytes(str.ToCharArray(), 0, str.Length);
        }

        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return defaultEncoding.GetDecoder().GetCharCount(bytes, index, count, true);
        }

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            return defaultEncoding.GetDecoder().GetChars(bytes, byteIndex, byteCount, chars, charIndex, true);
        }

        public override int GetMaxByteCount(int charCount)
        {
            return defaultEncoding.GetMaxByteCount(charCount);
        }

        public override int GetMaxCharCount(int byteCount)
        {
            return defaultEncoding.GetMaxCharCount(byteCount);
        }

        public override string GetString(byte[] bytes, int index, int count)
        {
            var str = new string(GetChars(bytes, index, count));

            foreach (var (item1, item2) in DecodingReplacements)
            {
                str = str.Replace(item1, item2);
            }

            return str;
        }
    }
}