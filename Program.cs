using System;
using System.Reflection;
using System.IO;
namespace capp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string basepath = Directory.GetCurrentDirectory();
            Assembly a = Assembly.LoadFile(basepath + "/trymodule.dll");
            Type[] ss = a.GetTypes();
            foreach(Type t in ss){
                Console.WriteLine(t.Name + " [" + t.FullName + "]");
                Console.WriteLine("Is class? : " + t.IsClass);
                foreach(MethodInfo m in t.GetMethods())
                    Console.WriteLine("method name: " + m.Name);
            }

            object o1 = a.CreateInstance(ss[0].FullName);

            
            //Get method only return public method
            MethodInfo m1 = ss[0].GetMethods()[2];
            m1.Invoke(null,null); //Static method don't need object.

            MethodInfo m2 = ss[0].GetMethods()[3];
            m2.Invoke(o1,null); //Non-static method need a object.

            MethodInfo m3 = ss[0].GetMethods()[4];
            m3.Invoke(o1,new object[] {2,5}); //Method with parameter
            
            MethodInfo m4 = ss[0].GetMethod("f1");
            m4.Invoke(null,null);

            Console.WriteLine();
            Console.WriteLine("Property list:");
            foreach(PropertyInfo p in ss[0].GetProperties()){
                Console.WriteLine(p.Name);
                Console.WriteLine(p.GetValue(o1));
            }

            Console.WriteLine();
            Console.WriteLine("Field list:");
            foreach(FieldInfo f in ss[0].GetFields()){
                Console.WriteLine(f.Name);
                    Console.WriteLine(f.GetValue(o1));
                
            }

            /*Console.WriteLine();
            Console.WriteLine("Member list:");
            foreach(MemberInfo mb in ss[0].GetMembers()){
                Console.WriteLine(mb.Name);
            }*/
            

            //MethodInfo m4 = ss[0].GetMethods()[2];

            /*Console.WriteLine(m4.IsAbstract);
            Console.WriteLine(m4.IsAssembly);
            Console.WriteLine(m4.IsConstructedGenericMethod);
            Console.WriteLine(m4.IsConstructor);
            Console.WriteLine(m4.IsFinal);
            Console.WriteLine(m4.IsGenericMethod);
            Console.WriteLine(m4.IsGenericMethodDefinition);
            Console.WriteLine(m4.IsHideBySig);
            Console.WriteLine(m4.IsSpecialName);
            Console.WriteLine(m4.IsStatic);
            Console.WriteLine(m4.IsVirtual);
            Console.WriteLine(m4.IsPublic);
            Console.WriteLine(m4.IsPrivate);*/
            

            


            
            
        }
    }
}
