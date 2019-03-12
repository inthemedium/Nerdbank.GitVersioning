﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerdbank.GitVersioning.Tasks;
using Xunit;

namespace NerdBank.GitVersioning.Tests
{
    public class AssemblyInfoTest
    {
        [Fact]
        public void FSharpGenerator()
        {
            var info = new AssemblyVersionInfo();
            info.AssemblyCompany = "company";
            info.AssemblyFileVersion = "1.3.1.0";
            info.AssemblyVersion = "1.3.0.0";
            info.CodeLanguage = "f#";
            
            var built = info.BuildCode();

            var expected = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssemblyInfo
[<assembly: System.Reflection.AssemblyVersionAttribute(""1.3.0.0"")>]
[<assembly: System.Reflection.AssemblyFileVersionAttribute(""1.3.1.0"")>]
[<assembly: System.Reflection.AssemblyInformationalVersionAttribute("""")>]
do()
[<System.CodeDom.Compiler.GeneratedCode(""" + AssemblyVersionInfo.GeneratorName + "," + AssemblyVersionInfo.GeneratorVersion + @""")>]
type internal ThisAssembly() =
  static member internal AssemblyVersion = ""1.3.0.0""
  static member internal AssemblyFileVersion = ""1.3.1.0""
  static member internal AssemblyCompany = ""company""
  static member internal RootNamespace = """"
do()
";
            Assert.Equal(expected, built);
        }
    }
}
