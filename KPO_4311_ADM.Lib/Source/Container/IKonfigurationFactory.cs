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

    public class KonfigurationFactoryModifiedPDRFile : IKonfigurationFactory
    {
        public IKonfigurationLoader CreateKonfigurationLoader()
        {
            //throw new NotImplementedException();
            return new KonfigurationModifiedPDRLoader(new int[] { 20, 20, 8, 8, 8, 19 });
        }

        public IKonfigurationSaver CreateKonfigurationSaver()
        {
            //throw new NotImplementedException();
            return new KonfigurationModifiedPDRSaver(new int[] { 20, 20, 8, 8, 8, 19 });
        }
    }

}