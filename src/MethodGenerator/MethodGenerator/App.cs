using MethodGeneratorTemplate.Settings;
using Microsoft.Extensions.Logging;

namespace MethodGeneratorTemplate;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task RunAsync() {
        logger.LogDebug("{SettingData}", settings.ToString());
    }
}