using Cabother.Exceptions.Environments;
using Microsoft.Extensions.Configuration;

namespace Cabother.Helpers
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Recupera a configuração das variaveis de ambiente
        /// </summary>
        /// <param name="configuration">objeto com as configurações do ambiente</param>
        /// <param name="config">Nome da configuração que está sendo procurada</param>
        /// <param name="required">Se a configuração é obrigatória</param>
        /// <typeparam name="T">Tipo da configuração</typeparam>
        public static T GetConfiguration<T>(this IConfiguration configuration, string config, bool required = true)
        {
            var environmentVariable = configuration[config.ToUpper()];

            if (required && string.IsNullOrWhiteSpace(environmentVariable))
            {
                throw new InvalidEnvironmentVariableException(config.ToUpper());
            }

            return configuration.GetValue<T>(config.ToUpper());
        }
    }
}