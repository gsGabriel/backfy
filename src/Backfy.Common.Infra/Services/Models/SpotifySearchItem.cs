using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backfy.Common.Infra.Services.Models
{

    public class SpotifySearchItem
    {
        [JsonProperty("albums")]
        public SpotifyPaging<SpotifyAlbum> Albums { get; set; }
    }
}
