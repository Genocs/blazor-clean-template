<!-- PROJECT SHIELDS -->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

[contributors-shield]: https://img.shields.io/github/contributors/Genocs/CleanArchitecture.svg?style=flat-square
[contributors-url]: https://github.com/Genocs/CleanArchitecture/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Genocs/CleanArchitecture?style=flat-square
[forks-url]: https://github.com/Genocs/CleanArchitecture/network/members
[stars-shield]: https://img.shields.io/github/stars/Genocs/CleanArchitecture.svg?style=flat-square
[stars-url]: https://img.shields.io/github/stars/Genocs/CleanArchitecture?style=flat-square
[issues-shield]: https://img.shields.io/github/issues/Genocs/CleanArchitecture?style=flat-square
[issues-url]: https://github.com/Genocs/CleanArchitecture/issues
[license-shield]: https://img.shields.io/github/license/Genocs/CleanArchitecture?style=flat-square
[license-url]: https://github.com/Genocs/CleanArchitecture/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/Genocs/CleanArchitecture">
    <img src="https://genocs-blog.netlify.app/wp-content/uploads/2021/05/GenocsPortalBannerv2.1.jpg" alt="Blazor Portal">
  </a>
  <h3 align="center">BlazorPortal - Clean Architecture Template</h3>
  <p align="center">
    Open Sourced Solution Template For Blazor Web-Assembly 5.0 built with MudBlazor Components
    <br />
    <a href="https://genocs-blog.netlify.app/blazor-template/><strong>Read the Documentation »</strong></a>
    <br />
    <br />
    <a href="https://github.com/Genocs/CleanArchitecture/issues">Report Bug</a>
    ·
    <a href="https://github.com/Genocs/CleanArchitecture/issues">Request Feature</a>
    .
    <a href="https://github.com/Genocs/CleanArchitecture/issues">Request Documentation</a>
  </p>
</p>

## About The Project :zap:

BlazorPortal is a Clean Architecture Solution Template for Blazor Webassembly 5.0 built with MudBlazor Components.

## Complete Overview - Youtube Video 🆕 📈

So, here is an in-depth video that takes you through the BlazorPortal Project! Do Like & Subscribe to my Youtube channel! It would be great if you could leave behind your valuable feedback in the comments section of the Video. This helps me reach a much wider audience with time :)

<a href="https://www.youtube.com/watch?v=j7BxKN7HYjk&lc=Ugy1SjDcmP0pboRxJe94AaABAg">Watch it here!</a>

[![Blazor Portal - Clean Architecture Solution Template for Blazor WebAssembly](http://img.youtube.com/vi/j7BxKN7HYjk/0.jpg)](http://www.youtube.com/watch?v=j7BxKN7HYjk "Blazor Portal - Clean Architecture Solution Template for Blazor WebAssembly")

### Tech Stack :muscle:

- Blazor WebAssembly 5.0 - ASP.NET Core Hosted Model
- [Entity Framework Core 5.0](https://docs.microsoft.com/en-us/ef/core/)

# BlazorPortal v3.0

- UI Improvements
- Docker Support
- Better Permissions Management
- Code Cleanups
- RTL Support
- Minor Bug Fixes
- Better Project Structure

# What to Expect in BlazorPortal 3.0?

- Modular Architecture
- Cleaner Separation Of Code
- Dedicated Documentation Website - [Here](https://genocs-blog.netlify.app/blazor-template/)
- Tutorials to add new entities, controllers
- UI Updates
- Support for PostgreSQL / MySQL - Easy DB Switching
- Theme Manager Integration to change UI Color Palettes / Fonts on the go.
- You can suggest your requirements as well!

# Down the Roadmap

- Migration to .NET 6
- Multi Tenancy
- Better Localization - JSON

# Getting Started 🦸

> **Important**
If you are already using Blazor Hero v1.x, make sure that you drop your existing database and re-update your database using the CLI as there are couple of new migrations added that may clash with your existing schema. Also, install the latest version of Blazor Portal.

The easiest way to get started with Blazor Hero is to install the [NuGet package](https://www.nuget.org/packages/GenocsBlazor/) and run `dotnet new GenocsBlazor`:

1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Install the latest DOTNET & EF CLI Tools by using this command `dotnet tool install --global dotnet-ef` 
3. Install the latest version of Visual Studio IDE 2019 (v16.8 and above) 🚀
4. Open up Command Prompt and run `dotnet new --install GenocsBlazor` to install the project template
5. Create a folder for your solution and cd into it (the template will use it as project name)
6. Run `dotnet new GenocsBlazor` to create a new Solution with all the Awesomeness 🕶️ of BlazorPortal 🦸

What to do next? Read the [guide](https://genocs-blog.netlify.app/blazor-template/general/getting-started/).

## Getting Started with Docker in Windows :rocket:

- Install Docker on Windows via `https://docs.docker.com/docker-for-windows/install/`
- Open up Powershell on Windows and run the following
    - `cd c:\`
    - `dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p securePassword123`
    - `dotnet dev-certs https --trust`
    - Note - Make sure that you use the same password that has been configured in the `docker-compose.yml` file. By default, `securePassword123` is configured.
- 5005 & 5006 are the ports setup to run Blazor Portal on Docker, so make sure that these ports are free. You could also change the ports in the `docker-compose.yml` and `Server\Dockerfile` files.
- Now navigate back to the root of the BlazorPortal Project on your local machine and run the following via terminal - `docker-compose -f 'docker-compose.yml' up --build`
- This will start pulling MSSQL Server Image from Docker Hub if you don't already have this image. It's around 500+ Mbs of download.
- Once that is done, dotnet SDKs and runtimes are downloaded, if not present already. That's almost 200+ more Mbs of download.
- PS If you find any issues while Docker installs the nuget packages, it is most likely that your ssl certificates are not intalled properly. Apart from that I also added the `--disable-parallel` in the `Server\dockerfile`to ensure network issues don't pop-up. You can remove this option to speed up the build process.
- That's almost everything. Once the containers are available, migrations are updated in the MSSQL DB, default data is seeded.
- Browse to https://localhost:5005/ to use your version of Blazor Portal!

# Complete Documentation :rocket:

Getting started with Blazor Portal – A Clean Architecture Template built for Blazor WebAssembly using MudBlazor Components. This project will make your Blazor Learning Process much easier than you anticipate. Blazor Portal is meant to be an Enterprise Level Boilerplate, which comes free of cost, completely open sourced. 

The provided documentation / guide will get you started with BlazorPortal in no-time. It provides a complete walkthrough about the project with to-the-point guides and notes.

<a href="https://genocs-blog.netlify.app/blazor-template/general/getting-started/"><strong>Read the Quick Start Guide</strong></a>

# Features

All the completed and the upcoming features are mentioned in the [Features.MD File](https://github.com/Genocs/CleanArchitecture/blob/master/Features.md)

## Contributing

Contributions are what make the open-source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

Here are the few contributions that I would highly appreciate ;)

- [ ] Need someone to add in the API Documentation for Swagger.
- [ ] Need someone to implement localization throughout every Razor Component of the solution under the WASM(Client) Project. You can take the Pages/Authentication/Login.razor as the point of reference. It is as simple as adding `@inject Microsoft.Extensions.Localization.IStringLocalizer<Login> localizer` to every page, changing the texts to `@localizer["Text Here"]` and finally adding resx files to the Resources Folder as per the folder structure.
- [ ] Need few contributors to add in various language translations as per the implemented Location. I got time to only add a few translations for French as of now.
- [ ] Need a UI contributor to look at the UX/UI of the entire project
- [ ] Need someone to buildup a cool Material Logo for BlazorPortal (BH):D Do contact me on LinkedIn (https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/).
- [ ] And finally, Stars from everyone! :D

## License

Distributed under the MIT License.

## Contact

### Giovanni Emanuele Nocco

- Blogs at [Genocs.com](https://genocs-blog.netlify.app)
- Facebook - [Genocs](https://www.facebook.com/Genocs)
- Twitter - [Giovanni Emanuele Nocco](https://www.twitter.com/Giovanni)
- Linkedin - [Giovanni Emanuele Nocco](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/)

## Support :star:

Has this Project helped you learn something New? or Helped you at work? Do Consider Supporting. 
Here are a few ways by which you can support.

- Leave a star! :star:
- Recommend this awesome project to your colleagues. 🥇
- Leave your feedback / comments regarding this project in the comments section on my blog [Genocs Library documentation](https://genocs-blog.netlify.app/blazor-template/general/getting-started/)
- Do consider endorsing me on LinkedIn for ASP.NET Core - [Connect via LinkedIn](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169) 🦸
- Or, If you want to support this project on the long run, [consider buying me a coffee](https://www.buymeacoffee.com/genocs)! ☕

<a href="https://www.buymeacoffee.com/genocs" target="_blank"><img src="https://genocs-blog.netlify.app/wp-content/uploads/2021/04/bmclogo.jpg" alt="Buy Me A Coffee" width="200"  style="height: 60px !important;width: 200px !important;" ></a>
