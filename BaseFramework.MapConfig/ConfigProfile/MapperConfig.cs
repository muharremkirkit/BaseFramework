using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseFrameWork.Core.Mapper;



namespace BaseFramework.MapConfig.ConfigProfile
{
   public class MapperConfig
    {   //referanslara baseframework.core ekledik
        public static void RegisterMappers()
        {
           MapperFactory.RegisterMappers();
        }
    }
}
