using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    public class ValueTypeRefType
    {
        public void AlterString(ref string xyz)
        {
            xyz = xyz + "!@# JUNK";
        }

        public void AlterNumber(ref int abc)
        {
            abc = abc+1;
        }

        public void AlterCollection(List<int> abcList)
        {
            abcList.Add(99);
        }
    }
}
