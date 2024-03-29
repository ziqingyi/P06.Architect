﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Architect.AspNetCoreCustom
{
    //core: public delegate Task RequestDelegate(HttpContext context);
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

                            Console.WriteLine($"***********Core***********context is : {context}");//await next.Invoke(context); //no next 


                            //next.Invoke(context);//core: Status404NotFound 


                            Console.WriteLine("This is hello world in HttpContext 3 Response end ");
                        });
                }
            );

            app.Use(func3);


            MyRequestDelegate resultDelegate =  app.Build();

            resultDelegate.Invoke("HttpContext is coming......");



            Console.WriteLine("all middleware is completed");
        }



    }

    public class MyAppBuilder: IAppBuilder
    {
        private readonly IList<Func<MyRequestDelegate,MyRequestDelegate>> _components 
            = new List<Func<MyRequestDelegate, MyRequestDelegate>>();

        IServiceProvider IAppBuilder.ApplicationServices 
        { 
            get => null; 
            set
            {
                
            } 
        }

        public IAppBuilder Use(Func<MyRequestDelegate, MyRequestDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        public MyRequestDelegate Build()
        {
            MyRequestDelegate app = context =>
            {
                Console.WriteLine("initial request delegate app with context: " + context);
                Console.WriteLine("The request reached the end of the pipeline without executing the endpoint, 404");

                /**
                If we reach the end of the pipeline, but we have an endpoint, then something unexpected has happened.
                This could happen if user code sets an endpoint, but they forgot to add the UseEndpoint middleware.
                var endpoint = context.GetEndpoint();
                var endpointRequestDelegate = endpoint?.RequestDelegate;
                if (endpointRequestDelegate != null)
                {
                    var message =
                        $"The request reached the end of the pipeline without executing the endpoint: '{endpoint!.DisplayName}'. " +
                        $"Please register the EndpointMiddleware using '{nameof(IApplicationBuilder)}.UseEndpoints(...)' if using " +
                        $"routing.";
                    throw new InvalidOperationException(message);
                }

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return Task.CompletedTask;
                 */
            };


            foreach (var component in _components.Reverse())
            {
                app = component(app);// invoke
            }

            return app;
        }

    }
    //source code: // public delegate Task RequestDelegate(HttpContext context);
    //
    // Summary:
    //     Defines a class that provides the mechanisms to configure an application's request
    //     pipeline.
    public interface IAppBuilder
    {

        //
        // Summary:
        //     Adds a middleware delegate to the application's request pipeline.
        //
        // Parameters:
        //   middleware:
        //     The middleware delegate.
        //
        // Returns:
        //     The Microsoft.AspNetCore.Builder.IApplicationBuilder.
        IAppBuilder Use(Func<MyRequestDelegate, MyRequestDelegate> middleware);
        //
        // Summary:
        //     Builds the delegate used by this application to process HTTP requests.
        //
        // Returns:
        //     The request handling delegate.
        MyRequestDelegate Build();


        // Summary:
        //     Gets or sets the System.IServiceProvider that provides access to the application's
        //     service container.
        IServiceProvider ApplicationServices
        {
            get;
            set;
        }


        #region  source code

        // Summary:
        //     Gets the set of HTTP features the application's server provides.
        //IFeatureCollection ServerFeatures
        //{
        //    get;
        //}

        //
        // Summary:
        //     Gets a key/value collection that can be used to share data between middleware.
        //IDictionary<string, object> Properties
        //{
        //    get;
        //}

        // Summary:
        //     Creates a new Microsoft.AspNetCore.Builder.IApplicationBuilder that shares the
        //     Microsoft.AspNetCore.Builder.IApplicationBuilder.Properties of this Microsoft.AspNetCore.Builder.IApplicationBuilder.
        //
        // Returns:
        //     The new Microsoft.AspNetCore.Builder.IApplicationBuilder.
        //IAppBuilder New();

        #endregion

    }



}
