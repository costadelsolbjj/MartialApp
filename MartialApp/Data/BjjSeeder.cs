using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartialApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace MartialApp.Data
{
  public class BjjSeeder
  {
    private readonly BJJSchoolContext _ctx;
    private readonly IWebHostEnvironment _hosting;
    private readonly UserManager<IdentityUser> _userManager;

    public BjjSeeder(BJJSchoolContext ctx, IWebHostEnvironment hosting, UserManager<IdentityUser> userManager)
    {
      _ctx = ctx;
      _hosting = hosting;
      _userManager = userManager;
    }

    public async Task SeedAsync()
    {

            var trainers =  _ctx.Trainers.ToList();

            foreach (var student in trainers)
            {
                // Seed the Main User
                IdentityUser user = await _userManager.FindByEmailAsync(student.Email);
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        Email = student.Email,
                        UserName = student.Email
                    };

                    var result = await _userManager.CreateAsync(user, "Martial!2020");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create user in Seeding");
                    }
                    else
                    {
                        user = await _userManager.FindByEmailAsync(student.Email);
                        student.UserGuid = Guid.Parse(user.Id);
                        _ctx.Update(student);

                        _ctx.SaveChanges();
                    }
                }
            }

      
    }
  }
}
