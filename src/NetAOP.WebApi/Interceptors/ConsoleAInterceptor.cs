﻿using Castle.DynamicProxy;

namespace NetAOP.WebApi.Interceptors
{
    public class ConsoleAInterceptor : IInterceptor
    {
        private ILogger logger;
        public ConsoleAInterceptor(ILogger logger)
        {
            this.logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            logger.LogDebug($"[ConsoleAInterceptor] -> Before Calling method: {invocation.Method.ReturnType} - {invocation.TargetType}.{invocation.Method.Name}");
            invocation.Proceed();
            logger.LogDebug($"[ConsoleAInterceptor] -> After Calling method: {invocation.Method.ReturnType} - {invocation.TargetType}.{invocation.Method.Name}");
        }
    }
}
