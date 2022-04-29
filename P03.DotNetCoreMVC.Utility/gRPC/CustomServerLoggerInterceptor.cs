using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace P03.DotNetCoreMVC.Utility.gRPC
{
    public class CustomServerLoggerInterceptor : Interceptor
    {
        public override  Task<TResponse>  UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            this.LogAOP<TRequest, TResponse>(MethodType.Unary ,context);
            return continuation(request, context);
        }

        private void LogAOP<TRequest, TResponse>(MethodType methodType, ServerCallContext context)
            where TRequest : class
            where TResponse : class
        {
            Console.WriteLine("****************LogAOP begin*****************");
            Console.WriteLine($"{context.RequestHeaders[0]}---{context.Host}--{context.Method}--{context.Peer}");
            Console.WriteLine($"Type: {methodType}. Request: {typeof(TRequest)}. Response: {typeof(TResponse)}");
            Console.WriteLine("****************LogAOP end*****************");
        }

    }
}
