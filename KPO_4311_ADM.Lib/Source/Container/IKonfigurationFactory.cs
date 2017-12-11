using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_4311_ADM.Lib
{
    public interface IKonfigurationFactory
    {
        IKonfigurationSaver CreateKonfigurationSaver();
        IKonfigurationLoader CreateKonfigurationLoader();
    }

    public class KonfigurationFactoryTest : IKonfigurationFactory
    {
        public IKonfigurationLoader CreateKonfigurationLoader()
        {
            //throw new NotImplementedException();
            return new KonfigurationTestLoader();
        }

        public IKonfigurationSaver CreateKonfigurationSaver()
        {
            //throw new NotImplementedException();
            return new KonfigurationTestSaver();
        }
    }

    public class KonfigurationFactoryFile : IKonfigurationFactory
    {
        public IKonfigurationLoader CreateKonfigurationLoader()
        {
            //throw new NotImplementedException();
            return new KonfigurationLoader();
        }

        public IKonfigurationSaver CreateKonfigurationSaver()
        {
            //throw new NotImplementedException();
            return new KonfigurationSaver();
        }
    }

    public class KonfigurationFactoryPDRFile : IKonfigurationFactory
    {
        public IKonfigurationLoader CreateKonfigurationLoader()
        {
            //throw new NotImplementedException();
            return new KonfigurationPDRLoader();
        }

        public IKonfigurationSaver CreateKonfigurationSaver()
        {
            //throw new NotImplementedException();
            return new KonfigurationPDRSaver();
        }
    }

}