﻿using System;
using System.IO;
using System.Reflection;

namespace Evolve.Core.Test.Driver
{
    public static class TestContext
    {
        static TestContext()
        {
            ProjectFolder = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(typeof(TestContext).GetTypeInfo().Assembly.Location), @"../../../"));
            NetCore10DriverResourcesProjectFolder = Path.GetFullPath(Path.Combine(ProjectFolder, @"../Evolve.Core.Test.Resources.SupportedDrivers"));
#if DEBUG
            NetCore10DepsFile = Path.Combine(NetCore10DriverResourcesProjectFolder, @"bin/Debug/netcoreapp1.1/Evolve.Core.Test.Resources.SupportedDrivers.deps.json");
#else
            NetCore10DepsFile = Path.Combine(NetCore10DriverResourcesProjectFolder, @"bin/Release/netcoreapp1.1/Evolve.Core.Test.Resources.SupportedDrivers.deps.json");
#endif
        }

        public static string ProjectFolder { get; }
        public static string NetCore10DriverResourcesProjectFolder { get; }
        public static string NetCore10DepsFile { get; }
        public static string NugetPackageFolder => $@"{EnvHome}/.nuget/packages";
        public static string EnvHome => Environment.GetEnvironmentVariable("USERPROFILE") ?? Environment.GetEnvironmentVariable("HOME");
        public static bool AppVeyor => Environment.GetEnvironmentVariable("APPVEYOR") == "True";
        public static bool Travis => Environment.GetEnvironmentVariable("TRAVIS") == "True";
    }
}
