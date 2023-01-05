using changecalc;

namespace UTests
{
    [TestClass]
    public class UnitTest1
    {
        //Validate the change
        [TestMethod]
        public void TestCalc()
        {
            //Fill the list with de denomination
            cGetDenom cChange = new cGetDenom();
            cChange.Run();
            cGetChange gc = new cGetChange();
            var res = gc.CalculateChange(78, 100);
            var sol = 0.0;
            foreach (var itm in res.changelist)
            {
                sol += (workingden.valueden[itm.numdenom] * itm.number);

            }
            Assert.AreEqual(22, sol);
        }

        //Validate the return of not valid if mount paid is less than price
        [TestMethod]
        public void ValidateMountLessthanPrice()
        {
            //Fill the list with de denomination
            cGetDenom cChange = new cGetDenom();
            cChange.Run();
            cGetChange gc = new cGetChange();
            var res = gc.CalculateChange(250, 150);
            Assert.AreEqual(res.valid, false);
        }

        //Validate the return of not valid if mount is equal to price
        [TestMethod]
        public void ValidateMountEqPrice()
        {
            //Fill the list with de denomination
            cGetDenom cChange = new cGetDenom();
            cChange.Run();
            cGetChange gc = new cGetChange();
            var res = gc.CalculateChange(150, 150);
            Assert.AreEqual(res.valid, false);
        }
    }
}