using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfPodServiceLibrary
{
    [ServiceContract]
    public interface IPodServices
    {
        [OperationContract]
        DateTime GetDateDaysAgo(int numberOfDaysAgo);    

        [OperationContract]
        string AddSpaceBetweenChars(string input);
    }
}
