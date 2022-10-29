﻿using Castle.DynamicProxy;

namespace NetAOP.WebApi.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {   
            logger.LogDebug($"[LoggingInterceptor] -> Calling method: {invocation.Method.ReturnType} - {invocation.TargetType}.{invocation.Method.Name}");
            invocation.Proceed();
        }
    }
}
