﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Architect
{
    public delegate void MyRequestDelegate(string context);
    public static class MiddlewareProcess
    {
        
        public static void Show1()
        {

            MyAppBuilder  app = new MyAppBuilder();

            Func<MyRequestDelegate, MyRequestDelegate> func1 = new Func<MyRequestDelegate, MyRequestDelegate>(
            next =>
            {
                Console.WriteLine("This is middleware 1 ");
                return new MyRequestDelegate(
                     context =>
                    {
                         Console.WriteLine("This is hello world in HttpContext Response 1 begin ");

                         next.Invoke(context);

                         Console.WriteLine("This is hello world in HttpContext Response 1 end ");
                    });
            }
            );

            app.Use(func1);

            Func<MyRequestDelegate, MyRequestDelegate> func2 = new Func<MyRequestDelegate, MyRequestDelegate>(
                next =>
                {
                    Console.WriteLine("This is middleware 2 ");
                    return new MyRequestDelegate(
                         context =>
                        {
                            Console.WriteLine("This is hello world in HttpContext 2 Response begin ");

                             next.Invoke(context);

                             Console.WriteLine("This is hello world in HttpContext 2 Response end ");
                        });
                }
            );

            app.Use(func2);

            Func<MyRequestDelegate, MyRequestDelegate> func3 = new Func<MyRequestDelegate, MyRequestDelegate>(
                next =>
                {
                    Console.WriteLine("This is middleware 3 ");
                    return new MyRequestDelegate(
                         context =>
                        {
                            Console.WriteLine("This is hello world in HttpContext 3 Response begin ");

                            Console.WriteLine("*******************Core****************************");//await next.Invoke(context); //no next 

                            Console.WriteLine("This is hello world in HttpContext 3 Response end ");
                        });
                }
            );

            app.Use(func3);


        }



    }

    public class MyAppBuilder
    {
        private readonly IList<Func<MyRequestDelegate,MyRequestDelegate>> _components 
            = new List<Func<MyRequestDelegate, MyRequestDelegate>>();


        public void Use(Func<MyRequestDelegate, MyRequestDelegate> middleware)
        {
            _components.Add(middleware);
        }

        public MyRequestDelegate Build()
        {
            //if we reach the end of the pipeline, but we have an endpoint, then something unexpected has happended.
            //this could happen if use code sets an endpoint, but they forget to add the UseEndpoint middleware. 

            MyRequestDelegate app = context =>
            {
                Console.WriteLine("initial request delegate app");
                return Task.CompletedTask;
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }

    }





}
