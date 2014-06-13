# Cors.ConfigProfiles

## Description
In ASP.NET Web API, you can use the EnableCorsAttribute class provided by the Microsoft.AspNet.WebApi.Cors NuGet package to enable CORS on an API controller or its actions. When you use this attribute to actually limit the capabilities of an external origin, you need to recompile and redeploy your API project if you need to change these limitations.

Cors.ConfigProfiles allows you to do the same thing, but also enables you to specify a profile, like the OutputCacheAttribute does for example. This means you can put the CORS configuration inside the web.config file. Should you need to change the CORS configuration, then it might be enough just to change the web.config file on the webserver!

## Get it on NuGet!

Cors.ConfigProfiles is available on NuGet. You can find it using the package manager, or install it directly using the following command:

    Install-Package Cors.ConfigProfiles

## Example usage
Using Cors.ConfigProfiles is very easy. In your code, add the EnableCorsAttribute on your API controller or an action:

    [EnableCors("*", "*", "*")]
	public class MyApiController : ApiController {
	    ...
    }

The example above demonstrates using the EnableCorsAttribute like the original one, specifying allowed origins, headers and methods. If you want to use a profile, you only need to give the profile name:

    [EnableCors("MyApiProfile")]
	public class MyApiController : ApiController {
	    ...
    }

This profile needs to be added to the web.config file to make it work:

	<?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="cors" type="Cors.ConfigProfiles.Configuration.CorsSection, Cors.ConfigProfiles, Version=5.1.3.0, Culture=neutral, PublicKeyToken=253caed373cef676" requirePermission="false" />
      </configSections>
      <cors>
        <corsProfiles>
          <add name="MyApiProfile" 
               origins="*" 
               methods="*" 
               headers="*" 
          />
        </corsProfiles>
      </cors>
	  ...

Note that you can also add other parameters to this configuration element, like:

* exposedHeaders
* supportsCredentials
* preflightMaxAge
