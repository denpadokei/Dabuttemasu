using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dabuttemasu.Models
{
    public class Setting
    {
        [JsonIgnore]
        public static Setting Instance { get; } = new Setting();
        public string InstallFolder { get; set; }
        public void Save()
        {
            // TODO:Jsonにしてファイルに書き込む処理
        }

        public void Load()
        {
            // TODO:ファイルを読み込んで設定に反映させる処理
        }

        /// <summary>
        /// シングルトンなのでインスタンス作成禁止
        /// </summary>
        private Setting()
        {

        }
    }
}
