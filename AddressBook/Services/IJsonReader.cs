using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IJsonReader
    {
        Task<string> ReadAllTextAsync(string path);
    }
}