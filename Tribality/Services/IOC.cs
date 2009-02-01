using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;
using System.IO;
using Rhino.Commons;
using Rhino.Commons.Binsor;
using Tribality;
using Tribality.Models;
using Tribality.Services;

namespace Tribality.Services
{
    public static class Container
    {
        public static T Resolve<T>()
        {
            return _Container.Resolve<T>();
        }

        public static T Resolve<T>(string key)
        {
            return _Container.Resolve<T>(key);
        }

        public static T Resolve<T>(IDictionary arguments)
        {
            return _Container.Resolve<T>(arguments);
        }

        public static T Resolve<T>(string key, IDictionary arguments)
        {
            return _Container.Resolve<T>(key, arguments);
        }

        private static RhinoContainer _Container;
        public static RhinoContainer GetContainer()
        {
            return _Container;
        }

        static Container() { _Initialize(); }

        private static void _Initialize()
        {
            _Container = new RhinoContainer();
            //Stream stream = 
            //    System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetManifestResourceStream("Skorer.IOC.Windsor.boo");
            //BooReader.Read(_Container, stream, "Windsor");

            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Windsor.boo";
            BooReader.Read(_Container, path);


        }

        private static WindsorContainer _Load(string configFile)
        {
            return new WindsorContainer(
                new XmlInterpreter(
                    new AssemblyResourceFactory().Create(
                        new CustomUri(configFile))));
        }
    }
}
