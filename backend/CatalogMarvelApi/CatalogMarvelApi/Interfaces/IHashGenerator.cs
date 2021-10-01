using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMarvelApi.Interfaces
{
    public interface IHashGenerator
    {
        string Generate(string text);
    }
}
