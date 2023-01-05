using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace changecalc
{
    /// <summary>
    /// Calculate the change
    /// </summary>
    public class cGetChange
    {
        public cResponse cResponse = new cResponse();
        public double _price;
        public double _amount;
        public double _change;
        public int _bestChoice = 0;
        public cResponse CalculateChange(double price, double amount)
        {
            _price = price;
            _amount = amount; _change = 0;

            if (_amount < _price)
            {
                cResponse.valid = false;
                cResponse.message = "The paid amount is lesser than the price";
                return cResponse;
            }

            if (_amount == _price)
            {
                cResponse.valid = false;
                cResponse.message = "The paid amount is exact the price";
                return cResponse;
            }

            _change = _amount - _price;

            calc();
            cResponse.valid = true;
            return cResponse;
        }
        /// <summary>
        /// A Helper function for Calculate amount in list where the change is recorded.
        /// </summary>
        /// <returns></returns>
        Double CalcAmount()
        {
            Double result = 0;
            foreach (var itm in cResponse.changelist)
            {
                result += workingden.valueden[itm.numdenom] * itm.number;
            }
            return result;
        }
        public void calc()
        {
            if (CalcAmount() < _change)
            {
                foreach (var itm in workingden.valueden)
                {
                    var valuechoice = workingden.valueden[_bestChoice];
                    if (itm > valuechoice && itm <= _change)
                    {
                        if (CalcAmount() + itm <= _change)  
                        _bestChoice = workingden.valueden.FindIndex(x => x.Equals(itm));
                    }
                }

                
                var indexFound = cResponse.changelist.FindIndex(x => x.numdenom.Equals(_bestChoice));
                if (indexFound == -1)
                    cResponse.changelist.Add(new items { numdenom = _bestChoice, number = 1 });
                else
                    cResponse.changelist[indexFound].number = cResponse.changelist[indexFound].number + 1; 

            }

            if (CalcAmount() < _change) { _bestChoice = 0; calc(); }
            return;



        }

    }


}

