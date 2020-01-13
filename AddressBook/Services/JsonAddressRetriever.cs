using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AddressBook.Models;
using AddressBook.Services;
using Newtonsoft.Json;

public class JsonAddressRetriever: IAddressRetriever
{
    private IJsonReader _jsonReader;
    
    public JsonAddressRetriever(IJsonReader jsonReader)
    {
        _jsonReader = jsonReader;
    }

    public async Task<List<Address>> GetAll()
    {
        var addressesJson = await _jsonReader.ReadAllTextAsync("Addresses.json");
        return JsonConvert.DeserializeObject<List<Address>>(addressesJson);
    }
}