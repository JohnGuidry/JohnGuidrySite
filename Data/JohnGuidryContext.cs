using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JohnGuidry.Models;

namespace JohnGuidry.Data
{
    public class JohnGuidryContext : DbContext
    {
        public JohnGuidryContext (DbContextOptions<JohnGuidryContext> options)
            : base(options)
        {
        }

        public DbSet<JohnGuidry.Models.DevNotes> DevNotes { get; set; } = default!;
    }
}
