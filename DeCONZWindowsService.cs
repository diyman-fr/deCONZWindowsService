using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using deCONZWindowsService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace deCONZWindowsService
{
    public class DeCONZWindowsService : BackgroundService
    {
        private readonly ILogger<DeCONZWindowsService> _logger;
        private readonly Settings _settings;

        public DeCONZWindowsService(ILogger<DeCONZWindowsService> logger, IOptions<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Run(stoppingToken);
        }

        protected async Task Run(CancellationToken stoppingToken)
        {
            await StartProcess(stoppingToken);
        }

        protected async Task<int> StartProcess(CancellationToken stoppingToken)
        {
            ProcessStartInfo psi = new ProcessStartInfo(_settings.DeCONZBinPath);
            psi.WindowStyle = ProcessWindowStyle.Minimized;
            psi.

            using (Process proc = Process.Start(psi))
            {
                await proc.WaitForExitAsync();
                return await StartProcess(stoppingToken);
            }
        }
    }
}
