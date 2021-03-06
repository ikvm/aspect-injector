﻿using AspectInjector.Broker;
using AspectInjector.BuildTask;
using AspectInjector.BuildTask.Processors;
using Microsoft.Build.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AspectInjector.CompileTimeTests
{
    [TestClass]
    public class RefOutTests : CompileTimeTestRunner
    {
        [TestMethod]
        public void Can_Compile_Ref_And_Out_Into_Array()
        {
            PE_Integrity_Is_Ok();
        }

        public class TargetClass
        {
            [Aspect(typeof(AspectImplementation))]
            public void TestMethod(object obj, ref object objRef, out object objOut, int value, ref int valueRef, out int valueOut, ref long longRef, ref double doubleRef, ref char charRef)
            {
                valueOut = 1;
                objOut = new object();
            }
        }

        public class AspectImplementation
        {
            [Advice(InjectionPoints.Before, InjectionTargets.Method)]
            public void BeforeMethod([AdviceArgument(AdviceArgumentSource.Arguments)] object[] args)
            {
            }
        }
    }
}