using System.IO;
using System.Threading.Tasks;
using AddressBook.Services;

public class JsonReader: IJsonReader
{
    public async Task<string> ReadAllTextAsync(string path)
    {
        return await File.ReadAllTextAsync(path);
    }
}