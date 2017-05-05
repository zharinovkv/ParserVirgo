using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParserAvito
{
    public class PingProxi
    {
        public async Task<List<string>> Example()
        {
            var allIps = Proxi.WebanetLabsNet.GetProxi();
            var goodIps = await PingProxi.Ping(allIps);
            return goodIps;
        }

        private static async Task<List<string>> Ping(List<string> ips)
        {
            List<string> goodIps = new List<string>();
            List<string> badIps = new List<string>();
            int timeout = 1;

            var tasks = ips.Select(ipAndPort =>
            {
                Ping ping = new Ping();
                var ip = ipAndPort.Split(':')[0];
                return ping.SendPingAsync(ip, timeout);
            }).ToList();

            var results = await Task.WhenAll(tasks);

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].Status == IPStatus.Success)
                    goodIps.Add(ips[i]);
                else
                    badIps.Add(ips[i]);
            }
            return goodIps;
        }
    }
}
