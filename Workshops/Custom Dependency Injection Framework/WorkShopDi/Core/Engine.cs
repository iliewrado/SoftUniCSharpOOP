using SoftUniDIFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using WorkShopDi.Contracts;

namespace WorkShopDi.Core
{
    public class Engine
    {
        //[Inject]
        //[Named("FileWriter")]
        private IWriter fileWriter;

        //[Inject]
        //[Named("ConsoleWriter")]
        private IWriter consoleWriter;

        //[Inject]
        private IReader reader;

        [Inject]
        public Engine(
            [Named("ConsoleWriter")]
            IWriter consoleWriter,
            [Named("FileWriter")]
            IWriter fileWriter,
            IReader reader)
        {
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
            this.reader = reader;
        }

        public void Run()
        {
            string text = reader.Read();
            fileWriter.Write(text);
            consoleWriter.Write(text);
        }
    }
}
