﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TF.Core.Entities
{
    public class GameFileSearch
    {
        public string RelativePath { get; set; }
        public string SearchPattern { get; set; }
        public bool IsWildcard { get; set; }
        public bool RecursiveSearch { get; set; }
        public IList<string> Exclusions { get; }

        public GameFileSearch()
        {
            Exclusions = new List<string>();
        }

        public string[] GetFiles(string path)
        {
            var result = new List<string>();

            var fullPath = Path.Combine(path, RelativePath);
            if (IsWildcard)
            {
                var files = Directory.GetFiles(fullPath, SearchPattern,
                    RecursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                foreach (var file in files)
                {
                    var excluded = Exclusions.Any(x => file.Contains(x));
                    if (!excluded)
                    {
                        result.Add(file);
                    }
                }
            }
            else
            {
                var excluded = Exclusions.Any(x => fullPath.Contains(x));
                if (!excluded && File.Exists(Path.Combine(fullPath, SearchPattern)))
                {
                    result.Add(Path.Combine(fullPath, SearchPattern));
                }
            }

            return result.ToArray();
        }
    }
}