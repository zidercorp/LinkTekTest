using LinkTekTest.Application.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LinkTekTest.Application.Services
{
    public class USStateService
    {
        IList<StateModel> StateModelList { get; set; }

        public IList<StateModel> GetZipCodeModels()
        {
            if (StateModelList == null)
            {
                var filePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "JsonFiles", "States.json");
                string jsonContent = File.ReadAllText(filePath);
                StateModelList = JsonConvert.DeserializeObject<IList<StateModel>>(jsonContent);
            }

            return StateModelList;
        }
    }
}
