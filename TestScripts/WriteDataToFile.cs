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
         
            SeleniumSetMethods.WriteDataIntoFile(@"Provide path of file located at", "Text to write in file");
            
        }
    }
}
