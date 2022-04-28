using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Grpc.Core;

namespace P03.DotNetCoreMVC.Utility.gRPC
{
    public class CustomClientLoggerInterceptor: Interceptor
    {
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest,TResponse> context,
            AsyncUnaryCallContinuation<TRequest,TResponse> continuation)
        {
            this.LogAOP(context.Method);
            return continuation(request, context);
        }

        private void LogAOP<TRequest, TResponse>(Method<TRequest, TResponse> method) 
            where TRequest:class 
            where TResponse : class
        { 
            Debug.WriteLine("****************LogAOP begin*****************");

            Debug.WriteLine($"{method.Name} -- {method.FullName} -- {method.ServiceName}");
            Debug.WriteLine($"Type: {method.Type}. Request: {typeof(TRequest)}. Response: {typeof(TResponse)}");

            Debug.WriteLine("****************LogAOP end*****************");
        }



    }
}
