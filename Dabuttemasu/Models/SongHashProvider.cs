using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dabuttemasu.Models
{
    public static class SongHashProvider
    {
        /// <summary>
        /// 曲のハッシュ値を取得します。
        /// </summary>
        /// <param name="dir">カスタムソングのフォルダパス</param>
        /// <returns></returns>
        public static string GenerateHash(string dir)
        {
            var combinedBytes = Array.Empty<byte>();
            var infoFile = Path.Combine(dir, "info.dat");
            if (!File.Exists(infoFile))
                return null;
            combinedBytes = combinedBytes.Concat(File.ReadAllBytes(infoFile)).ToArray();
            var token = JToken.Parse(File.ReadAllText(infoFile));
            var beatMapSets = token["_difficultyBeatmapSets"];
            var numChars = beatMapSets.Children().Count();
            for (var i = 0; i < numChars; i++) {
                var diffs = beatMapSets.ElementAt(i);
                var numDiffs = diffs["_difficultyBeatmaps"].Children().Count();
                for (var j = 0; j < numDiffs; j++) {
                    var diff = diffs["_difficultyBeatmaps"].ElementAt(j);
                    var beatmapPath = Path.Combine(dir, diff["_beatmapFilename"].Value<string>());
                    if (File.Exists(beatmapPath))
                        combinedBytes = combinedBytes.Concat(File.ReadAllBytes(beatmapPath)).ToArray();
                }
            }

            var hash = CreateSha1FromBytes(combinedBytes.ToArray());
            return hash;
        }

        /// <summary>
        /// <see cref="byte[]"/>をSHA1ハッシュに変換します。
        /// </summary>
        /// <param name="input">変換する<see cref="byte[]"/></param>
        /// <returns></returns>
        private static string CreateSha1FromBytes(byte[] input)
        {
            using (var sha1 = SHA1.Create()) {
                var inputBytes = input;
                var hashBytes = sha1.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}
