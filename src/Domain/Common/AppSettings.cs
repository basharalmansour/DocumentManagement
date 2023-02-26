using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;

public class AppSettings
{
    public ClientSettings ClientSettings { get; set; }
    public ElasticSearchOptions ElasticSearchOptions { get; set; }
    public OtpSettings OtpSettings { get; set; }
    public string Sha1Key { get; set; }
}

public class ElasticSearchOptions
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Node { get; set; }
    public string HostUrls { get; set; }
    public string DockerHostUrl { get; set; }
}
public class OtpSettings
{
    public string Username { get; set; }
    public string Password { get; set; }
}