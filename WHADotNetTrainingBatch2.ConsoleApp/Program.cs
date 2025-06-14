// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;
using WHADotNetTrainingBatch2.ConsoleApp;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Create();
//adoDotNetExample.Read();
//adoDotNetExample.Update();
adoDotNetExample.Delete();


Console.ReadKey();