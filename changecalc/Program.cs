
using changecalc;

//This is mandatory it gets the denomination from the JSON file (denominations.json)
cGetDenom cChange = new cGetDenom();
cChange.Run();

//This is a example of use, you need to overload the method CalculateChange with Price,Amount paid
cGetChange getChange = new cGetChange();
cResponse _cresponse = getChange.CalculateChange(55.25,505.50);

//This way you can get the change, cresponse returns if is valid and the list (changelist) of indexes
//of  the workingden list it depends of the json.
if (_cresponse.valid)
{
    Console.WriteLine("Change:");
    foreach (var itm in _cresponse.changelist)
    {
        Console.WriteLine($"({workingden.valueden[itm.numdenom]} x {itm.number})");
    }
 }else
{
    Console.WriteLine($"{_cresponse.message}");
}


