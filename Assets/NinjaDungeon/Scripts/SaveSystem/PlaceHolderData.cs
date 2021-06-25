using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    /// <summary>
    /// Информация для сохранения PlaceHolder
    /// </summary>
    public class PlaceHolderData : BaseBuildingState
    {
        [JsonProperty("remainResource")]
        public List<Resource> RemainResources { get; set; }
    }
}
