using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TCP_Chat {
    public class CreateRole {

        public static class IdentityDataInit {
            public static void SeedData (
                RoleManager<IdentityRole> roleManager) {
                SeedRoles (roleManager);
            }

            public static void SeedRoles
                (RoleManager<IdentityRole> roleManager) {
                    
                    if (!roleManager.RoleExistsAsync ("User").Result) {
                        IdentityRole role = new IdentityRole ();
                        role.Name = "User";
                        IdentityResult roleResult = roleManager.CreateAsync (role).Result;
                    }
                }
        }
        }
        }