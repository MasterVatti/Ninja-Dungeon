using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    /// <summary>
    /// Информация для сохранения PlaceHolder
    /// </summary>
    public class PlaceHolderData : BuildingData
    {
        [JsonIgnore]
        public List<Resource> RemainResources
        {
            set
            {
                foreach (var resource in value)
                {
                    State.Add((int)resource.Type, resource.Amount);
                }
            } }
    }
}
