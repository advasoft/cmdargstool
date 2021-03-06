﻿
using System;

namespace Advasoft.CmdArgsTool
{
    public abstract class OptionsFactoryBase
    {
        private IOptionsPolicy _creationPolicy;
        private ILogger _logger;

        protected OptionsFactoryBase(IOptionsPolicy creationPolicy, ILogger logger)
        {
            _creationPolicy = creationPolicy;
            _logger = logger;
        }

        protected abstract OptionsBase CreateOptionsByPolicy(string[] cmdArgsArray,
            IOptionsPolicy creationPolicy);

        public OptionsBase CreateOptions(string[] cmdArgsArray)
        {
            try
            {
                return CreateOptionsByPolicy(cmdArgsArray, _creationPolicy);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception);
            }

            throw new ApplicationException("Invalid parse cmd arguments");
        }
    }
}
