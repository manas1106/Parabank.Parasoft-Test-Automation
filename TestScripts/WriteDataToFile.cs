using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaBankWebsite.TestScripts
{
    [TestClass]
    public class WriteDataToFile
    {
        [TestMethod]
        public void WriteIntoFile()
        {
         
            SeleniumSetMethods.WriteDataIntoFile(@"C:\Users\manas.bisen\Documents\C# Practice\ParaBankWebsite\Files\Software testing.txt", "What is Defect?");
            
        }
    }
}
