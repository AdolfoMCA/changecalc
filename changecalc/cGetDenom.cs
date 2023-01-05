using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace changecalc
{/// <summary>
/// Estructure for deserialize JSON with denominations list.
/// </summary>
    public class cGetDenom
    {
        public class jsonden
        {
            public bool Active { get; set; }
          public string  Denomination { get; set; }
            public string[]? Values { get; set; }
         }

        public class ljson
        {
            public List<jsonden> Countries { get; set; }
        }


 /// <summary>
 /// Register on global static class the active denominations 
 /// </summary>
        public void Run()
        {
            
            string text = File.ReadAllText(@"./denominations.json");
            var denomination = JsonSerializer.Deserialize<ljson>(text);
            foreach(var val in denomination.Countries)
            {
                if (val.Active)
                {
                    workingden.nameden = val.Denomination;
                    foreach(var den in val.Values)
                    {
                        workingden.valueden.Add(Double.Parse(den));
                    }
                }
            }
            
            
        }
    }
}
