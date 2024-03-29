using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.DomainServices
{
    public  class NormalizedUrl
    {
        public static string TurkishToEnglish(string name)
        {
            string turkishCharacters = "ığüşöç ";
            string englishCharacters = "igusoc-";

            for (int i = 0; i < turkishCharacters.Length; i++)
            {
                name = name.ToLower().Replace(turkishCharacters[i], englishCharacters[i]);
            }
            return name;
        }
    }
}
