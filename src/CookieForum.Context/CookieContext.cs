using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookieForum.Context
{
	public class CookieContext : IdentityDbContext<
		IdentityUser<Guid>,
		IdentityRole<Guid>,
		Guid,
		IdentityUserClaim<Guid>,
		IdentityUserRole<Guid>,
		IdentityUserLogin<Guid>,
		IdentityRoleClaim<Guid>,
		IdentityUserToken<Guid>>
	{
		public CookieContext(DbContextOptions<CookieContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			RenameIdentityEntities(modelBuilder);
		}

		private void RenameIdentityEntities(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityUser<Guid>>().ToTable("IdentityUsers", "dbo");
			modelBuilder.Entity<IdentityRole<Guid>>().ToTable("IdentityRoles", "dbo");
			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("IdentityUserClaims", "dbo");
			modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("IdentityUserRoles", "dbo");
			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("IdentityUserLogins", "dbo");
			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("IdentityRoleClaims", "dbo");
			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("IdentityUserTokens", "dbo");
		}
	}
}
