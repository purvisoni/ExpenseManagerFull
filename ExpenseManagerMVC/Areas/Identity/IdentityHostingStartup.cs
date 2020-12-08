// using System;
// using ExpenseManagerMVC.Areas.Identity.Data;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.UI;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// [assembly: HostingStartup(typeof(ExpenseManagerMVC.Areas.Identity.IdentityHostingStartup))]
// namespace ExpenseManagerMVC.Areas.Identity
// {
//     public class IdentityHostingStartup : IHostingStartup
//     {
//         public void Configure(IWebHostBuilder builder)
//         {
//             builder.ConfigureServices((context, services) => {

//                 services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//                     .AddEntityFrameworkStores<ExpenseManagerMVCIdentityDbContext>();
//             });
//         }
//     }
// }